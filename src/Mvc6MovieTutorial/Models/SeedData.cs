using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Mvc6MovieTutorial.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            if (context.Database == null) { throw new Exception("DB is null!"); }
            if (context.Movie.Any()) { return; } //If there are any movies in the DB, the DB has been seeded

            context.Movie.AddRange(
            new Movie
            {
                Title = "Alien",
                ReleaseDate = DateTime.Parse("1979-04-22"),
                Genre = "Horror, Sci-Fi",
                Rating = "R",
                Price = 2.51M
            },
            new Movie
            {
                Title = "A Clockwork Orange",
                ReleaseDate = DateTime.Parse("1972-02-02"),
                Genre = "Crime, Drama, Sci-Fi",
                Rating = "R",
                Price = 1.55M
            },
            new Movie
            {
                Title = "The Shining",
                ReleaseDate = DateTime.Parse("1980-05-23"),
                Genre = "Drama, Horror",
                Rating = "R",
                Price = 2.69M
            },
            new Movie
            {
                Title = "Pulp Fiction",
                ReleaseDate = DateTime.Parse("1994-08-14"),
                Genre = "Crime, Drama",
                Rating = "R",
                Price = 4.18M
            },
            new Movie
            {
                Title = "Inception",
                ReleaseDate = DateTime.Parse("2010-07-16"),
                Genre = "Action, Mystery, Sci-Fi",
                Rating = "R",
                Price = 7.89M
            },
            new Movie
            {
                Title = "Purple Rain",
                ReleaseDate = DateTime.Parse("1984-07-27"),
                Genre = "Drama, Music, Musical",
                Rating = "R",
                Price = 3.36M
            },
            new Movie
            {
                Title = "Cats Don't Dance",
                ReleaseDate = DateTime.Parse("1997-03-26"),
                Genre = "Animation, Comedy, Family",
                Rating = "G",
                Price = 4.59M
            });
            context.SaveChanges();
        }
    }
}
