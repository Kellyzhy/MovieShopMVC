﻿using MovieShop.MVC.Filters;
using System.Web;
using System.Web.Mvc;

namespace MovieShop.MVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
