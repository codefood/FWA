using FWA.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FWA.Data.Repositories.Interfaces
{
    public interface IMovieRepository
    {
        IList<Movie> Search(IEnumerable<Func<Movie, bool>> filters);

    }
}
