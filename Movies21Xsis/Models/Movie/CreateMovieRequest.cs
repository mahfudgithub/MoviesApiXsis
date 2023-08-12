using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movies21Xsis.Models.Movie
{
    public class CreateMovieRequest
    {
        [Required(ErrorMessage = "Title is Required"), StringLength(200 , ErrorMessage ="Title Maximum Length 200 character")]
        public string title { get; set; }
        public string description { get; set; }
        [RegularExpression(@"^\d+.\d{0,1}$", ErrorMessage = "Rating can't have more than 1 decimal places")]
        [Range(minimum:0.1,maximum:10.0, ErrorMessage = "Rating value Maximum 10")]
        public float rating { get; set; }
        public string image { get; set; }
    }
}
