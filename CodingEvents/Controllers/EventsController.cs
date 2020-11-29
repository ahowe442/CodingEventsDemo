using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEvents.Data;
using CodingEvents.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodingEvents.Controllers
{
    public class EventsController : Controller
    {
        //static private List<string> Events = new List<string>();
        //static private Dictionary<string, string> Events = new Dictionary<string, string>();
        static private List<Event> Events = new List<Event>();

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {

            ViewBag.events = EventData.GetAll();

            return View();
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("/Events/Add")]
        public IActionResult NewEvent(Event newEvent)
        {
            EventData.Add(newEvent);

            return Redirect("/Events");
        }

        public IActionResult Delete()
        {
            ViewBag.events = EventData.GetAll();
            return View();
        }


        [HttpPost]
        public IActionResult Delete(int[] eventIds)
        {
            foreach(int eventId in eventIds)
            {
                EventData.Remove(eventId);
            }

            return Redirect("/Events");
        }


        [Route("/Events/Edit/{eventId}")]
        public IActionResult Edit(int eventId)
        {

            ViewBag.eventToEdit = EventData.GetById(eventId);
            ViewBag.title = "Edit Event {Name} (id={Id})";
            return Redirect("/Edit");
        }


        [HttpPost]
        [Route("/Events/Edit")]
        public IActionResult SubmitEditEventForm(int eventId, string name, string description)
        {
            EventData.GetById(eventId);
             
            //EventData = ViewBag.eventToEdit.name;
            //description = ViewBag.eventToEdit.description;
            return Redirect("/Events");
        }
    }
}
/*TODO:  
 * Back in EventsController, round out the Edit() method.

Use an EventData method to find the event object with the given eventId.
Put the event object in ViewBag.
Return the appropriate view.
Within the form fields in Edit.cshtml,

Get the name and description from the event that was passed in via ViewBag and set them as the values of the form fields.
Add action="/events/edit" to the form tag.
Add another input to hold the id of the event being edited. This should be hidden from the user:

 */