## W12_Survivor

W12_Survivor is a web API project built using .NET 8.0 and Entity Framework Core. 
It integrates with a PostgreSQL database using Npgsql. This API is designed to serve as a foundation 
for applications requiring robust data management and modern API architecture.

### Features

- Implements RESTful API design principles.
- Manages competitors and categories with a one-to-many relationship.
- CRUD operations for competitors and categories.
- Uses PostgreSQL as the database for high-performance data storage.
- Utilizes Entity Framework Core for database interaction.
- Migration and schema management for database updates.
- Modular and scalable architecture.

---

### Technologies Used

- **.NET 8.0**: A modern, fast, and scalable framework.
- **Entity Framework Core**: ORM for data manipulation.
- **PostgreSQL**: Relational database management.
- **Npgsql**: Data provider for PostgreSQL.

---

### Database Configuration

The project uses Entity Framework Core to manage database interactions. The database schema is updated through migrations.

To add new migrations:
```bash
dotnet ef migrations add MigrationName
```
To apply migrations:
```bash
dotnet ef database update
```

Ensure that PostgreSQL is running locally or accessible from the configured connection string in `appsettings.json` file.

---

### Usage Instructions

1. **API Endpoints**:

### CompetitorsController:
- `GET /api/competitors` - List all competitors.
- `GET /api/competitors/{id}` - Retrieve a specific competitor by ID.
- `GET /api/competitors/categories/{CategoryId}` - Retrieve competitors by category ID.
- `POST /api/competitors` - Create a new competitor.
- `PUT /api/competitors/{id}` - Update a specific competitor.
- `DELETE /api/competitors/{id}` - Delete a specific competitor.

### CategoriesController:
- `GET /api/categories` - List all categories.
- `GET /api/categories/{id}` - Retrieve a specific category by ID.
- `POST /api/categories` - Create a new category.
- `PUT /api/categories/{id}` - Update a specific category.
- `DELETE /api/categories/{id}` - Delete a specific category.

---
