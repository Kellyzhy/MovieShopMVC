using MovieShop.Data;
using MovieShop.Data.Repositories;
using MovieShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Service
{
    public class GenreService : IGenreService
    {
        private IGenreRepository _genreRepository;
        public GenreService(IGenreRepository genreRepository)
        {
            //create a new instance
            //var text = new MovieShopDbContext();
            _genreRepository = genreRepository;
        }
        public IEnumerable<Genre> GetAllGenres()
        {
            //GettAll coming from Repository and GenreRepository implementing Repository
            var genres = _genreRepository.GetAll();
            return genres;
        }
    }

    //method based on requirement
    public interface IGenreService
    {
        IEnumerable<Genre> GetAllGenres();
  
    }
}
