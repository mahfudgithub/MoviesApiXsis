using Movies21Xsis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies21Xsis.Interface
{
    public interface IMovies
    {
        Task<WebResponse> GetListMovies();
    }
}
