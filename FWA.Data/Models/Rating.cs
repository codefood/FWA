using System;
using System.Collections.Generic;
using System.Text;

namespace FWA.Data.Models
{
    public class Rating
    {
        public Guid Id { get; set; }
        public Guid MovieId { get; set; }

        public Guid RatedBy { get; set; }
        public decimal Value { get; set; }

        //TODO: 
    }
}
