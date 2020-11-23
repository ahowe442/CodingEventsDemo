using System;
using System.Collections.Generic;
using CodingEvents.Models;

namespace CodingEvents.Data
{
    public class EventData
    {
        //Store the events
        static private Dictionary<int, Event> Events = new Dictionary<int, Event>();

        //Add events
        public static void Add(Event newEvent)
        {
            Events.Add(newEvent.Id, newEvent);
        }

        //GetAll - retrieve the events.
        public static IEnumerable<Event> GetAll()
        {
            return Events.Values;
        }

        //GetById - retrieve by a single event by id. 
        public static Event GetById(int id)
        {
            return Events[id];
        }

        //Remove
        public static void Remove(int id)
        {
            Events.Remove(id);
        }

    }
}
