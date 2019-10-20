using FWA.Data.Models;
using FWA.Data.Repositories;
using FWA.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FWA.Data.Services
{
    public class RatingService
    {
        private readonly IRatingRepository _ratingRepository;

        public RatingService(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        public decimal GetAverageRating(Movie movie)
        {
            return GetAverageRating(movie.Id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns></returns>
        /// <remarks>Consider implementing a caching layer here</remarks>
        public decimal GetAverageRating(Guid movieId)
        {
            var ratings = _ratingRepository.RatingsForMovie(movieId);
            var rating = ratings.Average(x => x.Value);
            return Round(rating);
        }

        public decimal Round(decimal input)
        {
            return Math.Round(input, MidpointRounding.AwayFromZero);
        }


    }
}
