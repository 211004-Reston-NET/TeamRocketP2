using System;
using System.Collections.Generic;
using System.Linq;
using DL;
using Models;

namespace BL
{
    public class EventBL : IEventBL

    {
        IEventRepo _repo;

        public EventBL(IEventRepo p_repo)
        {
            _repo = p_repo;
        }
        public Event AddEvent(Event p_event)
        {
            return _repo.AddEvent(p_event);
        }

        public List<Event> GetAllEvent()
        {
            return _repo.GetAllEvent();
        }

        
        
        public Event GetEventById(int p_eventId)
        {
            List<Event> listOfEvent = _repo.GetAllEvent();


            List<Event> Found = (listOfEvent.Where(eve => eve.EventId.Equals(p_eventId))).ToList();

            return Found[0];
        }

        public Event DeleteEvent(int p_event_Id)
        {
            return _repo.DeleteEvent(p_event_Id);
        }

        public Event UpdateEventById(int p_eventId)
        {
            throw new NotImplementedException();
        }
    }
}