# CarShop: Car Rental Management System 🚗

CarShop is a simple to use car rental management system built with **ASP.NET Core MVC**. It provides an intuitive interface for users to browse, rent, and view cars details, while administrators and managers can oversee rental operations, and handle damage reports.

---

## Features 🌟

### For Customers:
- **Browse Cars**: Explore a wide range of cars.
- **Search & Filter**: Find cars by make, or price range.
- **Rent Cars**: Easily rent cars by selecting rental periods.
- **Submit Feedback**: Share feedback and ratings for rented cars.

### For Managers & Administrators only:
- **Car Management**: Add, edit, and delete cars in the inventory.
- **Damage Reports**: Log and review damage reports for rented cars.
  
### For Administrators only:
- **User Management**: Add and remove roles from users and delete user accounts.

---

## 🛠️ Technologies Used

### Backend
- **ASP.NET Core**: Robust and scalable web framework.
- **Entity Framework 8**: Efficient database interactions with LINQ and more.
- **AutoMapper**: Simplifying object-to-object mapping.
- **Authentication**: Identity Framework with role-based access control (Admin, Manager, Customer)

### Frontend
- **Bootstrap 5**: Responsive and modern UI components.
- **Razor Pages**: Simple, efficient and straightforward for developing pages.
- **Font Awesome**: Font Awesome for icons.

### Testing
- **NUnit**: Comprehensive testing framework.
- **Moq**: Mocking framework for unit testing.
- **MockQueryable**: Simplifying LINQ mocking for Entity Framework queries.
- **Fine Code Coverage**: Awesome tool for visualizing unit test code coverage.

---

## Installation & Setup 🖥️

### Prerequisites:
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Visual Studio](https://visualstudio.microsoft.com/)
- Version of visual studio **Needs** to be at least 17.7 to be able to support .NET 8.0

### Steps to Run Locally:
1. Clone the repository:
   ```bash
   git clone https://github.com/Dragomir-Georgiev/ProjectDefence_CarShop_Dec2024.git
   ```

2. Configure the Database:
- Open the appsettings.json file in the project.
- Update the DefaultConnection string with your SQL Server instance details

3. Run Database Migrations:
- At the top center of the project, Select/Make the CarShop.Web as your default startup project.
- Open the package manager console in visual studio.
- Select Data\CarShop.Data as the default project for the package manager console.
- Write and execute:
   ```bash
   Update-Database
   ```
- Reinstall the following nuget packages if you having trouble updating the database:
  ```bash
  Microsoft.EntityFrameworkCore.SqlServer Version="8.0.10"
  Microsoft.EntityFrameworkCore.Tools Version="8.0.10"
  ```
4. Run the application:
- While the project is open is visual studio, press CTRL + F5.

6. Open your browser and navigate to:
   ```
   http://localhost:7279
   ```
   If your default port is different. Make sure to change it in the https profile in CarShop.Web\Properties\launchSettings.json

---

Enjoy Exploring the CarShop Project! 🚗✨
