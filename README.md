# InvoiceManager

Invoice manager consists of add invoice and update invoice endpoints. This project is a .NET Core application that uses Azure Cosmos DB to save invoice and invoice item information. It follows a layered architecture pattern that separates concerns between different parts of the application.

The project has the following layers:

Web API layer: This layer is responsible for receiving HTTP requests and returning HTTP responses. It uses the Service layer to process requests.
Service layer: This layer is responsible for processing requests received from the Web API layer. It uses the Repository layer to interact with the data store.
Repository layer: This layer is responsible for interacting with the data store. It uses the DTO layer to transfer data between layers.

The project uses the following NuGet packages:

- Microsoft.Azure.Cosmos for interacting with Azure Cosmos DB
- Newtonsoft.Json for JSON serialization and deserialization
- Moq for mocking dependencies in unit tests

## Getting Started

To get started with the project, follow these steps:

1. Clone the repository.
2. Install .NET Core if you haven't already.
3. Install the required NuGet packages by running `dotnet restore` in the project directory.
4. Add your Azure Cosmos DB account credentials to `appsettings.json`.
5. Run the application by running `dotnet run` in the project directory.
6. Use an HTTP client to send requests to the Web API endpoints.

## API Endpoints

The Web API layer exposes the following endpoints:

- POST `/api/Invoice/Add`: Creates a new invoice in the data store.

    Request body:

    ```json
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
    ```

    Response body:

    ```json
    {
        "isError": false,
        "message": "Sucessfully added invoice, invoice id : 1123"
    }
    ```

- PUT `/api/Invoice/Update`: Updates an existing invoice in the data store.

    Request body:

    ```json
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
    ```

    Response body:

    ```json
    {
        "isError": false,
        "message": "Sucessfully updated invoice, invoice id : 1123"
    }
    ```

Please note that the configurations of the Azure Cosmos DB are to be added in the `appsettings.json`.
![image](https://user-images.githubusercontent.com/60961883/234160625-1ac75518-e6bf-4972-b071-822f42964481.png)

## Unit Tests

The project includes unit tests for the Repository layer using Moq. To run the tests, run `dotnet test` in the project directory.

## Further Improvements

- We can use authentication for security.
- We can use logging mechanisms.
