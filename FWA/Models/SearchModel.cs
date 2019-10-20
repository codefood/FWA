using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FWA.WebApi.Models
{
    public class SearchModel
    {
        public string? Title { get; set; }
        public int? YearOfRelease { get; set; }
        public string? Genre { get; set; }
        public IEnumerable<string>? Genres { get; set; }

    }
}
