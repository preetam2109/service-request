# 📦 Service Request Manager

A full-stack Service Request Management system designed to efficiently manage IT helpdesk-style tickets. It features a robust **ASP.NET Core Web API** backend and a modern **Angular 15+** frontend with JWT-based authentication and role-secured access.

---

## ✨ Features

### 🔧 Backend – ASP.NET Core Web API
- **RESTful API**: Complete CRUD operations for service requests.
- **Entity Framework Core**: Seamless SQL Server integration for data persistence.
- **JWT Authentication**: Secures all endpoints with token-based auth.
- **Swagger Documentation**: Easily test and explore the API.
- **Robust Architecture**: Includes exception handling and logging.
- **Clean Code Structure**: Follows standard .NET Core design practices.

### 🎨 Frontend – Angular 15+
- **Modern UI**: Built with Angular Material for a sleek, responsive design.
- **Request List View**: With pagination, sorting, and status filtering.
- **Create/Edit Forms**: Fully validated forms for request creation and updates.
- **Detail Pages**: View complete request info with clean layout.
- **Secure Login**: JWT-based authentication with protected routes.
- **API Services**: Centralized services for all backend communication.

---

## 📸 Application Screenshots

Below are screenshots demonstrating key functionality in the Service Request Manager frontend.


### 🔐 Login Page
The login page uses JWT authentication to secure the application.


<img width="1279" alt="login" src="https://github.com/user-attachments/assets/d44c9087-2f02-494c-bb37-97e550ab8f6d" />

---

### ➕ Create a New Service Request  
**POST /api/requests**

This form allows users to create a new service request with validation.


<img width="1280" alt="create-request" src="https://github.com/user-attachments/assets/eaee53da-b4e9-484f-b009-24184c75bcdb" />


---

### 📋 View All Service Requests  
**GET /api/requests**

Displays a paginated and filterable list of all service requests.


<img width="1280" alt="all-requests" src="https://github.com/user-attachments/assets/e8ea40ab-10cc-409c-ba41-a2a637e5803b" />

---

### 🔍 View a Single Request by ID  
**GET /api/requests/{id}**

Shows the full details of a selected service request.
<img width="1280" alt="get-request-by-id" src="https://github.com/user-attachments/assets/aaeacc2d-4f6d-4d54-8d63-a33ed7c79f4b" />



---

### ✏️ Update an Existing Request  
**PUT /api/requests/{id}**

Allows editing of an existing request's data using the same form.

<img width="1280" alt="update-request" src="https://github.com/user-attachments/assets/49f99e72-a838-40b8-8802-f0ff6e48c199" />


---

### ❌ Delete a Service Request  
**DELETE /api/requests/{id}**

Requests can be deleted directly from the list view with confirmation.

<img width="1280" alt="delete-request" src="https://github.com/user-attachments/assets/2004ea8b-b741-4ece-a7d6-5757e98d8174" />



## 🛠️ Technologies Used

### Backend
- [.NET Core (SDK 6.0+)](https://dotnet.microsoft.com/en-us/)
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- JWT (JSON Web Tokens)
- Swagger / Swashbuckle

### Frontend
- [Angular 15+](https://angular.io/)
- Standalone Components
- Angular Material
- TypeScript
- HTML5 & CSS3

---

## 🚀 Deployment Details

This full-stack Service Request Manager application is deployed as follows:

### 🧩 Architecture Overview

| Layer      | Technology       | Hosting Platform |
|------------|------------------|------------------|
| Frontend   | Angular 15+      | [Netlify](https://www.netlify.com/) |
| Backend    | ASP.NET Core Web API | [Render](https://render.com/) |
| Database   | SQL Server       | [Somee](https://somee.com/) |
| API Testing| Postman / Local |


## 🔗 UI Source Code

For the Angular frontend source code, please refer to the **[Frontend Repository](https://github.com/preetam2109/service-request-app)**.






