## Inventory Control System Backend - README

This README provides an overview of the backend system for an Inventory Control System developed using .NET 8.

### Introduction

The Inventory Control System backend is a pivotal component designed to manage and maintain inventory-related data and operations.

### Features

- **CRUD Operations**: Create, Read, Update, and Delete operations for managing inventory items.

### Technologies Used

- **.NET 8**: The backend is developed using .NET 8, a powerful and versatile framework for building scalable and high-performance applications.
- **C#**: The primary programming language used for development.
- **Entity Framework Core**: For database interaction and management.
- **ASP.NET Core Web API**: For building RESTful APIs to communicate with the frontend and other services.
- **Swagger**: API documentation and testing tool for developers.

### Setup and Installation

To set up the Inventory Control System backend locally, follow these steps:

1. **Clone the Repository**: Clone the backend repository to your local machine.

   ```bash
   git clone <repository_url>
   ```
   
2. **Change the connection string located on appsettings.json**.


2. **Database Update**: Update the database with the applied migration.

   ```bash
   update-database
   ```
