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

            var demoMovieNames = new List<string>{ "The Godfather", "The Shawshank Redemption", "The Godfather: Part II", "Inception", "Fight Club", "The Dark Knight", "12 Angry Men" };
            var rand = new Random();
            Movies = new List<Movie>();

            foreach(var demoMovie in demoMovieNames)
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

        public IList<Movie> Movies { get; set; }

        public IList<Rating> Ratings { get; set; }

    }
}
