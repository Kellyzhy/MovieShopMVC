using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Entities
{
    [Table("Crew")]
    public class Crew
    {
        public int Id { get; set; }

        [StringLength(128)]
        public String Name { get; set; }
        public String Gender { get; set; }
        public String TmdbUrl { get; set; }

        [StringLength(2084)]
        public String ProfilePath { get; set; }

        public virtual ICollection<MovieCrew> MovieCrews { get; set; }

    }
}
