using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FWA.Data.Models;
using FWA.Data.Repositories.Interfaces;

namespace FWA.Data.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private DataContext _context;

        public RatingRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Rating> RatingsByUser(Guid userId)
        {
            return _context.Ratings.Where(x => x.RatedBy == userId);
        }

        public IEnumerable<Rating> RatingsForMovie(Guid movieId)
        {
            return _context.Ratings.Where(x => x.MovieId == movieId);
        }
    }
}
