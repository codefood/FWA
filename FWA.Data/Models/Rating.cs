using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FWA.Data.Models
{
    public class Rating
    {
        [Key]
        public Guid Id { get; set; }
        
        [Required]
        public Guid MovieId { get; set; }

        [Required]
        [ForeignKey("MovieId")]
        public virtual Movie Movie { get; set; }

        public virtual User? RatedBy { get; set; }
        public decimal Value { get; set; }

    }
}
