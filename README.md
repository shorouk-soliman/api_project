# API Project

This project is an e-commerce application that allows users to manage their shopping cart and place orders. It includes functionalities for adding items to the cart, updating item quantities, creating orders based on cart items, and managing products, categories, and users.

## Features

- User authentication and authorization
- Manage products and categories
- Add items to the cart
- Edit item quantities in the cart
- Remove items from the cart
- Place orders based on cart contents
- View order history

## Technologies Used

- **Backend:** ASP.NET Core
- **Database:** SQL Server
- **ORM:** Entity Framework Core
- **API Documentation:** Swagger

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### Installation

1. **Clone the repository:**
   ```bash
   git clone https://github.com/shorouk-soliman/api_project.git
   cd api_project
2.  Restore NuGet packages:
dotnet restore
3.  Update the appsettings.json file with your SQL Server connection string.

Apply migrations to set up the database:
dotnet ef database update
4. 
Here's a comprehensive README file for the GitHub repository at https://github.com/shorouk-soliman/api_project/tree/master:

markdown
Copy code
# API Project

This project is an e-commerce application that allows users to manage their shopping cart and place orders. It includes functionalities for adding items to the cart, updating item quantities, creating orders based on cart items, and managing products, categories, and users.

## Features

- User authentication and authorization
- Manage products and categories
- Add items to the cart
- Edit item quantities in the cart
- Remove items from the cart
- Place orders based on cart contents
- View order history

## Technologies Used

- Backend: ASP.NET Core
- Database: SQL Server
- ORM: Entity Framework Core
- API Documentation: Swagger

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server)

### Installation

1. **Clone the repository:**
   ```bash
   git clone https://github.com/shorouk-soliman/api_project.git
   cd api_project
Backend Setup:

Navigate to the backend project directory:

bash
Copy code
cd commerce.Api
Restore NuGet packages:

bash
Copy code
dotnet restore
Update the appsettings.json file with your SQL Server connection string.

Apply migrations to set up the database:

bash
Copy code
dotnet ef database update
Run the backend server:
dotnet run


API Documentation
The API documentation is available via Swagger. Once the backend server is running, navigate to http://localhost:5000/swagger.

Contributing
Fork the repository.
Create a new branch (git checkout -b feature/YourFeature).
Commit your changes (git commit -m 'Add some feature').
Push to the branch (git push origin feature/YourFeature).
Open a pull request.
Contact
Name: Shorouk Soliman
Email: shorooukabdelhamied4@gmail.com
GitHub: https://github.com/shorouk-soliman
