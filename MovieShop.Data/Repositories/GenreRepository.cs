using MovieShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Data.Repositories
{
    public class GenreRepository : Repository<Genre>, IGenreRepository//this class depanding on contract 
        // the fist one is ihenrantance, 8 method
        //second one is 
    {
        public GenreRepository(MovieShopDbContext context) : base(context)//base>>repository
        {
            //constracter, expacting MovieDbContext, the context passing to base class
        }

        public Genre GetGenreByName(string name)
        {
            var genre = _context.Genres.FirstOrDefault(g => g.Name == name);
            //var genre = _context.Genres.Where(g => g.Name == name).FirstOrDefault();
            return genre;
        }
    }
    public interface IGenreRepository : IRepository<Genre> //8 method // total implementing 9 method 
    {//
        Genre GetGenreByName(string name);//one method 
    }
}
