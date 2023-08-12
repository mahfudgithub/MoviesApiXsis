using Movies21Xsis.Models;
using Movies21Xsis.Models.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies21Xsis.Interface
{
    public interface IMovies
    {
        Task<WebResponse> GetListMovies();
        Task<WebResponse> CreateMovieAsync(CreateMovieRequest createMovieRequest);
        Task<WebResponse> GetMoviesById(int Id);
        Task<WebResponse> UpdateMoviesAsync(int Id, CreateMovieRequest createMovieRequest);
        Task<WebResponse> DeleteMoviesAsync(int Id);
    }
}
