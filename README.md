# Animal Adoption System API

A RESTful Web API built with ASP.NET Core for managing animal adoption processes.  
The system allows users to browse animals, submit adoption requests, and enables administrators to manage animals and review adoption requests.

------------------------------------------------------------------------------------------------------------------------------------------------------------

## Features

### User Features
- User Registration and Login
- JWT Authentication
- Browse Available Animals
- Search, Filter, Sort, and Pagination
- View Animal Details
- Submit Adoption Requests
- View Personal Adoption Requests

### Admin Features
- Add New Animals
- Update Existing Animals
- Delete Animals
- Accept or Reject Adoption Requests
- View All Adoption Requests

------------------------------------------------------------------------------------------------------------------------------------------------------------

##  Technologies Used

- ASP.NET Core Web API
- C#
- Entity Framework Core
- SQL Server
- ASP.NET Identity
- JWT Authentication
- AutoMapper
- Repository Pattern
- Generic Repository Pattern
- Specification Pattern
- Middleware
- DTOs
- Dependency Injection
- LINQ

------------------------------------------------------------------------------------------------------------------------------------------------------------

##  Project Architecture

The project follows a layered architecture:

```text
GraduationProject
│
├── Project.Core
│   ├── Entities
│   ├── Interfaces
│   ├── Specifications
│   └── Enums
│
├── Project.Repository
│   ├── Data
│   ├── Configurations
│   └── Generic Repository
│
├── Project.Services
│   └── Token Service
│
└── GraduationProject
    ├── Controllers
    ├── DTOs
    ├── Middleware
    ├── Extensions
    └── Helpers
```

------------------------------------------------------------------------------------------------------------------------------------------------------------

##  Authentication & Authorization

The system uses:

- ASP.NET Identity
- JWT Tokens
- Role-Based Authorization

Roles:

- User
- Admin

------------------------------------------------------------------------------------------------------------------------------------------------------------

##  API Endpoints

### Account

- Register
- Login
- CreateAdminRole
- MakeAdmin

### Animals

- Get All Animals
- Get Animal By Id
- Get Types
- Get Breeds
- Get Shelters

### Adoption

- Create Adoption Request
- Get My Requests

### Admin

- Get All Requests
- Accept Adoption Request
- Reject Adoption Request
- Add Animal
- Update Animal
- Delete Animal

------------------------------------------------------------------------------------------------------------------------------------------------------------

##  Design Patterns Used

- Repository Pattern
- Generic Repository Pattern
- Specification Pattern
- Dependency Injection

------------------------------------------------------------------------------------------------------------------------------------------------------------

##  Concepts Applied

- Clean Architecture Principles
- DTO Mapping with AutoMapper
- Custom Exception Middleware
- API Validation Responses
- Pagination
- Filtering
- Sorting
- JWT Authentication
- Role-Based Authorization

------------------------------------------------------------------------------------------------------------------------------------------------------------

## Author

**Omar Mohamed**

Backend .NET Developer

- LinkedIn: www.linkedin.com/in/omar-mohamed-404ba5354
- GitHub: https://github.com/omarrmuhamd


