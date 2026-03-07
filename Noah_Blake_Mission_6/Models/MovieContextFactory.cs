using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Noah_Blake_Mission_6.Models;

public class MovieContextFactory : IDesignTimeDbContextFactory<MovieContext>
{
    public MovieContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<MovieContext>();
        optionsBuilder.UseSqlite("Data Source=JoelHiltonMovies.sqlite");

        return new MovieContext(optionsBuilder.Options);
    }
}
