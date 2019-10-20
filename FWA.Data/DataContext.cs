using FWA.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FWA.Data
{
    /// <summary>
    /// TODO: Implement Data storage
    /// </summary>
    /// * Investigate Entity Framework, Dapper, other ORMs
    /// * Might be worth looking into NoSQL databases, MongoDB could store this data beautifully!
    /// * Select the best for the data that needs to be stored
    public class DataContext : DbContext
    {

        public DataContext()
        {
            //DEMO: Add a random collection of movies
            //These methods need to be run in order
            SeedUsers();
            SeedMovies();
            SeedRatings();

        }

        private void SeedUsers()
        {
            var rand = new Random();
            for(var i = 0; i < rand.Next(10, 20); i++)
            {
                Users.Add(new User()
                {
                    Id = Guid.NewGuid()
                });
            }
        }

        private void SeedMovies()
        {
            var demoMovieNames = new List<string> { "The Godfather", "The Shawshank Redemption", "The Godfather: Part II", "Inception", "Fight Club", "The Dark Knight", "12 Angry Men" };
            var rand = new Random();

            foreach (var demoMovie in demoMovieNames)
            {

                Movies.Add(new Movie()
                {
                    Id = Guid.NewGuid(),
                    Title = demoMovie,
                    //No movies are released after the 29th of the month in the country of Testland, where this test is set
                    Released = new DateTime(rand.Next(1950, 2019), rand.Next(1,12), rand.Next(1, 28)), 
                    RunningTime = rand.Next(85, 240)
                });
            }
        }

        private void SeedRatings()
        {
            var rand = new Random();
            foreach (var movie in Movies)
            {
                for (var i = 0; i < rand.Next(1, 20); i++)
                {
                    Ratings.Add(new Rating()
                    {
                        Id = Guid.NewGuid(),
                        MovieId = movie.Id,
                        RatedBy = Users[rand.Next(0, Users.Count())],
                        Value = rand.Next(0, 5)
                    });
                }
            }
        }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Rating> Ratings { get; set; }

        public DbSet<User> Users { get; set; }

    }
}
