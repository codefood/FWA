using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<IActionResult> Search(SearchModel model)
        {
            if (!model.Valid())
                return BadRequest();

            return null;
        }

    }
}