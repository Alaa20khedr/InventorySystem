# Inventory System

An inventory and sales system with a 4 tier architecture, demonstrating concurrency handling, separation of concerns, and a user-friendly Angular interface. The backend API enforces stock limits using optimistic concurrency, while the frontend displays real-time stock and error messages.

## Technologies
- ASP.NET Core 9
- Entity Framework Core with SQL Server
- Angular 19 (Standalone components)
- Bootstrap / Custom CSS

## How to Run

### Backend
1. Open `InventorySystem.sln` in Visual Studio or use terminal.
2. Set `InventorySystem.API` as startup project.
3. Run `dotnet run` or press F5.
4. API will run on `https://localhost:7044` (or other port). Swagger available at `/swagger`.

### Frontend
1. Navigate to `inventory-ui` folder.
