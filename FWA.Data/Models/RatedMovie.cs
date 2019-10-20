using FWA.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FWA.Data.Models
{
    public class RatedMovie : Movie
    {

        public decimal Rating { get; set; }
    }
}
