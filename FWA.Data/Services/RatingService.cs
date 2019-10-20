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

        public decimal GetAverageRating(Guid movieId)
        {
            var ratings = _ratingRepository.RatingsForMovie(movieId);
            var rating = ratings.Average(x => x.Value);
            return Round(rating);
        }

        public async Task<IEnumerable<RatedMovie>> TopFive(Guid? ratedBy)
        {
            return (await _ratingRepository.TopByRating(5, ratedBy)).Select(x => 
            { 
                x.Rating = Round(x.Rating);
                return x;
            });
        }

        public decimal Round(decimal input)
        {
            return Math.Round(input * 2, MidpointRounding.AwayFromZero) / 2;
        }


    }
}
