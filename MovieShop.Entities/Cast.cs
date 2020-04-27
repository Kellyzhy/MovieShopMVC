using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Entities
{
    [Table("Cast")]
    public class Cast
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please Enter Cast Name")]
        [StringLength(128, ErrorMessage ="Mixmum Length should be 128")]
        public string Name { get; set; }

        public string Gender { get; set; }

        [Url]
        public string TmdbUrl { get; set; }

        [StringLength(2084)]
        [Url]
        public string ProfilePath { get; set; }

        public ICollection<MovieCast> MovieCast { get; set; }
    }
}
