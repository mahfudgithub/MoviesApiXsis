using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies21Xsis.Interface;
using Movies21Xsis.Models.Movie;
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

        [HttpPost]
        public async Task<IActionResult> CreateMovies([FromBody] CreateMovieRequest createMovieRequest)
        {
            if (ModelState.IsValid)
            {
                var result = await _movies.CreateMovieAsync(createMovieRequest);
                return Ok(result);
            }
            return BadRequest("Some Properties are not valid ");
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetMoviesById([FromRoute] int Id)
        {
            if (ModelState.IsValid)
            {
                var result = await _movies.GetMoviesById(Id);
                return Ok(result);
            }
            return BadRequest("Some Properties are not valid ");
        }

        [HttpPatch("{Id}")]
        public async Task<IActionResult> UpdateMovies([FromRoute] int Id, [FromBody] CreateMovieRequest createMovie)
        {
            if (ModelState.IsValid)
            {
                var result = await _movies.UpdateMoviesAsync(Id, createMovie);
                return Ok(result);
            }
            return BadRequest("Some Properties are not valid ");
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteMovies([FromRoute] int Id)
        {
            if (ModelState.IsValid)
            {
                var result = await _movies.DeleteMoviesAsync(Id);
                return Ok(result);
            }
            return BadRequest("Some Properties are not valid ");
        }
    }
}
