using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FWA.Data.Models;
using FWA.Data.Search;
using FWA.Data.Services;
using FWA.WebApi.Extensions;
using FWA.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FWA.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MovieService movieService;
        private readonly RatingService ratingService;

        public MovieController(MovieService movieService, RatingService ratingService)
        {
            this.movieService = movieService;
            this.ratingService = ratingService;
        }

        [HttpGet]
        [Route("setup")]
        public async Task<IActionResult> Setup()
        {
            await this.movieService.Setup();
            return Ok();
        }

        [HttpGet]
        [Route("{*input}")]
        public IActionResult Search(string input)
        {
            if (string.IsNullOrEmpty(input)) return BadRequest();

            var model = new SearchModel();
            if(int.TryParse(input, out var year))
            {
                model.YearOfRelease = year;
            }
            else
            {
                model.Title = input;
            }
            return Search(model);
        }

        [HttpPost]
        public IActionResult Search(SearchModel model)
        {
            if (!model.Valid())
                return BadRequest();

            var searchBuilder = new SearchBuilder();
            if (model.Title != null) searchBuilder = searchBuilder.WithPartialTitle(model.Title);
            if (model.YearOfRelease != null) searchBuilder = searchBuilder.On(model.YearOfRelease.Value);
            if (model.Genre != null) searchBuilder = searchBuilder.WithGenre(model.Genre);
            if (model.Genres != null) searchBuilder = searchBuilder.WithGenre(model.Genres);

            var searchRResult = movieService.Search(searchBuilder);

            if (!searchRResult.Any()) return NotFound();

            var ratedResults = searchRResult.Select(x => new RatedMovie()
            {
                Genres = x.Genres,
                Released = x.Released,
                RunningTime = x.RunningTime,
                Id = x.Id,
                Title = x.Title,
                Rating = ratingService.GetAverageRating(x)
            });

            return Ok(ratedResults);
        }

    }
}