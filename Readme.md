# TransitOps - Smart Transport Operations Platform

TransitOps is a centralized platform designed to digitize and optimize transport operations, including vehicle management, driver profiles, and trip lifecycles. This project was developed as part of a hackathon to provide operational visibility and efficiency for logistics companies[cite: 1].

## 🏗️ Architecture: N-Tier Design
TransitOps follows a robust **N-tier architecture** to ensure clear separation of concerns, scalability, and maintainability[cite: 1]. The data flow is structured as follows:

* **Presentation Layer (UI)**: Uses **ViewModels** to handle user input, validation, and data presentation, ensuring the UI remains decoupled from the database structure[cite: 1].
* **Service Layer**: Acts as the business logic orchestrator, utilizing **DTOs (Data Transfer Objects)** to safely transfer data between the presentation and data layers without exposing database entities directly[cite: 1].
* **Repository Layer**: Manages the **Entities**, which represent the direct database schema and map to your SQL tables using Entity Framework Core[cite: 1].
* **Data Mapping**: Employs **AutoMapper** to seamlessly transform data between ViewModels, DTOs, and Entities[cite: 1].

## 🚀 Key Implemented Features
* **Vehicle Registry**: Complete CRUD functionality to manage fleet assets, including tracking Registration Numbers, Capacity, Acquisition Cost, and Odometer readings[cite: 1].
* **Driver Management**: System to manage driver profiles, including license details, expiry dates, and status tracking (Available, On Trip, Off Duty, Suspended)[cite: 1].
* **Automated Logic**:
    * Enforced validation for unique Vehicle Registration Numbers[cite: 1].
    * Implemented type-safe mappings between `DateTime` and `DateOnly` types to ensure seamless data handling[cite: 1].

## 🛠 Tech Stack
* **Framework**: .NET Core MVC
* **Architecture**: N-Tier (Presentation, Service, Repository, Data)
* **Data Access**: Entity Framework Core
* **Mapping**: AutoMapper
* **Database**: SQL Server

## 📋 Project Status
- [x] Project Setup & Git Initialization
- [x] Database Schema Design (Users, Vehicles, Drivers)
- [x] Vehicle Registry CRUD
- [x] Driver Management CRUD
- [x] AutoMapper Configuration & Business Logic Layer
- [ ] Trip Management & Lifecycle Workflows
- [ ] Fuel & Expense Tracking
- [ ] Dashboard & KPI Reporting