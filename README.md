# 📚 Library Management System (LibraryApp)

It is a modern Full-Stack web application designed for comprehensive management of library resources.

## 📋 Project Description

The application enables administrators and library staff to manage the book collection, authors, genres, and the book lending process. The system features a modern, responsive user interface and a fully functional authentication system with role separation.

## 🚀 Implemented Features

### 🔹 Main Modules

- **Dashboard:** Central start panel with quick access to key sections.
- **Books:** Full CRUD support – adding, editing, deleting, and browsing books.
- **Search:** Ability to filter books by title.
- **Loans:** System for registering loans and returns (available for users).
- **Authors and Genres:** Management of library metadata (Administrator only).

### 🔹 Security & UI

- **Authentication:** Login and registration system (ASP.NET Core Identity) with modern Split-Screen Design.
- **Modern Interface:** Utilizes **Bootstrap 5**, **Bootstrap Icons**, and custom styles (gradients, cards, shadows).
- **Responsiveness:** Application adapted for mobile and desktop devices.
- **Validation:** Protection of forms against invalid data.

## 🔑 Access Credentials & Permissions

The application implements a role and security policy system (`AdminOnly`):

1.  **Administrator (`admin@test.com`):** Full access to edit, delete, and add (Books, Authors, Genres, Loans).
2.  **Logged-in User:** Access to the Loans module - ability to borrow books. No access to edit library resources.
3.  **Guest (Not logged in):** Read-only access (viewing the book list and details).

**Administrator Account:**

- **Email:** `admin@test.com`
- **Password:** `Admin123!`

_(Registering a new account creates a user with standard permissions who cannot edit the book database)._

## ⚙️ Configuration & API

- **Database:** The project uses **SQLite** (`library.db`). The connection string is located in the `appsettings.json` file.
- **API Endpoint:** As per requirements, the project exposes an API endpoint (CRUD) for the main entity (Books), returning data in JSON format:
  - Address: `/api/Api` (e.g., `http://localhost:5000/api/Api`)

## 🛠 Technologies

- **Backend:** .NET 8.0 (ASP.NET Core MVC)
- **Database:** SQLite (Entity Framework Core)
- **Frontend:** Razor Views, Bootstrap 5, CSS3
- **Tools:** Visual Studio Code, Git

## 💻 How to Run the Project

1.  **Clone the repository:**
    ```bash
    git clone [https://github.com/Nurpacqiao/LibrarySystem.git](https://github.com/Nurpacqiao/LibrarySystem.git)
    ```
2.  **Navigate to the project folder:**
    ```bash
    cd LibrarySystem
    ```
3.  **Restore the database (Required after cloning):**
    ```bash
    dotnet ef database update
    ```
4.  **Run the application:**
    ```bash
    dotnet watch run
    ```
5.  Open the browser at: `http://localhost:5000`

---

&copy; 2026 LibraryApp
