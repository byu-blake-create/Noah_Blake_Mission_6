using Microsoft.EntityFrameworkCore;

namespace Noah_Blake_Mission_6.Models;

public class MovieContext : DbContext
{
    public MovieContext(DbContextOptions<MovieContext> options) : base(options)
    {
    }

    public DbSet<Movie> Movies => Set<Movie>();
    public DbSet<Category> Categories => Set<Category>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>()
            .HasMany(c => c.Movies)
            .WithOne(m => m.Category)
            .HasForeignKey(m => m.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, CategoryName = "Action/Adventure" },
            new Category { CategoryId = 2, CategoryName = "Comedy" },
            new Category { CategoryId = 3, CategoryName = "Drama" },
            new Category { CategoryId = 4, CategoryName = "Family" },
            new Category { CategoryId = 5, CategoryName = "Miscellaneous" }
        );

        modelBuilder.Entity<Movie>().HasData(
            new Movie
            {
                MovieId = 1,
                CategoryId = 1,
                Title = "The Dark Knight",
                Year = 2008,
                Director = "Christopher Nolan",
                Rating = "PG-13",
                Edited = false,
                CopiedToPlex = true,
                LentTo = null,
                Notes = "Favorite Batman film"
            },
            new Movie
            {
                MovieId = 2,
                CategoryId = 1,
                Title = "The Lord of the Rings: The Fellowship of the Ring",
                Year = 2001,
                Director = "Peter Jackson",
                Rating = "PG-13",
                Edited = false,
                CopiedToPlex = true,
                LentTo = null,
                Notes = "Extended edition"
            },
            new Movie
            {
                MovieId = 3,
                CategoryId = 3,
                Title = "Interstellar",
                Year = 2014,
                Director = "Christopher Nolan",
                Rating = "PG-13",
                Edited = false,
                CopiedToPlex = true,
                LentTo = null,
                Notes = "Amazing score"
            }
        );
    }
}
