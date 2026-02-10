# Mission 6 Step-by-Step Guide (ASP.NET + SQLite)

Below is a clean, end-to-end checklist to build the project exactly to the rubric.
Target project name format: `Mission06_LastName`

## 1) Create the Solution and Project
1. Open terminal in your workspace.
1. Create a new solution and MVC project:
   ```bash
   dotnet new sln -n Mission06_LastName
   dotnet new mvc -n Mission06_LastName
   dotnet sln Mission06_LastName.sln add Mission06_LastName/Mission06_LastName.csproj
   ```
1. Open the solution in your IDE (Rider/VS).

## 2) Add the Required Pages
1. Create three pages:
   - Home page: title + photo
   - Get to Know Joel page: links + linked image
   - Movie Entry page: form to add movies
1. In MVC, add a new controller (e.g., `HomeController`) and three actions:
   - `Index` (Home)
   - `GetToKnowJoel`
   - `AddMovie`
1. Add views for each action under `Views/Home/`.

## 3) Shared Navigation Menu
1. Open the layout file: `Views/Shared/_Layout.cshtml`
1. Add navigation links to:
   - Home
   - Get to Know Joel
   - Add Movie

## 4) Home Page Requirements
1. Add the exact title text:
   - `The Joel Hilton Film Collection`
1. Add the image (use an `<img>` tag):
   - `https://byu.box.com/s/8sjz2qei13h4nnlw0e6gc10ot35octkf`

## 5) “Get to Know Joel” Page Requirements
1. Add a link to Quick Wits Comedy:
   - `https://www.qwcomedy.com/`
1. Add a link to Baconsale:
   - `https://baconsale.com/`
1. Add the image that links to Baconsale:
   - Image source: `https://byu.box.com/s/ie6ibeddqm0f6oudp7bc5dyt87zxi2u4`
   - Wrap the image in an `<a>` tag pointing to `https://baconsale.com/`

## 6) Build the Movie Form
1. Create a model class (e.g., `Movie`) with fields from the spreadsheet.
1. Required fields: all except `Edited`, `Lent To`, `Notes`.
1. Specific rules:
   - `Rating` must be a dropdown: `G`, `PG`, `PG-13`, `R`
   - `Edited` is a yes/no (bool)
   - `Notes` limited to 25 characters
1. Add validation attributes to enforce requirements:
   - `[Required]` for required fields
   - `[StringLength(25)]` for Notes
1. Build the form in the `AddMovie` view using tag helpers.

## 7) SQLite Database (Model-First)
1. Add EF Core packages:
   ```bash
   dotnet add Mission06_LastName package Microsoft.EntityFrameworkCore.Sqlite
   dotnet add Mission06_LastName package Microsoft.EntityFrameworkCore.Tools
   ```
1. Create a `MovieContext` class that inherits from `DbContext`.
1. Register the context in `Program.cs` with a SQLite connection string.
1. Create and apply migrations:
   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```
1. Ensure the DB is normalized (no repeated groups, sensible types).

## 8) Save Movies From the Form
1. In the controller, create a POST action for `AddMovie`.
1. If `ModelState.IsValid`, save to SQLite.
1. Redirect to a confirmation or list page after saving.

## 9) Seed at Least 3 Movies
1. Add 3 of your favorite movies:
   - Use a seeding method or insert them manually.
1. Verify they exist in the database.

## 10) Final Checks
1. Required pages exist and render correctly.
1. Navigation is shared.
1. Form validates properly (rating dropdown, notes length).
1. Database writes work.

## 11) GitHub Submission
1. Initialize git and commit:
   ```bash
   git init
   git add .
   git commit -m "Mission 6 initial submission"
   ```
1. Create a GitHub repo named `Mission06_LastName`.
1. Push and submit the **public** link in Learning Suite.

---

If you want, tell me your last name and I can customize the project name and commands.
