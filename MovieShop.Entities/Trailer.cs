using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Entities
{
    [Table("Trailer")]
    public class Trailer
    {
        public int Id { get; set; }

        public int MovieId { get; set; }

        [StringLength(2084)]
        public string TraileraUrl { get; set; }

        [StringLength(2084)]
        public string Name { get; set; }

        //navigation property
        //if given a trailer id and ask for movie name, can query this object
        //==>join Trailer and Mmovie table
        public Movie Movie { get; set; }
    }
}
