using FWA.Data.Models;
using FWA.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FWA.Data.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly DataContext context;

        public MovieRepository(DataContext context)
        {
            this.context = context;
        }

        public IList<Movie> Search(IEnumerable<Func<Movie, bool>> filters)
        {
            var queryable = context.Movies.AsQueryable();
            
            foreach(var filter in filters)
            {
                queryable = queryable.Where(filter).AsQueryable();
            }
            return queryable.ToList();
        }
    }
}
