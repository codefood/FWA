﻿using FWA.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FWA.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opts) : base(opts) { }

        public async Task Setup()
        {
            //DEMO: Add a random collection of movies
            //These methods need to be run in order
            if(!Users.Any()) SeedUsers();
            if(!Movies.Any()) SeedMovies();
            if(!Ratings.Any()) SeedRatings();
            await SaveChangesAsync();
        }

        private void SeedUsers()
        {
            var rand = new Random();
            var users = new List<string> { "Fred Jones", "Daphne Blake", "Norville Roberts", "Velma Dinkley" };
            foreach(var user in users)
            {
                Users.Add(new User()
                {
                    Id = Guid.NewGuid(),
                    Name = user
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
            var users = Users.ToArray();

            foreach (var movie in Movies)
            {
                for (var i = 0; i < rand.Next(1, 20); i++)
                {
                    Ratings.Add(new Rating()
                    {
                        Id = Guid.NewGuid(),
                        MovieId = movie.Id,
                        RatedBy = users[rand.Next(0, users.Count())],
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
