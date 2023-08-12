using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Movies21Xsis.DataContext;
using Movies21Xsis.Exceptions;
using Movies21Xsis.Interface;
using Movies21Xsis.Models;
using Movies21Xsis.Models.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies21Xsis.Repository
{
    public class MovieRepository : IMovies
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public MovieRepository(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<WebResponse> CreateMovieAsync(CreateMovieRequest createMovieRequest)
        {
            WebResponse webResponse = new WebResponse();

            Movie movie = new Movie()
            {
                Title = createMovieRequest.title,
                Description = createMovieRequest.description,
                Rating = createMovieRequest.rating,
                Image = createMovieRequest.image,
                Created_at = DateTime.Now
            };
            try
            {
                _appDbContext.Movies.Add(movie);
                await _appDbContext.SaveChangesAsync();

                webResponse.status = true;
                webResponse.message = "Insert Data Successfully";
                webResponse.data = movie;
            }
            catch (Exception ex)
            {
                throw new BadRequestException($"Something went wrong : {ex.Message}");
            }

            return webResponse;
        }


        public async Task<Movie> GetMovieById(int Id)
        {
            var movie = new Movie();
            try
            {
                movie = await _appDbContext.Movies.FindAsync(Id);
            }
            catch (Exception ex)
            {
                throw new BadRequestException($"Something went wrong : {ex.Message}");
            }

            return movie;
        }

        public async Task<WebResponse> GetListMovies()
        {
            WebResponse webResponse = new WebResponse();
            try
            {
                var result = await _appDbContext.Movies.ToListAsync();

                var dataMap = _mapper.Map<List<Movie>>(result.OrderBy(o => o.Id));
                webResponse.status = true;
                webResponse.message = "Get List Data Successfully";
                webResponse.data = dataMap;
            }
            catch (Exception ex)
            {
                throw new BadRequestException($"Something went wrong : {ex.Message}");
            }
            return webResponse;
        }

        public async Task<WebResponse> GetMoviesById(int Id)
        {
            WebResponse webResponse = new WebResponse();

            var movie = await GetMovieById(Id);
            if (movie != null)
            {
                webResponse.status = true;
                webResponse.message = "Get Data Successfully";
                webResponse.data = movie;
            }
            else
            {
                webResponse.status = false;
                webResponse.message = "No Data Found";
                webResponse.data = null;
            }
            return webResponse;
        }

        public async Task<WebResponse> UpdateMoviesAsync(int Id, CreateMovieRequest createMovieRequest)
        {
            WebResponse webResponse = new WebResponse();
            bool isValid = true;

            // Validation
            if (string.IsNullOrWhiteSpace(Id.ToString()))
            {
                isValid = false;
                webResponse.status = false;
                webResponse.message = "Id Should not be empty";
                webResponse.data = null;
            }

            var movie = await GetMovieById(Id);
            if (movie == null)
            {
                isValid = false;
                webResponse.status = false;
                webResponse.message = "No Data Found";
                webResponse.data = null;
            }
            // End

            if (isValid)
            {
                Movie movieDTO = new Movie()
                {
                    Id = Id,
                    Title = createMovieRequest.title,
                    Description = createMovieRequest.description,
                    Rating = createMovieRequest.rating,
                    Image = createMovieRequest.image,
                    Created_at = movie.Created_at,
                    Updated_at = DateTime.Now
                };

                try
                {
                    _appDbContext.Movies.Update(movieDTO);
                    await _appDbContext.SaveChangesAsync();

                    webResponse.status = true;
                    webResponse.message = "Update Data Successfully";
                    webResponse.data = movieDTO;
                }
                catch (Exception ex)
                {
                    throw new BadRequestException($"Something went wrong : {ex.Message}");
                }
            }
            return webResponse;
        }

        public async Task<WebResponse> DeleteMoviesAsync(int Id)
        {
            WebResponse webResponse = new WebResponse();

            var movie = await GetMovieById(Id);
            if (movie == null)
            {
                webResponse.status = false;
                webResponse.message = "No Data Found";
                webResponse.data = null;
            }
            else
            {
                try
                {
                    _appDbContext.Movies.Remove(movie);
                    await _appDbContext.SaveChangesAsync();

                    webResponse.status = true;
                    webResponse.message = "Delete Data Successfully";
                    webResponse.data = null;
                }
                catch (Exception ex)
                {
                    throw new BadRequestException($"Something went wrong : {ex.Message}");
                }
            }

            return webResponse;
        }
    }
}
