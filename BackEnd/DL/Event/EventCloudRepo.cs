using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using Entity = DL.Entities;
using Model = Models;

namespace DL
{
    public class EventCloudRepo : IEventRepo
    {
        private Entity.P3ApiContext _context;

       // not sure if this is correct
        public EventCloudRepo(Entity.P3ApiContext p_context)
        {
            _context = p_context;
        }
        public Model.Event AddEvent(Model.Event p_event)
        {
            _context.Events.Add
            (
                new Entity.Event()
                {
                    StartTime = p_event.StartTime,
                    EndTime = p_event.EndTime,
                    StartDate = p_event.StartDate,
                    EndDate = p_event.EndDate,
                    Location = p_event.Location, 
                    EventName = p_event.EventName,
                    EventDescription= p_event.EventDescription
                }
            );
            _context.SaveChanges();
            return p_event;
        }

        public List<Model.Event> GetAllEvent()
        {
            return _context.Events.Select(Event =>
                new Model.Event()
                {
                    EventId =  Event.EventId,
                    StartTime = Event.StartTime,
                    EndTime = Event.EndTime,
                    StartDate = Event.StartDate,
                    EndDate = Event.EndDate,
                    Location = Event.Location, 
                    EventName = Event.EventName,
                    EventDescription= Event.EventDescription
                }
            ).ToList();

        }

        // ---to be deleted---
        //  public int GetEventById (Event p_event)
        // {
        //     Event Event = GeteventById(p_event.EventId);
        //     return Event.EventId;
        // }

         public Model.Event DeleteEvent( int p_event_Id)
        {

            var result = _context.Events
                .FirstOrDefault<Entity.Event>(eve =>
                    eve.EventId == p_event_Id);
            _context.Events.Remove(result);
            _context.SaveChanges();

            return new Model.Event()           

               {
                    EventId = result.EventId,
                    StartTime = result.StartTime,
                    EndTime = result.EndTime,
                    StartDate = result.StartDate,
                    EndDate = result.EndDate,
                    Location = result.Location, 
                    EventName = result.EventName,
                    EventDescription = result.EventDescription 
                };
        


          
        }

        public Event GetEventById(int p_eventId)
        {
            throw new NotImplementedException();
        }

        public Event UpdateEventById(int p_eventId)
        {
            throw new NotImplementedException();
        }

        // --to be deleted--
        // public Event UpdateEventById(Event p_even)
        // {
        //     _context.Event.Update(p_event);
        //     _context.SaveChanges();
        //     return p_event;
      }  // }
    }
