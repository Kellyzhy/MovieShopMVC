using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Entities
{
    //change table name
    [Table("Genre")]
    public class Genre
    {
        public int Id { get; set; }

        //DataAnnotation attribute used to add constraints on table
        [Required]  //has to be value here
        [StringLength(64)]  //change length to 64
        public string Name { get; set; }

        public ICollection<Movie> Movies { get; set; }

        
    }
}
