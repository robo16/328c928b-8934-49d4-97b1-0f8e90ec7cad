# Longest Increasing Subsequence (LIS) Calculator API

## Solution Overview

This project is a C# Minimal API that calculates the Longest Increasing Subsequence (LIS) from a given space-separated string of integers. It is built using ASP.NET Core and provides an endpoint to compute the LIS while handling input validations. The solution also includes comprehensive unit tests to ensure the functionality and robustness of the API.

### Features

- Input validation and parsing.
- Efficient LIS calculation using optimized algorithms.
- Global exception handling with structured error responses.
- Integrated Swagger UI for easy API exploration and testing.
- Docker support for consistent environment deployment.
- Code coverage integration using Coverlet.

## Prerequisites

Before running the solution locally, ensure you have the following installed:

- [.NET SDK 6.0 or later](https://dotnet.microsoft.com/download)
- [Docker Desktop](https://www.docker.com/get-started)

## Getting Started

### Running the Solution Locally

1. **Clone the repository**:

    ```bash
    git clone https://github.com/robo16/328c928b-8934-49d4-97b1-0f8e90ec7cad.git
    cd LISMinimalApi
    ```

2. **Run the API Locally**:

   Use the command below to run the API in your local development environment:

    ```bash
    dotnet run --project LISMinimalApi/LISMinimalApi.csproj
    ```

3. **Access API**:

   Open your web browser and navigate to [http://localhost:5000/](http://localhost:5000/) to access the Swagger UI.

### Running the Docker Container

To run the API in a Docker container, follow these steps:

1. **Build the Docker Image**:

   In the project directory, run the following command:

   ```bash
   docker build -t lisminimalapi .
   ```

2. **Run the Docker Container**:

   Use the command below to run the container:

   ```bash
   docker run -d -p 5000:80 --name lisminimalapi_container lisminimalapi
   ```

3. **Access Swagger UI**:

   Open your web browser and navigate to [http://localhost:5000/](http://localhost:5000/) to explore the API and view the documentation.

4. **Stopping and Removing the Container**:

   To stop the running container:

   ```bash
   docker stop lisminimalapi_container
   ```

   To remove the container:

   ```bash
   docker rm lisminimalapi_container
   ```

## Running Tests

To ensure that the application functions as expected, you can run unit tests that cover the core functionalities:

1. **Navigate to the Test Project**:

   Go to the directory where your test project is located (typically in the test folder of your solution).

    ```bash
    cd LISMinimalApi.Tests
    ```

2. **Run the Tests**:

   Use the following command to execute the tests and collect code coverage:

   ```bash
   dotnet test --collect:"XPlat Code Coverage"
   ```

3. **Generate HTML Report (Optional)**:

   If you want to see a detailed HTML report of the code coverage, install ReportGenerator globally using:

   ```bash
   dotnet tool install -g dotnet-reportgenerator-globaltool
   ```

   Then run:

   ```bash
   reportgenerator -reports:TestResults/**/*.cobertura.xml -targetdir:coverage-report -reporttypes:Html
   ```

   Open `index.html` in the `coverage-report` directory to view the coverage results in your web browser.