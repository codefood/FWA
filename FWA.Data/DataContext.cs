using FWA.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FWA.Data
{
    /// <summary>
    /// TODO: Implement Data storage
    /// </summary>
    /// * Investigate Entity Framework, Dapper, other ORMs
    /// * Might be worth looking into NoSQL databases, MongoDB could store this data beautifully!
    /// * Select the best for the data that needs to be stored
    public class DataContext
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
            Users = new List<Guid>();
            for(var i = 0; i < rand.Next(10, 20); i++)
            {
                Users.Add(Guid.NewGuid());
            }
        }

        private void SeedMovies()
        {
            var demoMovieNames = new List<string> { "The Godfather", "The Shawshank Redemption", "The Godfather: Part II", "Inception", "Fight Club", "The Dark Knight", "12 Angry Men" };
            var rand = new Random();
            Movies = new List<Movie>();

            foreach (var demoMovie in demoMovieNames)
            {
                Movies.Add(new Movie()
                {
                    Id = Guid.NewGuid(),
                    Title = demoMovie,
                    YearOfRelease = rand.Next(1950, 2019),
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
                        RatedBy = Users[rand.Next(0, Users.Count)],
                        Value = rand.Next(0, 5)
                    });
                }
            }
        }

        public IList<Movie> Movies { get; set; }

        public IList<Rating> Ratings { get; set; }

        public IList<Guid> Users { get; set; }

    }
}
