# InvoiceManager
Invoice manager consist with add invoice and update invoice endpoints

This project is a .NET Core application that uses Azure Cosmos DB to save invoice and invoice item information. It follows a layered architecture pattern that separates concerns between different parts of the application.

The project has the following layers:

Web API layer: This layer is responsible for receiving HTTP requests and returning HTTP responses. It uses the Service layer to process requests.
Service layer: This layer is responsible for processing requests received from the Web API layer. It uses the Repository layer to interact with the data store.
Repository layer: This layer is responsible for interacting with the data store. It uses the DTO layer to transfer data between layers.

The project uses the following NuGet packages:

Microsoft.Azure.Cosmos for interacting with Azure Cosmos DB
Newtonsoft.Json for JSON serialization and deserialization
Moq for mocking dependencies in unit tests

Getting Started
To get started with the project, follow these steps:

Clone the repository.
Install .NET Core if you haven't already.
Install the required NuGet packages by running dotnet restore in the project directory.
Add your Azure Cosmos DB account credentials to appsettings.json.
Run the application by running dotnet run in the project directory.
Use an HTTP client to send requests to the Web API endpoints.

API Endpoints
The Web API layer exposes the following endpoints:

POST /api/Invoice/Add
Creates a new invoice in the data store.

Request body:

json
{
  "id": "ddd",
  "date": "2023-02-14T06:34:38.279Z",
  "description": "string",
  "totalAmount": 0,
  "invoiceItems": [
    {
      "amount": 0,
      "quantity": 0,
      "unitPrice": 0,
      "totalAmount": 0
    }
  ]
}
Response body:
{
    "isError": false,
    "message": "Sucessfully added invoice, invoice id : 1123"
}

PUT /api/Invoice/Update
Updates an existing invoice in the data store.

Request body:

json
{
  "id": "1123",
  "date": "2023-02-14T06:34:38.279Z",
  "description": "abcdf",
  "totalAmount": 0,
  "invoiceItems": [
    {
      "amount": 0,
      "quantity": 0,
      "unitPrice": 0,
      "totalAmount": 0
    }
  ]
}
Response body:

{
    "isError": false,
    "message": "Sucessfully updated invoice, invoice id : 1123"
} 

Please note that to add configurations of the azure dosmosdb in appsetting
![image](https://user-images.githubusercontent.com/60961883/234159627-e5fbbace-1941-4efd-8537-17c70cf7254a.png)

Unit Tests
The project includes unit tests for the Repository layer using Moq. To run the tests, run dotnet test in the project directory.

Further more improvements

* we can use Authentification for security
* can use logging mechanisum

