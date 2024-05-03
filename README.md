# Project Name
 EDT Library System
## Description
 EDT Library Systemis a Web API that  manage a small book library.

## Features
This is a small library system where you would be able to perform ADD, Update, Delete, Get All books, Find Books based on ID.

## Getting Started

### Prerequisites
- .NET Core 3.1 or later
- Any other dependencies your project has

### Installation
1. Clone the repository: `https://github.com/BalajiRajaraman78/EDTLBS.git`
2. Navigate to the project directory: `cd EDTLBS.git`
3. Install the dependencies: `dotnet restore`

### Usage
1. Run the project: `dotnet run`
2. The API will be available at `https://localhost:7246`

## API Endpoints
- /swagger/v1/swagger.json
- `GET /api/BookLibrary`: This is a Get API. Fetching all the books. 
- `GET /api/BookLibrary/{id}`: This is a Get API. Fetching Book based on BookID. 
- `POST /api/BookLibrary`: This is a Post API. 
- Sample-Input Post body Json Format
- {
  "id": 6,
  "title": "title-6",
  "author": "author-6",
  "pages": 600
}
-`Put /api/BookLibrary/{id}`: This is a Put API. 
- Pass an existing BookID to Update
- Sample-Input Post body Json Format
- {
  "id": 1,
  "title": "title-1 - Updated",
  "author": "author-1 - Updated",
  "pages": 100
}
- Add as many endpoints as your API has

-`Delete /api/BookLibrary/{id}`: This is a Delete API. 
	Pass an existing Book ID to delete the book.

## Project Structure
The Solution is divided into the following Project Based on future extension 

##  EDTLBS(Main Project)
	--BookLibraryController
 
##  EDTLBS.Common (Any Common method and Models, Enum will be in the project)
	The models(E.g: Book class)
	--Book.cs
 
## EDTLBS.Services (Service layer Web API Controller calls the Iservices in the constructor leave the implementation to services)
	--The implementation is loosely coupled and passed via dependency injection
	--IBookServices.cs
	--BookServices.cs (Implements the interface currently performs the CRUD operations )	
 
##  EDTLBS.Repository (Repository layer - Service laye calls the IRepository in the constructor leave the implementation to Repository)
	--The implementation is loosely coupled and passed via dependency injection
	--IBookRepository.cs
	--BookRepository.cs Calls the data access layer - Any implementation of Data caching can be performed. 	
 
##  EDTLBS.DAL (Data Access layer - Application DB Context is implemented here using the Entity Framework and using InMemoryDatabase)
	--ApplicationDbContext
 
##  EDTLBS.TestProject (Test Project to check the test cases)
	--BookLibraryControllerTest.cs (Testing the controller mocking the Service api using Xunit and Moq)
	--BookRepositoryTests.cs (Testing the Repository mocking the Repository api using Xunit and Moq)
 
## License
MIT

