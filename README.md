# GoBosniaApi

Welcome to the GoBosniaApi GitHub repository. This API allows you to interact with the GoBosnia web tourist application, providing endpoints for managing and retrieving tourist-related data.

## Table of Contents

- [About GoBosnia Web App](#about-gobosnia-web-app)
  - [Key Features](#key-features)
- [Introduction](#introduction)
- [Features](#features)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
  - [Running the Application](#running-the-application)
- [Configuration](#configuration)
- [Contributing](#contributing)
- [Technologies](#technologies)
- [Contact](#contact)

## About GoBosnia Web App

GoBosnia is a web application designed to help tourists explore the best spots in Bosnia and Herzegovina. The application is user-friendly and does not require registration, making it a convenient tool for visitors to quickly access a variety of tourist-related content.

### Key Features

- **Comprehensive Tourist Information**: Easily access detailed information about accommodations, activities, attractions, restaurants and posts about interesting topics regarding Bosnia and Herzegovina's history and geography.
- **Leave Reviews**: You as a tourist can leave reviews on specific tourist content without the need to log in. All reviews are subject to approval by an administrator to ensure quality and relevance.
- **AI-Powered Trip Planner**: Utilize the Trip Planner feature, which uses AI to generate the most ideal set of activities based on your input parameters, providing a personalized travel experience.

GoBosnia aims to enhance the travel experience by offering a centralized platform for tourists to discover, plan, and review their trips in Bosnia and Herzegovina.

You can check the frontend repository [here](https://github.com/jasarevicedis/goBosnia).

## Introduction

This API serves as a backend for the GoBosnia web app. It also provides access to the application's features, enabling developers to build custom integrations or mobile applications.

## Features

- Admin authentification and authorization (soon)
- CRUD operations on tourist contents (accommodations, attractions, activities, food and drinks (restaurants and cafes), posts) 
- Adding and approving reviews on tourist contents
- Getting the AI generated planning of the tourist trips (soon)
- Error handling with clear status codes

## Getting Started

### Prerequisites

Before you begin, ensure you have the following installed:

- [.NET 6.0 SDK or later](https://dotnet.microsoft.com/download/dotnet/6.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- A code editor (e.g., Visual Studio, Visual Studio Code)
- [Git](https://git-scm.com/)

### Installation

1. Clone the repository:

    ```bash
    git clone https://github.com/aljubuncic/GoBosniaApi.git
    ```

2. Navigate to the project directory:

    ```bash
    cd GoBosniaApi
    ```

3. Restore dependencies:

    ```bash
    dotnet restore
    ```

4. Build the project:

    ```bash
    dotnet build
    ```

### Running the Application

1. Update the database connection string and other settings in `appsettings.json`, or by adding a user secret like mentioned in the [Configuration](#configuration) part.
2. Apply the latest migration to the database:
  
    ```bash
    dotnet ef database update
    ```

3. Run the application:

    ```bash
    dotnet run
    ```
    
    If you want to populate the database with some example data, run this command:

    ```bash
    dotnet run seed-data
    ```
   

5. Viewing the API

   Server is now hosted on https://localhost:7142

   You can check the swagger documentation of the API on the following url: https://localhost:7142/swagger/index.html

## Configuration

Configure your application settings in `appsettings.json`. Here is a sample configuration:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=your_server;Database=your_db_name;User Id=your_user;Password=your_password;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }
}
```

If you want to avoid entering database connection data in `appsettings.json`, you can also add a user secret by running this command in the terminal from the project directory:

```bash
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=your_server;Database=your_db_name;User Id=your_user;Password=your_password;"
```

## Contributing

Contributions to GoTravnikApi are welcome! If you'd like to contribute, please follow these steps:

1. Fork the repository.
2. Create a new branch: `git checkout -b feature/my-feature`
3. Make your changes.
4. Commit your changes: `git commit -am 'Add new feature'`
5. Push to the branch: `git push origin feature/my-feature`
6. Submit a pull request.

## Technologies

- ASP .NET Core 
- SQL Server

## Contact

For any inquiries or feedback, please contact us:
- [Ahmed Ljubunčić](https://github.com/aljubuncic)
- [Edis Jašarević](https://github.com/jasarevicedis)
