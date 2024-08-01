Overview
This project is a Garage Management System developed using C#. It manages vehicles in a garage, allowing for efficient handling and organization of vehicles and related tasks.
The project implements the Factory Design Pattern and is designed with a clear separation between the business logic layer and the user interface (UI) layer.

Features
Vehicle Management: Add, update, and remove vehicles from the system.
Service Tracking: Manage and track services and repairs for each vehicle.
Customer Management: Maintain customer information and their associated vehicles.
Report Generation: Generate reports on vehicle statuses and services performed.
Architecture

The project is structured into two main layers:

Business Logic Layer (BLL):

Handles all the core logic and operations of the application.
Contains classes and methods for managing vehicles, customers, and services.
Implements the Factory Design Pattern to create instances of different vehicle types.
User Interface (UI) Layer:

Provides a graphical interface for users to interact with the system.
Communicates with the Business Logic Layer to perform operations and display data.
Technologies
Language: C#
Design Pattern: Factory Design Pattern
