using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FWA.Data.Models
{
    public class Genre
    {
        [Key]
        public string Name { get; set; } = "";
    }
}
