using MovieShop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieShop.MVC.Controllers
{
    [RoutePrefix("movies")] //for every action method inside the controller, "movie" should be automatically attached
    public class MoviesController : Controller
    {
        //DI with constructor injection
        //private readonly int a;
        private readonly IMovieService _movieservice;
        private readonly IGenreService _genreservice;

        //MVC 5 requires Parameterless constructor
        //For IMovieService movieService, we need to inject an implementation
        //we can pass any object/instance that implements IMovieService Interface
        //in our project MovieService class is implementing IMoveService Interface
        //IOC should inject instance of MovieService for constructor
        //.NET framework there are no bulit-in IOC, we need to download 3rd party IOC's
        //Populer 3rd party IOC's like Ninect, Autofac, Unity etc
        //in .NET Core ot ASP.NET Core Dependency Injection is built-in IOC, so we don/t need that 3rd party IOC
        public MoviesController(IMovieService movieservice, IGenreService genreservice)
        {
            _movieservice = movieservice;
            _genreservice = genreservice;
        }
        
        // GET: Movies
        [HttpGet]
        [Route("")]
        public ActionResult TopMovies()
        {
            var topmovies = _movieservice.GetTop20RevenueMovies();
            return View(topmovies);
        }

        //take genre id from URL and then call movie service to 
        //get a list of movei belonging to that fenre
        [HttpGet]
        [Route("genres/{genreId}")]
        public ActionResult GetMoviesByGenre(int genreId)
        {
            //take genre id from URL and then call movie service to get a list of movie
            //belonging to that genre.
            //return movies to the view and display as imagetags inside the 
            //bootstrp card with image URLs poterUrl from Movie table column
            //create GetMovieByGenre (int genreId) inside IMovieService and
            //implement that method call Movie Repository to get movies of that genre
            var movies = _movieservice.GetMoviesByGenre(genreId).OrderBy(m => m.Title).ToList();
            return View("MoviesByGenre", movies);
        }

        public ActionResult MovieDetails(int movieId)
        {
            //a = 8; a readonly file cannot be assigned to (except in a constructor or a variable initiialzer)
            //int x = 0;
            //int y = 7;
            //int ans = y / x;
            var movie = _movieservice.GetMovieById(movieId);
            return View("MovieDetails", movie);
        }
    }
}