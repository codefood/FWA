using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FWA.Data.Models
{
    public class Rating
    {
        [Key]
        public Guid Id { get; set; }
        public Guid MovieId { get; set; }

        public virtual User RatedBy { get; set; }
        public decimal Value { get; set; }

        //TODO: 
    }
}
