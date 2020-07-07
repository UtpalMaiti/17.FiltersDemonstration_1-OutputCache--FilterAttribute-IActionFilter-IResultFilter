using FiltersDemonstration_1.UtilityClasses;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace FiltersDemonstration_1.Controllers
{
    //[CustomActionFilter]
    public class HomeController : Controller
    {
        // GET: Home
        //[CustomActionFilter]                   //it is used for Reslt or view purpose
        [CustomActionResultFilter]                                                     //it is used for Action view purpose
        //[OutputCache(CacheProfile = "testProfile")]   //This is configue in WebConfig
        [OutputCache(Duration = 60)]                                                    //This Hard coded in Controller
        public ActionResult Index()
        {
            System.Web.Caching.Cache cache = new System.Web.Caching.Cache();
            cache["name"] = "Test";

            ViewBag.ControllerName = cache["name"];
            ViewBag.CountryList = new List<string>
            {
                "India","China","Japan","US","UK"
            };

            Thread.Sleep(1000);
            return View();
        }

        //[CustomActionFilter]
        [OverrideActionFilters]  //if dont want to apply on Parent /Contoller filter // to remove Controller Filter Behaviour
        public ActionResult EditProfile(string id)
        {
            //write the Logic to get the Profile Details By Id
            Thread.Sleep(500);
            return View();
        }
    }
}