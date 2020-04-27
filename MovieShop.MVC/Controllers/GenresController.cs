using MovieShop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieShop.MVC.Controllers
{
    public class GenresController : Controller
    {
        private readonly IGenreService _genreService;
        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }
        // GET: Genres
        public PartialViewResult GetGenreName()
        {
            var genres = _genreService.GetAllGenres().OrderBy(g => g.Name).ToList();
            return PartialView("GenreView", genres);
        }
        
    }
}