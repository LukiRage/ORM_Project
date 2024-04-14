# ORM Data Service and Frontend

## Description
This repository contains a .NET project for an Object-Relational Mapping (ORM) data service, along with a frontend application built with React. The data service provides functionalities to import, export, and serve data related to air quality, CO2 emissions, GDP growth, and industry growth. The frontend application interacts with the data service to visualize and manipulate the data.

## Backend Key Features
- **Data Import and Export**: Provides methods to import data from JSON and XML files into a database and export data from the database to JSON and XML files.
- **Data Service API**: Implements REST and SOAP APIs for retrieving data based on specified parameters such as year code and country code.
- **Database Models**: Defines entity classes for database tables including AirQuality, CO2Emission, GDPGrowth, IndustryGrowth, Country, and Year.
- **Controller for All Data Retrieval**: Includes a controller (DataAllController) for retrieving all data from the database tables in a single API call.
- **Authentication**: Uses JWT (JSON Web Tokens) for authentication.

## Frontend Key Features
- **User Authentication**: Provides login functionality for users to access their respective panels.
- **Admin Panel**: Allows administrators to import/export data, visualize data using charts, and perform CRUD operations.
- **User Panel**: Enables regular users to visualize data using charts and filter data based on year code and country code.

## Technologies Used

### Backend
- **Language**: C#
- **Frameworks/Libraries**: .NET Core, Entity Framework Core
- **Serialization**: Newtonsoft.Json, System.Xml.Serialization
- **Web API**: ASP.NET Core Web API
- **Database**: MySQL
- **Authentication**: JWT (JSON Web Tokens)

### Frontend
- **Framework**: React
- **State Management**: React Hooks (useState, useEffect)
- **Routing**: React Router
- **HTTP Client**: Axios
- **Charts**: Chart.js
- **Styling**: CSS

## How to Use

### Backend
1. Clone the repository to your local machine.
2. Set up a MySQL database and configure the connection string in the DataContext class.
3. Build and run the project.
4. Use the provided REST and SOAP endpoints to retrieve data from the database.

### Frontend
1. Clone the repository to your local machine.
2. Navigate to the frontend directory.
3. Install dependencies by running `npm install`.
4. Start the frontend application by running `npm start`.
5. Access the application in your web browser.

## Endpoints

### Backend
- **REST API**: `/api/data/{tableName}` - Retrieves data based on table name, year code, and country code.
- **SOAP API**: `/api/data` - Supports SOAP requests for data retrieval.

### Frontend
- **Admin Panel**: Accessible at `/adminpanel` route after login. Allows administrators to import/export data, visualize data using charts, and perform CRUD operations.
- **User Panel**: Accessible at `/userpanel` route after login. Enables regular users to visualize data using charts and filter data based on year code and country code.

## Additional Notes

- Ensure proper authentication and authorization configuration for accessing the APIs.
- Customize database models and controllers as per specific project requirements.
- Feel free to extend the frontend application with additional features or customize the styling as needed.

## The developers that work on this project:

- @RobertNeat
- @LukiRage
- @Kander678
- @Dexos21
