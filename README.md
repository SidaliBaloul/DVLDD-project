To Login : 
UserName : user5
Password = popo

This is a Windows Forms application in C# built as learning project while i study programming fundamentals ,
the project is DVLD (Driving and Vehicle Licensing Departement )


📘 Overview

The DVLD project uses ADO.NET within the Data Access Layer (DAL) to handle all communication with the SQL Server database. This includes executing queries, managing connections, and performing CRUD operations in a structured and efficient way.

The DVLD (Driver & Vehicle Licensing Department) project is a structured C# application designed to simulate or manage DVLD-related operations such as:

Managing driver records

Issuing licenses

Handling renewals and replacements

The project follows a Three-Tier Architecture, ensuring clean separation of concerns, maintainability, and scalability.

🏛 Architecture Structure

The system is developed using the 3-tier architecture pattern:

1️⃣ Presentation Layer (UI Layer)

Contains all UI forms, controls, and event handlers

Handles user interaction

Displays data received from the Business Layer

Does NOT contain business logic or database code

2️⃣ Business Layer (BL)

Contains all business rules and application logic

Validates input and coordinates data flow

Acts as a middle layer between UI and Data

Ensures clean, reusable logic

3️⃣ Data Access Layer (DAL)

Handles all database operations

Contains CRUD methods (Insert, Update, Delete, Select)

Communicates with SQL Server

Returns clean data objects to the BL


✨ Features

✔ 3-tier clean architecture
✔ SQL database support
✔ Reusable business logic
✔ Modular and scalable code base
✔ Easy to maintain and extend
✔ Proper separation of concerns
✔ Form-based UI 

Common DVLD operations include:

Driver registration & management

License issuance and renewal

License replacement (lost/damaged)

Local & international license handling

Violations and payments 


🛠 Technologies Used
Component	Technology
Language	C#
Framework	.NET Framework
UI	Windows Forms
Database	SQL Server
Architecture	Three-Tier (UI → BL → DAL)
DataAccess ADO.net 
