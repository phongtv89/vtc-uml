# Clothing Shop Management System

## Overview
The Clothing Shop Management System is a C# console application designed to manage products, orders, and customers for a clothing shop. It utilizes a three-tier architecture, separating the application into Data Access, Business Logic, and Presentation layers. The application connects to a MySQL database for data storage and provides functionality for two types of users: staff and accountants.

## Features
- **User Authentication**: Login functionality for staff and accountant users.
- **Product Management**: Staff can search, add, edit, and delete products.
- **Order Management**: Staff can search for orders, while accountants can add, edit, and update orders.
- **Customer Management**: Staff can search for customers, while accountants can add, edit, and update customer information.
- **Reporting**: Accountants can generate order reports based on specific time periods.

## Project Structure
```
ClothingShopApp
├── DataAccess
│   ├── DatabaseContext.cs
│   ├── Repositories
│   │   ├── CustomerRepository.cs
│   │   ├── OrderRepository.cs
│   │   └── ProductRepository.cs
│   └── Models
│       ├── Customer.cs
│       ├── Order.cs
│       └── Product.cs
├── BusinessLogic
│   ├── Services
│   │   ├── CustomerService.cs
│   │   ├── OrderService.cs
│   │   └── ProductService.cs
│   └── Interfaces
│       ├── ICustomerService.cs
│       ├── IOrderService.cs
│       └── IProductService.cs
├── Presentation
│   ├── Program.cs
│   ├── Menus
│   │   ├── MainMenu.cs
│   │   ├── StaffMenu.cs
│   │   └── AccountantMenu.cs
│   └── Utils
│       ├── InputHelper.cs
│       └── ReportGenerator.cs
├── appsettings.json
├── ClothingShopApp.sln
└── README.md
```

## Setup Instructions
1. **Clone the Repository**: Clone this repository to your local machine.
2. **Install Dependencies**: Ensure you have the necessary dependencies installed, including Entity Framework and MySQL Connector.
3. **Configure Database**: Update the `appsettings.json` file with your MySQL database connection string.
4. **Run Migrations**: Use Entity Framework migrations to create the database schema.
5. **Start the Application**: Run the application using your preferred C# development environment.

## Usage Guidelines
- **Login**: Users must log in to access the application. Staff and accountants will see different menus based on their roles.
- **Navigating Menus**: Follow the prompts in the console to navigate through the various functionalities of the application.
- **Data Management**: Use the provided options to manage products, orders, and customers as per your role.

## Contributing
Contributions are welcome! Please submit a pull request or open an issue for any enhancements or bug fixes.

## License
This project is licensed under the MIT License. See the LICENSE file for more details.