# 🎫 IT Support Ticket System (ASP.NET Core MVC)

A role-based **IT Support Ticket Management System** built using **ASP.NET Core MVC**, **Entity Framework Core**, and **SQLite**.  
This project simulates a real-world IT support workflow with **Support**, **Technician**, and **Admin** roles.

---

## 🚀 Features

### 🔐 Role-Based Access
- **Support**
  - Create tickets
  - View own tickets only

- **Technician**
  - View assigned tickets
  - Update ticket status
  - Add resolution notes
  - Close tickets

- **Admin**
  - View all tickets
  - Assign tickets to technicians
  - Manage ticket workflow

---

### 🎫 Ticket Lifecycle
- Create → Open
- Assign → In Progress
- Resolve → Closed
- Automatic tracking of:
  - Created Date
  - Assigned Date
  - Updated Date
  - Closed Date

---

### 🧩 Modules Implemented
- User Authentication (Session-based)
- Ticket Categories
- Ticket Priorities
- Ticket Management (Create, Assign, Update)
- Role-based Dashboard
- Clean UI using Bootstrap

---

## 🛠️ Tech Stack

- **Backend:** ASP.NET Core MVC (.NET)
- **ORM:** Entity Framework Core
- **Database:** SQLite
- **Frontend:** Razor Views + Bootstrap
- **Authentication:** Session-based (Custom)

---

## 📂 Project Structure

ITSupport/
│
├── Controllers/
│ ├── AccountController.cs
│ ├── HomeController.cs
│ ├── TicketsController.cs
│ └── TicketCategoriesController.cs
│
├── Models/
│ ├── Ticket.cs
│ ├── TicketCategory.cs
│ ├── TicketPriority.cs
│ └── TicketAttachment.cs
│
├── Data/
│ └── ApplicationDbContext.cs
│
├── Views/
│ ├── Home/
│ ├── Tickets/
│ ├── TicketCategories/
│ └── Shared/
│
├── Migrations/
├── wwwroot/
├── appsettings.json
└── Program.cs




---

## ⚙️ Prerequisites

Make sure you have the following installed:

- .NET SDK (latest stable)
- Git
- Visual Studio / VS Code / GitHub Codespaces

---

## ▶️ How to Run the Project

### 1️⃣ Clone the Repository
```bash
git clone https://github.com/your-username/ITSupportTicketSystem.git
cd ITSupportTicketSystem

dotnet restore
dotnet ef database update
dotnet run



👤 Default Roles (Example)

You can create users directly from the database or seed manually:

Admin

Support

Technician

Only Support users can create tickets.

🔐 Security & Design Notes

Role-based authorization enforced at controller + UI level

System-controlled fields are never editable by users

Ticket lifecycle strictly managed by backend logic

Designed to be easily extendable (attachments, history, SLA)

📈 Future Enhancements

File attachments (upload & download)

Ticket history / timeline

Work Type & Environment master data

Email notifications

SLA tracking

ASP.NET Identity authentication

📄 License

This project is created for learning, college projects, and demonstrations.
You are free to modify and extend it.

🙌 Author

Rathod Sahil
ASP.NET Core Developer
GitHub: developershahil

⭐ If you find this project useful, give it a star!






