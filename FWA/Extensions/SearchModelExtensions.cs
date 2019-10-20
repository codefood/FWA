using FWA.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FWA.WebApi.Extensions
{
    public static class SearchModelExtensions
    {

        public static bool Valid(this SearchModel model)
        {
            return 
                model != null &&
                model.Genre != null && 
                model.Title != null && 
                model.YearOfRelease != null && 
                model.Genres != null && 
                model.Genres.Any();
        }
    }
}
