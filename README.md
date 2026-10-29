# stock-sales-system-api

## Project Structure

    stock-sales-system-api/
    ├── src/
    │   ├── StockSalesSystem.API/              # Web API layer
    │   ├── StockSalesSystem.Application/      # Use cases and orchestration
    │   ├── StockSalesSystem.Domain/           # Entities and business rules
    │   └── StockSalesSystem.Infrastructure/   # Data access
    ├── tests/
    │   ├── StockSalesSystem.UnitTests/        # Domain and application tests
    │   └── StockSalesSystem.IntegrationTests/ # API and database tests
    └── StockSalesSystem.sln                   # Solution file