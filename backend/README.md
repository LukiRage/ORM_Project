# ORM_Data_Service
## Description:
This repository contains a .NET project for an Object-Relational Mapping (ORM) data service. It provides functionalities to import, export, and serve data related to air quality, CO2 emissions, GDP growth, and industry growth. The project includes components for handling data serialization to JSON and XML formats, as well as REST and SOAP APIs for data retrieval.

## Key Features:

Data Import and Export: Provides methods to import data from JSON and XML files into a database and export data from the database to JSON and XML files.
Data Service API: Implements REST and SOAP APIs for retrieving data based on specified parameters such as year code and country code.
Database Models: Defines entity classes for database tables including AirQuality, CO2Emission, GDPGrowth, IndustryGrowth, Country, and Year.
Controller for All Data Retrieval: Includes a controller (DataAllController) for retrieving all data from the database tables in a single API call.

## Technologies Used:

Language: C#</br>
Frameworks/Libraries: .NET Core, Entity Framework Core</br>
Serialization: Newtonsoft.Json, System.Xml.Serialization</br>
Web API: ASP.NET Core Web API</br>
Database: MySQL</br>
Authentication: JWT (JSON Web Tokens)

## How to Use:

Clone the repository to your local machine.
Set up a MySQL database and configure the connection string in the DataContext class.
Build and run the project.
Use the provided REST and SOAP endpoints to retrieve data from the database.
## Endpoints:

REST API: /api/data/{tableName} - Retrieves data based on table name, year code, and country code.</br>
SOAP API: /api/data - Supports SOAP requests for data retrieval.
## Additional Notes:

Ensure proper authentication and authorization configuration for accessing the APIs.
Customize database models and controllers as per specific project requirements.
