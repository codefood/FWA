using FWA.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FWA.Data.Search
{
    public class SearchBuilder
    {
        public string Title { get; private set; }
        public DateTime SinceDate { get; private set; }
        public List<string> Genres { get; private set; }

        public SearchBuilder WithPartialTitle(string title)
        {
            Title = title;
            return this;
        }
        public SearchBuilder Since(int year)
        {
            SinceDate = new DateTime(year, 1, 1);
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
            if (SinceDate != null)
                yield return (x => x.Released >= SinceDate);
            if (Genres != null && Genres.Any())
                yield return (x => x.Genres?.Any(y => Genres.Contains(y)) ?? false);
        }

    }
}
