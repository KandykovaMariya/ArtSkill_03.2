using ArtSkill_03._2.Models;
using ArtSkill_03._2.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace ArtSkill_03._2.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataManager dataManager;


        public HomeController(DataManager dataManager)
        {
            this.dataManager = dataManager;
           
        }
        [Authorize]
        public IActionResult Index()
        {
            return View(dataManager.TextFields.GetTextFieldByCodeWord("PageIndex")); 
          //  return Content(User.Identity.Name);
        }
        public IActionResult Users()
        {
            return View(dataManager.TextFields.GetTextFieldByCodeWord("PageContacts"));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
