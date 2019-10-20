using FWA.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FWA.Data.Repositories.Interfaces
{
    public interface IRatingRepository
    {

        IEnumerable<Rating> RatingsForMovie(Guid movieId);
        IEnumerable<Rating> RatingsByUser(Guid userId);

    }
}
