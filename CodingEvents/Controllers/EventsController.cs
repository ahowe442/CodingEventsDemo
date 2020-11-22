using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodingEvents.Controllers
{
    public class EventsController : Controller
    {
        static private List<string> Events = new List<string>();
        //static private Dictionary<string, string> Events = new Dictionary<string, string>();
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {

            ViewBag.events = Events;

            return View();
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("/Events/Add")]
        public IActionResult NewEvent(String name)
        {
            Events.Add(name);
            return Redirect("/Events");
        }
    }
}
