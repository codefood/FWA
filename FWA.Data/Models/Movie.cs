using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FWA.Data.Models
{
    public class Movie
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }
        public DateTime Released { get; set; }
        public int RunningTime { get; set; }

        public virtual IList<string> Genres { get; set; }
        
    }
}
