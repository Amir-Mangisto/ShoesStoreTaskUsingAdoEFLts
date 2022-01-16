using ShoesStoreTaskUsingAdoEFLts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoesStoreTaskUsingAdoEFLts.Controllers
{
    public class SportShoesController : Controller
    {
        SportShoe[] shoes = new SportShoe[]
                {
            new SportShoe(1,"Nike","Air 1",8,400),
            new SportShoe(2,"Jorden","Max",10,200),
            new SportShoe(3,"Adidas","Summer",9,150),
            new SportShoe(4,"Nike","Air 1",5,100)
                };

        // GET: SportShoe
        public ActionResult ShowSportShoeName()
        {
            ViewBag.SportShoeName = shoes[0].Brand;
            return View();
        }

        public ActionResult ShowShoe(int id)
        {
            SportShoe sportShoe = shoes.First(shoeId => shoeId.Id == id);
            ViewBag.Theshoe = sportShoe;
            return View();
        }
        public ActionResult ShowAllShoes()
        {
            return View(shoes);
        }
    }
}
