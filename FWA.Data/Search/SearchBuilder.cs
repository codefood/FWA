using FWA.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FWA.Data.Search
{
    public class SearchBuilder
    {
        private string? Title { get; set; } 
        private DateTime? OnDate { get; set; }
        private List<string>? Genres { get; set; }

        public SearchBuilder WithPartialTitle(string title)
        {
            Title = title;
            return this;
        }
        public SearchBuilder On(int year)
        {
            OnDate = new DateTime(year, 1, 1);
            return this;
        }

        public SearchBuilder WithGenre(params string[] genres)
        {
            Genres = genres.ToList();
            return this;
        }

        public IEnumerable<Func<Movie, bool>> Build()
        {
            if (Title != null)
                yield return (x => x.Title.Contains(Title, StringComparison.OrdinalIgnoreCase));
            if (OnDate != null)
                yield return (x => x.Released.Year == OnDate.Value.Year);
            if (Genres != null && Genres.Any())
                yield return (x => x.Genres?.Any(y => Genres.Contains(y.Name)) ?? false);
        }

    }
}
