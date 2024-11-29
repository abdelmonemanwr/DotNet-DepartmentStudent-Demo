# Department-Student Demo

A modern and well-structured .NET application demonstrating the implementation of CRUD operations for managing **Departments** and **Students**. This project follows best practices in software development, including a layered architecture, reusable patterns, and efficient database interaction.

---

## ✨ Features
- **CRUD Operations**: Perform Create, Read, Update, and Delete operations for departments and students.
- **Layered Architecture**: Separation of concerns with Controllers, Services, Repositories, and DTOs.
- **Entity Framework Core**: Simplified database access with migrations and a code-first approach.
- **AutoMapper Integration**: Streamlined object mapping between Models and DTOs.
- **Generic Repository Pattern**: Centralized and reusable repository logic for database interactions.
- **Unit of Work Pattern**: Ensures consistency by managing multiple repositories as a single transaction.
- **Extensible Design**: Easily scalable for additional features and entities.

---

## 📋 API Endpoints

### Departments
- **GET** `/api/Departments`: Retrieve all departments.
- **GET** `/api/Departments/{id}`: Retrieve a single department by ID.
- **POST** `/api/Departments`: Add a new department.
- **PUT** `/api/Departments/{id}`: Update an existing department.
- **DELETE** `/api/Departments/{id}`: Delete a department by ID.

### Students
- **GET** `/api/Students`: Retrieve all students.
- **GET** `/api/Students/{id}`: Retrieve a single student by ID.
- **POST** `/api/Students`: Add a new student.
- **PUT** `/api/Students/{id}`: Update an existing student.
- **DELETE** `/api/Students/{id}`: Delete a student by ID.

---

## 🚀 Getting Started

### 1️⃣ Clone the Repository
```bash
git clone https://github.com/your-username/DotNet-DepartmentStudent-Demo.git
cd DotNet-DepartmentStudent-Demo
```

### 2️⃣ Set Up the Database
#### 1. Update the appsettings.json file with your SQL Server connection string
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=your_server;Database=your_db;Trusted_Connection=True;"
  }
}
```

#### 2. Apply migrations to create the database schema:
```bash
dotnet ef database update
```

### 3️⃣ Run the Application
#### Start the application with:
```bash
dotnet run
```

#### By default, the API will be accessible at:

> HTTP:  ```link http://localhost:5000 ```
> HTTPS: ```link https://localhost:5001```
