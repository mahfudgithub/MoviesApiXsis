using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Movies21Xsis.Models.Movie
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }        
        public string Title { get; set; }
        public string Description { get; set; }
        public float? Rating { get; set; }
        public string Image { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
    }
}
