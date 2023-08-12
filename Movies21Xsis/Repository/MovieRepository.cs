using Microsoft.EntityFrameworkCore;
using Movies21Xsis.DataContext;
using Movies21Xsis.Exceptions;
using Movies21Xsis.Interface;
using Movies21Xsis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies21Xsis.Repository
{
    public class MovieRepository : IMovies
    {
        private readonly AppDbContext _appDbContext;

        public MovieRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<WebResponse> GetListMovies()
        {
            WebResponse webResponse = new WebResponse();
            try
            {
                var result = await _appDbContext.Movies.ToListAsync();

                webResponse.status = true;
                webResponse.message = "Get List Data Successfully";
                webResponse.data = result;
            }
            catch (Exception ex)
            {
                throw new BadRequestException($"something went wrong : {ex.Message}");
            }
            return webResponse;
        }
    }
}
