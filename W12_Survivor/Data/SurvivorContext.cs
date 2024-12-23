using Microsoft.EntityFrameworkCore;
using W12_Survivor.Models;

namespace W12_Survivor.Data;

public class SurvivorContext : DbContext
{
    public SurvivorContext(DbContextOptions<SurvivorContext> options) : base(options) { }
    
    public DbSet<Competitor> Competitors { get; set; }
    public DbSet<Category> Categories { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Competitor>()
            .HasOne(c => c.Category)
            .WithMany(c => c.Competitors)
            .HasForeignKey(c => c.CategoryId);

        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Warriors", IsDeleted = false},
            new Category { Id = 2, Name = "Wizards", IsDeleted = false}
            );
        
        modelBuilder.Entity<Competitor>().HasData(
            new Competitor { Id = 1, FirstName = "Illidan", LastName = "Stormrage", CategoryId = 1, IsDeleted = false},
            new Competitor { Id = 2, FirstName = "Garrosh", LastName = "Hellscream", CategoryId = 1, IsDeleted = false},
            new Competitor { Id = 3, FirstName = "Jaina", LastName = "Proudmoore", CategoryId = 2, IsDeleted = false},
            new Competitor { Id = 4, FirstName = "Malfurion", LastName = "Stormrage", CategoryId = 2, IsDeleted = false},
            new Competitor { Id = 5, FirstName = "Tyrande", LastName = "Whisperwind", CategoryId = 2, IsDeleted = false},
            new Competitor { Id = 6, FirstName = "Sylvanas", LastName = "Windrunner", CategoryId = 1, IsDeleted = false},
            new Competitor { Id = 7, FirstName = "Anduin", LastName = "Wrynn", CategoryId = 1, IsDeleted = false},
            new Competitor { Id = 8, FirstName = "Cairne", LastName = "Bloodhoof", CategoryId = 1, IsDeleted = false},
            new Competitor { Id = 9, FirstName = "Arthas", LastName = "Menethil", CategoryId = 1, IsDeleted = false},
            new Competitor { Id = 10, FirstName = "Kael'thas", LastName = "Sunstrider", CategoryId = 2, IsDeleted = false},
            new Competitor { Id = 11, FirstName = "Muradin", LastName = "Bronzebeard", CategoryId = 1, IsDeleted = false},
            new Competitor { Id = 12, FirstName = "Maiev", LastName = "Shadowsong", CategoryId = 1, IsDeleted = false},
            new Competitor { Id = 13, FirstName = "Millhouse", LastName = "Manastorm", CategoryId = 2, IsDeleted = false},
            new Competitor { Id = 14, FirstName = "Lorgus", LastName = "Jett", CategoryId = 2, IsDeleted = false},
            new Competitor { Id = 15, FirstName = "Shandris", LastName = "Feathermoon", CategoryId = 1, IsDeleted = false}
            );
        
        // set CreatedDate and ModifiedDate to the current time when
        // a Competitor or Category is created or modified in the database
        modelBuilder.Entity<Competitor>().Property(c => c.CreatedDate).HasDefaultValueSql("now()");
        modelBuilder.Entity<Competitor>().Property(c => c.ModifiedDate).HasDefaultValueSql("now()");
        
        modelBuilder.Entity<Category>().Property(c => c.CreatedDate).HasDefaultValueSql("now()");
        modelBuilder.Entity<Category>().Property(c => c.ModifiedDate).HasDefaultValueSql("now()");
    }
}