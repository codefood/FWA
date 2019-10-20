using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FWA.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FWA.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopController : ControllerBase
    {
        private readonly RatingService ratingService;

        public TopController(RatingService ratingService)
        {
            this.ratingService = ratingService;
        }

        [HttpGet]
        [Route("{user?}")]
        public async Task<IActionResult> User(Guid? userId)
        {
            return Ok(await ratingService.TopFive(userId));
        }

    }
}