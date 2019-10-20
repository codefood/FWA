using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FWA.Data.Models;
using FWA.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FWA.Data.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private DataContext _context;

        public RatingRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RatedMovie>> TopByRating(int count, Guid? ratedBy)
        {
            var ratings = (await _context.Ratings
                .Include(x => x.Movie)
                 .Where(x => ratedBy == null || x.RatedBy.Equals(ratedBy.Value))
                 .GroupBy(x => x.MovieId)
                 .Select(x => new
                 {
                     Id = x.Key,
                     //Movie = x.Select(y => y.Movie).FirstOrDefault(),
                     TotalRating = x.Sum(y => y.Value),
                     AverageRating = x.Average(y => y.Value)
                 })
                 .OrderByDescending(x => x.AverageRating)
                 //.ThenBy(x => x.Movie.Title)
                 .Take(count)
                 .ToListAsync());
            

            var list = new List<RatedMovie>();
            foreach(var rating in ratings)
            {
                var movie = await _context.Movies.FirstOrDefaultAsync(x => x.Id == rating.Id);
                list.Add(new RatedMovie()
                {
                    Genres = movie.Genres,
                    Id = movie.Id,
                    Rating = rating.AverageRating,
                    Released = movie.Released,
                    RunningTime = movie.RunningTime,
                    Title = movie.Title
                });
            }
            return list;

        }

        public IEnumerable<Rating> RatingsByUser(Guid userId)
        {
            return _context.Ratings.Where(x => x.RatedBy != null && x.RatedBy.Id == userId);
        }

        public IEnumerable<Rating> RatingsForMovie(Guid movieId)
        {
            return _context.Ratings.Where(x => x.MovieId == movieId);
        }
    }
}
