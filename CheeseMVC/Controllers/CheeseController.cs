using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheeseMVC.Models.Cheese;
using Microsoft.AspNetCore.Mvc;

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
        public static List<Cheese> cheeses = new List<Cheese>();

        [HttpGet]
        public IActionResult Index()
        {
            
            return View(cheeses);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Cheese cheese)
        {
            cheeses.Add(cheese);
            return Redirect("Index");
        }

        [HttpGet]
        public IActionResult CheckBoxDelete()
        {
            ViewBag.cheeses = cheeses;
            return View();
        }

        [HttpPost]
        public IActionResult CheckBoxDelete(string[] cheese)
        {

            return Redirect("Index");
        }

        [HttpGet]
        public IActionResult DropDownDelete()
        {
            return View(cheeses);
        }

        [HttpPost]
        public IActionResult DropDownDelete(Cheese cheese)
        {
            return Redirect("Index");
        }
    }
}