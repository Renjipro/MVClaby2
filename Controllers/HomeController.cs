﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CarManager.Models;

namespace CarManager.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Lista samochodów do wyświetlenia
        /// </summary>
        List<CarViewModel> allCars;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

            this.allCars = new List<CarViewModel>();

            allCars.Add(new CarViewModel("Focus", "Ford", 10000, "~/Images/focus.png"));
            allCars.Add(new CarViewModel("Golf", "Volkswagen", 20000, "~/Images/golf.png"));
            allCars.Add(new CarViewModel("Civic", "Honda", 30000, "~/Images/civic.png"));
            allCars.Add(new CarViewModel("Megane", "Renault", 40000, "~/Images/megane.png"));
            
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult InterestingLink()
        {
            return View();
        }

        public IActionResult GetAllCars()
        {
            return View(this.allCars);
        }

        public IActionResult GetCarByModel(string model)
        {
            CarViewModel car = this.allCars.Where(a => a.Model.ToLower() == model.ToLower()).FirstOrDefault();
            return View(car);
        }

        public IActionResult GetListOfModels()
        {
            List<string> allModels = new List<string>();

            foreach(CarViewModel Car in this.allCars)
            {
                allModels.Add(Car.Model);
            }
            return View(allModels);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
