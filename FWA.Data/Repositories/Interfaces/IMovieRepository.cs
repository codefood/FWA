using FWA.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FWA.Data.Repositories.Interfaces
{
    public interface IMovieRepository
    {
        IList<Movie> Search(IEnumerable<Func<Movie, bool>> filters);

        Task Setup();

    }
}
