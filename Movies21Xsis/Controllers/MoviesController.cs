using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies21Xsis.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies21Xsis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovies _movies;

        public MoviesController(IMovies movies)
        {
            _movies = movies;
        }
        public async Task<IActionResult> GetListMovies()
        {
            if (ModelState.IsValid)
            {
                var result = await _movies.GetListMovies();
                return Ok(result);
            }
            return BadRequest("Some Properties are not valid ");
        }
    }
}
