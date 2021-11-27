using System.Collections.Generic;
using Models;

namespace BL
{
    public interface IEventBL
    {
        /// <summary>
        /// will return a list of Event
        /// </summary>
        /// <returns></returns>
        List<Event> GetAllEvent();

        /// <summary>
        /// Adds passed event to the database
        /// </summary>
        /// <param name="p_event"></param>
        /// <returns>added user</returns>
        Event AddEvent(Event p_event);

         /// <summary>
        /// It will grab any event from the database by it's Id
        /// </summary>
        /// <param name="p_eventId">This is the Id that will be assigned to the event</param>
        /// <returns>It returns the event by Id</returns>

        Event GetEventById(int p_eventId);

        Event UpdateEventById(int p_eventId);

 /// <summary>
        /// It will delete an Event from the database
        /// </summary>
        /// <param name="p_event">This is the event it will delete</param>
        /// <returns>It returns the deleted event</returns>
        Event DeleteEvent(Event p_event);

    
    }
}