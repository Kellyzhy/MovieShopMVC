using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Entities
{ 
    [Table("Movie")]
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(256)]
        public string Title { get; set; }

        public string Overview { get; set; }
            
        [StringLength(512)]
        public string Tagline { get; set; }

        //? means its a nullable property, value types can be made null
        public decimal? Budget { get; set; }
            
        public decimal? Revenue { get; set; }
            
        [StringLength(2084)]
        public string ImdbUrl { get; set; }
            
        [StringLength(2084)]
        public string TmdbUrl { get; set; }
            
        [StringLength(2084)]
        public string PosterUrl { get; set; }
            
        [StringLength(2084)]
        public string BackdropUrl { get; set; }
            
        [StringLength(64)]
        public string OriginalLanguage { get; set; }
            
        [Column(TypeName = "datetime2")]
        public DateTime? ReleaseDate { get; set; }
            
        public int? RunTime { get; set; }
            
        public decimal? Price { get; set; }
            
        [Column(TypeName = "datetime2")]
        public DateTime? CreatedDate { get; set; }
            
        [Column(TypeName = "datetime2")]
        public DateTime? UpdatedDate { get; set; }
            
        public string UpdatedBy { get; set; }
            
        public string CreatedBy { get; set; }

        [NotMapped]
        public decimal? Rating { get; set; }

        public virtual ICollection<Genre> Genres { get; set; }
        //navigation property, one movie has many trailers
        public virtual ICollection<Trailer> Trailers { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<MovieCrew> MovieCrews { get; set; }
        public virtual ICollection<MovieCast> MovieCasts { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}

