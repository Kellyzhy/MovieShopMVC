using MovieShop.Entities;
using MovieShop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieShop.MVC.Controllers
{
    
    public class CastsController : Controller
    {
        private readonly ICastService _castService;

        public CastsController(ICastService castService)
        {
            _castService = castService;
        }

        // GET: Cast
        [HttpGet]
        [Route("details/{id}")]
        public ActionResult CastDetails(int movieId)
        {
            var cast = _castService.GetCastDetails(movieId);
            return View(cast);
        }


        //step 1 create a actin method that return empty View to enter cast information
        // url: cast/create 
        //GET: Cast
        [HttpGet]
        public ActionResult Create()
        {
            return View("CreateCast");
        }
        

        [HttpPost]
        public ActionResult Create(Cast cast)
        {
            return View();
        }
        //save info to DB

        //send cast to Cast Service and cast service needs to send to cast Repository that uses Add method
        //check if the cast is saved in DB


    }

}