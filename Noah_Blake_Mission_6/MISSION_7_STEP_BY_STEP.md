# Mission #7 Step-by-Step Instructions (Joel Hilton Movie Collection)

## 1. Work on the correct branch
1. Confirm you are on your Mission 7 branch:
   - `git branch --show-current`
2. If needed, rename to the class naming convention:
   - `git branch -m Mission07_Blake`
3. Push the branch to GitHub:
   - `git push -u origin <your-branch-name>`

## 2. Replace the database with the provided file
1. Download the provided SQLite file from:
   - <https://byu.box.com/s/7r68gh9tz6e22criq36k2shrp47f2pv2>
2. Put the file in the project root and name it `JoelHiltonMovies.sqlite` (same location as `appsettings.json`).
3. Remove stale SQLite lock files if they exist:
   - `JoelHiltonMovies.sqlite-shm`
   - `JoelHiltonMovies.sqlite-wal`
4. Verify `appsettings.json` still points to:
   - `"MovieConnection": "Data Source=JoelHiltonMovies.sqlite"`

## 3. Update the model to match Mission 7 validation rules
1. Edit `Models/Movie.cs`.
2. Ensure these required fields are enforced:
   - `Title` required
   - `Year` required and minimum `1888`
   - `Edited` required
   - `CopiedToPlex` required (add this property if missing)
3. Implement validation attributes:
   - Keep `[Required]` on `Title`
   - Add `[Range(1888, 3000)]` on `Year`
   - Make `Edited` and `CopiedToPlex` non-nullable (`bool`) or use nullable + `[Required]` with explicit UI selection
4. Keep existing properties that are still in the DB (`Category`, `Director`, `Rating`, `LentTo`, `Notes`) unless your schema says otherwise.

## 4. Update Add Movie form for required fields
1. Edit `Views/Home/AddMovie.cshtml`.
2. Make sure `Title` and `Year` inputs display validation messages.
3. Add UI for `CopiedToPlex` (if not present).
4. Use explicit Yes/No controls for `Edited` and `CopiedToPlex` (radio buttons are usually clearer than a single checkbox for required values).
5. Keep `@Html.AntiForgeryToken()` and validation summary.

## 5. Add a page to list all movies
1. In `Controllers/HomeController.cs`, add a GET action (example: `MovieList`) that loads movies from `_context.Movies`.
2. Sort predictably (example: by `Title` then `Year`).
3. Create `Views/Home/MovieList.cshtml`.
4. Build a Bootstrap table using classes like:
   - `table table-striped table-bordered table-hover`
5. Include columns for key movie fields and action buttons/links for Edit and Delete.

## 6. Add Update (Edit) functionality
1. Add `EditMovie(int id)` GET action in `Controllers/HomeController.cs` to load the selected movie.
2. Add `EditMovie(Movie movie)` POST action to validate and save updates.
3. Reuse `AddMovie.cshtml` or create a dedicated `EditMovie.cshtml`.
4. Confirm edits persist in the SQLite database.

## 7. Add Delete functionality
1. Add `DeleteMovie(int id)` GET action to show a confirmation page.
2. Add `DeleteMovie(int id, ...)` POST action (or named action like `DeleteConfirmed`) to remove the record.
3. Redirect back to the movie list after deletion.
4. Create `Views/Home/DeleteMovie.cshtml` confirmation UI.

## 8. Add navigation links
1. Edit `Views/Shared/_Layout.cshtml`.
2. Add navbar links to:
   - Movie List page
   - Add Movie page (keep existing link)

## 9. Test required behaviors before submitting
1. Run the app:
   - `dotnet run`
2. Verify:
   - Movie list loads from provided DB
   - Add works
   - Edit works
   - Delete works
   - Validation blocks missing `Title`, `Year`, `Edited`, or `CopiedToPlex`
   - Validation blocks `Year < 1888`
3. Spot-check Bootstrap styling on table and forms.

## 10. Final submission workflow
1. Commit your work:
   - `git add .`
   - `git commit -m "Complete Mission 7 movie collection CRUD and validation"`
2. Push your branch:
   - `git push`
3. In your submission comments, include the exact branch name to be graded.

