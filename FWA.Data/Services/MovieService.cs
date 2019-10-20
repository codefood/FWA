using FWA.Data.Models;
using FWA.Data.Repositories.Interfaces;
using FWA.Data.Search;
using System;
using System.Collections.Generic;
using System.Text;

namespace FWA.Data.Services
{
    public class MovieService
    {
        private readonly IMovieRepository movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        public IList<Movie> Search(SearchBuilder searchBuilder)
        {
            //entrypoint for adding extra business logic to the search
            return movieRepository.Search(searchBuilder.Build());
        }
    }
}
