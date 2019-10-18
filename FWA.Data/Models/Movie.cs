using System;
using System.Collections.Generic;
using System.Text;

namespace FWA.Data.Models
{
    public class Movie
    {
        public string Title { get; internal set; }
        public int YearOfRelease { get; internal set; }
        public int RunningTime { get; internal set; }
        public Guid Id { get; internal set; }
    }
}
