Configuration Manager Singleton
Overview

This project demonstrates the implementation of the Singleton design pattern in C# to create a thread-safe Configuration Manager. The Configuration Manager ensures that only one instance exists throughout the application, providing centralized management of application-wide settings.
Features

    Singleton Pattern: Ensures only one instance of the Configuration Manager is created.
    Thread Safety: Utilizes ConcurrentDictionary to safely manage configuration settings in a multi-threaded environment.
    Configuration Management: Provides methods to add, retrieve, and remove configuration settings.
    API Endpoints: Includes simple API endpoints to interact with the Configuration Manager.

Technology Stack

    .NET Core / ASP.NET Core: Web application framework.
    C#: Programming language used for implementing the Singleton pattern.
    ConcurrentDictionary: Ensures thread-safe access to configuration settings.

Project Structure

├── Controllers
│   └── ConfigurationController.cs
├── Singletons
│   └── ConfigurationManagerSingleton.cs
├── Program.cs
└── README.md

Singleton Implementation

The ConfigurationManagerSingleton class is designed as a thread-safe Singleton, ensuring that only one instance of the configuration manager exists. It uses a private constructor and a static property Instance to control the instantiation. The ConcurrentDictionary<string, object> is used to store and manage configuration settings securely in a multi-threaded environment.
Key Methods

    Get<T>(string key): Retrieves the value associated with the specified key.
    AddSetting(string key, object value): Adds a new key-value pair to the configuration settings.
    RemoveSetting(string key): Removes the key-value pair associated with the specified key.

Example Usage

csharp

var configManager = ConfigurationManagerSingleton.Instance;

// Add a setting
configManager.AddSetting("AppName", "MyApplication");

// Get a setting
var appName = configManager.Get<string>("AppName");

// Remove a setting
configManager.RemoveSetting("AppName");

API Endpoints

The project includes simple API endpoints to interact with the Configuration Manager.

    Add Setting: GET /addy
        Adds a new setting with key "AppName" and value "MyApplication".
    Get Setting: GET /Get
        Retrieves the value of the setting with key "AppName".
    Remove Setting: GET /remove
        Removes the setting with key "AppName".

Running the Application

    Clone the repository.
    Open the project in your IDE.
    Build and run the application.
    Use the provided API endpoints to interact with the Configuration Manager.
