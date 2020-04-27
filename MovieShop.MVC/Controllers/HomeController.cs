using MovieShop.MVC.Filters;
using MovieShop.Service;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieShop.MVC.Controllers
{
    //[HandleError]
    //default controller
    [MovieShopExceptionFilter]
    public class HomeController : Controller
    {
        Logger logger = LogManager.GetCurrentClassLogger();
        //default method
        //method only execute when http get request
        //GET is default mthod for action method
        private  readonly IMovieService _movieservice;
        public HomeController(IMovieService movieservice)
        {
            _movieservice = movieservice;
        }


        //[LogActionFilter]  //customer attribut -- action filter
        [HttpGet]
        public ActionResult Index()
        {
            //int x = 1;
            //int y = 0;
            //int z = x / y;

            //look for view's folder --> View
            //look for controller name folder --> Home
            //look for folder which has same name as action method name --> index


            //get top revenue mocies and show them in home page
            //use same Movie Card as you did for genres movies
            var topmovies = _movieservice.GetTop20RevenueMovies(); 
            //go sefination of this method will go to the interface, 
            //but during the run time it should go to specific method implementation
            return View(topmovies);
           
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}