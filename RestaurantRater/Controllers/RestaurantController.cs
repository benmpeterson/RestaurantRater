using RestaurantRater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantRater.Controllers
{
    public class RestaurantController : Controller
    {
        //GET: Restaurant
        private RestaurantDBContext db = new RestaurantDBContext();
        // GET: Restaurants
        public ActionResult Index()
        {
            return View(db.Restaurants.ToList());
        }

        //GET: Restaurant/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="RestaurantID, Name")] Restaurant resturant)
        {
            if (ModelState.IsValid)
            {
                db.Restaurants.Add(resturant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(resturant);
        }






    }
}