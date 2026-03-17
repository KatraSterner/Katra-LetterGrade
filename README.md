# Katra-LetterGrade
dotnet application using svelte front end.
## How to Start Project:
### Solution and Projects
```
#Create the Solution
dotnet new sln -n LetterGrade

# Web API
dotnet new webapi -n LetterGrade.Api --use-controllers

# Class Library
dotnet new classlib -n LetterGrade.Core

# add projects to the Solution (.slnx)
dotnet sln add LetterGrade.Api
dotnet sln add LetterGrade.Core

# API "see" the Class Library
dotnet add LetterGrade.Api reference LetterGrade.Core

# Make svelte front-end
npx sv create vinyl-web
cd vinyl-web
npm install
```

### Core
This section will include business logic and database 
interactions. Directories in this project layer: 
 - Models
 - Interfaces  
   - Only needed if interacting with a database
 - Repositories
    - Only needed if interacting with a database
 - Services
 - Data
   - DbContext to outline the database and seed test data

```
# Run these commands from inside the Core project
cd LetterGrade.Core

# delete this file
rm Class.cs
# make needed directories or run this command in Git Bash
mkdir Models Interfaces Repositories Services Data

# packages for using Sqlite DB
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Design

# this layer wont be ran but it can be built to test for errors
dotnet build
```

After running these commands as needed, make any Models 
and DTOs you might need, create DbContext and Repository 
if using a DB, create Services with business logic, and 
set up Program.cs in API (copy another project as needed).

### API
```
# Run these commands from inside the API project
cd LetterGrade.Api

# Add Scalar (OpenAPI UI) for testing
dotnet add package Scalar.AspNetCore
```

Create Controller directory and files and update Program.cs 
to "map controllers". 

To Test that this was successful, run the API project and 
go to `/scalar` to check that there are no errors and the 
controller is returning expected data. Here you can see your 
endpoints and any returned data from them. 

### Svelte Front End
```
# generate fetch logic automatically with HeyAPI
npm install @hey-api/openapi-ts -D
npm install @hey-api/client-fetch

# create connections to DTOs (only if you used a DB)
npx openapi-ts -i http://localhost:5224/openapi/v1.json -o src/lib/api  #change port
```

Build out `+page.svelte` now and run this layer using `npm run dev`. 

## Running the Project: 
To run this project, run the LetterGrade.API layer first 
with `dotnet run` and then run the svelte frontend, 
LetterGrade.Web, with `npm run dev`.