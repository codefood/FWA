using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public MovieController(MovieService movieService)
        {
            this.movieService = movieService;
        }

        [HttpGet]
        [Route("setup")]
        public async Task<IActionResult> Setup()
        {
            await this.movieService.Setup();
            return Ok();
        }

        [HttpGet]
        [Route("{*title}")]
        public async Task<IActionResult> Search(string title)
        {
            return await Search(new SearchModel()
            {
                Title = title
            });
        }

        [HttpPost]
        public async Task<IActionResult> Search(SearchModel model)
        {
            if (!model.Valid())
                return BadRequest();

            var searchBuilder = new SearchBuilder();
            if (model.Title != null) searchBuilder = searchBuilder.WithPartialTitle(model.Title);
            if (model.YearOfRelease != null) searchBuilder = searchBuilder.Since(model.YearOfRelease.Value);
            if (model.Genre != null) searchBuilder = searchBuilder.WithGenre(model.Genre);
            if (model.Genres != null) searchBuilder = searchBuilder.WithGenre(model.Genres);

            var result = movieService.Search(searchBuilder);

            if (!result.Any()) return NotFound();

            return Ok(result);
        }

    }
}