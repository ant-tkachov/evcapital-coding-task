# E&V Capital Coding Task

## Installation

To run the API from the command line:

1. Clone the repository: `git clone https://github.com/ant-tkachov/evcapital-coding-task.git`
2. Open `Developer Command Prompt for VS 2017` and navigate to the folder where the `EVCapital.CodingTask.sln` is located
3. Run: `dotnet restore`
4. Run: `dotnet run --project EVCapital.CodingTask.Api`
5. Open a browser, copy and paste URL: [http://localhost:5000/swagger](http://localhost:5000/swagger)

To run the UI from the command line:

1. Navigate to EVCapital.CodingTask.Web
2. Run `npm install`
3. Run `ng serve --port 4444`
4. Open `http://localhost:4444`

## Testing

### Run unit tests from the command line

To run the tests from the command line:
1. Open `Developer Command Prompt for VS 2017` and navigate to the folder where the `EVCapital.CodingTask.sln` is located
2. Run: `dotnet restore`
3. Run: `dotnet test EVCapital.CodingTask.BusinessLayer.Tests`

## Solution Structure

The provided solution contains the following projects.

Backend:
* EVCapital.CodingTask.Api
* EVCapital.CodingTask.BusinessLayer.Tests
* EVCapital.CodingTask.BusinessLayer
* EVCapital.CodingTask.Core
* EVCapital.CodingTask.DataLayer

Frontend:
* EVCapital.CodingTask.Web
