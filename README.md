# E-Commerce Demo using Razor Pages and Clean Architecture

Welcome to the E-Commerce demo project showcasing the usage of Razor Pages and Clean Architecture. This project facilitates managing clients, products, and their relationships using a structured architectural approach.

## Disclaimer

This project has two branches, master branch is a code without using asynchronous and the other branch (async) is a code using asynchronous.

## Entities

1. **Client**: Represents a customer or user of the system.
2. **Product**: Represents an item available for purchase.
3. **ClientProduct**: Represents the relationship between a client and a product.

## Functionalities

1. **Add**: Add new clients, products, and client-product relationships.
2. **Remove**: Remove clients and products from the system.
3. **Edit**: Modify client and product details.
4. **Read**: View lists of clients, products, and client-product relationships.

## Technologies Used

1. **ASP.NET Core 8.0**: Web framework for building web applications.
2. **EF Core 8.0**: Entity Framework Core for database access and ORM.
3. **Razor Pages**: Lightweight framework for building dynamic web pages using C#.

## Architectures Used

1. **Clean Architecture (Onion)**: Modular and layered architectural style promoting separation of concerns and maintainability.

## Patterns Used

1. **Repository Pattern**: Abstraction layer for data access, providing a consistent interface for data operations.
2. **Unit of Work**: Coordinates multiple repository operations within a single transaction.
3. **Dependency Injection**: Technique for achieving loose coupling and promoting testability and maintainability.

## Packages

- **Microsoft.Extensions.Configuration.Abstractions**
- **Microsoft.Extensions.DependencyInjection.Abstractions**
- **Microsoft.EntityFrameworkCore**
- **Microsoft.EntityFrameworkCore.Design**
- **Microsoft.EntityFrameworkCore.SqlServer**
- **Microsoft.EntityFrameworkCore.Tools**

## Getting Started

To set up the project:

1. Install the required packages listed above.
2. Configure the ASP.NET Core project using Razor Pages.
3. Set up Entity Framework Core to use SQL Server as the database provider.
4. Implement the Clean Architecture principles, including repository pattern, unit of work, and dependency injection.

## Contributions

Contributions to this project are welcome. Please refer to the [contribution guidelines](CONTRIBUTING.md) for details on how to contribute.

## License

This project is licensed under the [MIT License](LICENSE).