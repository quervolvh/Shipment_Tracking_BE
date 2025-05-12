# 📦 Shipment Tracking API

A clean and modular ASP.NET Core Web API for managing and tracking shipments.  
This project is structured using **Domain-Driven Design (DDD)** principles with clearly separated concerns across **Domain**, **Application**, **Infrastructure**, and **Presentation** layers.

---

## 🚀 Features

- 📦 **Shipments API**  
  - Create new shipments  
  - List all shipments  
  - Filter shipments by **carrier** and **status**

- 🚚 **Carriers API**  
  - Manage available carriers

- 🛒 **Products API**  
  - Manage products associated with shipments

- 📄 **Swagger (OpenAPI)** for easy API exploration and documentation

- 🗃️ **SQLite** integration via **Entity Framework Core**

- 🧱 Clean architecture with minimal coupling and high maintainability

- 📃 Lightweight usage of `ILogger<T>` for logging

---

## 🧱 Technologies

- [.NET 8+](https://dotnet.microsoft.com/en-us/)
- [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/) with SQLite provider
- [Swagger / Swashbuckle](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)
- ASP.NET Core Web API
- Clean Architecture / Domain-Driven Design (DDD)

---

## 📂 Project Structure

/YourProject
│
├── /Domain # Core business entities and interfaces
│ └── Entities
│
├── /Application # DTOs, service interfaces, use cases
│ └── DTOs
│
├── /Infrastructure # EF Core DbContext, Repositories, SQLite config
│ └── Data
│
├── /Presentation # API Controllers, Filters
│ └── Controllers
│
├── /Shared # Common utilities, wrappers (e.g. Result<T>)
│
├── appsettings.json # Configuration
├── Program.cs # App startup
└── README.md # This file
---

## 🛠️ Setup & Run

### Prerequisites

- [.NET SDK 8 or 9](https://dotnet.microsoft.com/en-us/download)
- SQLite installed (optional, EF Core will create the DB)

### Run the App

```bash
dotnet restore
dotnet ef database update
dotnet run


The app will start at:
http://localhost:5281


## 🔍 API Documentation (Swagger)

Swagger UI is enabled for this project to provide interactive and up-to-date API documentation.

Once the app is running, navigate to:

http://localhost:5281/swagger


Here, you can:

- View all available endpoints
- See detailed request and response structures
- Test endpoints directly in the browser
- Explore query parameters, response codes, and schemas

### 🧪 Example Endpoints

#### 📦 Shipment Endpoints

| Method | Route                    | Description                           |
|--------|--------------------------|---------------------------------------|
| GET    | `/api/shipments`         | Retrieve all shipments                |
| POST   | `/api/shipments`         | Create a new shipment                 |
| PUT   | `/api/shipments`          | Update a shipment                     |
| GET    | `/api/shipments?status=InTransit&carrierId=1` | Filter shipments by status and carrier |

#### 🛒 Product Endpoints

| Method | Route             | Description         |
|--------|-------------------|---------------------|
| GET    | `/api/products`   | Retrieve all products|
| POST   | `/api/products`   | Add a new product   |

#### 🚚 Carrier Endpoints

| Method | Route            | Description         |
|--------|------------------|---------------------|
| GET    | `/api/carriers`  | Retrieve all carriers|
| POST   | `/api/carriers`  | Add a new carrier   |

### ✅ Notes

- All endpoints use standard REST semantics.
- Responses include appropriate HTTP status codes and JSON payloads.
- Use Swagger UI to validate your requests before consuming the API programmatically.
