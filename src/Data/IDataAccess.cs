using EventTracker.Dtos;
using EventTracker.Models;
using System.Collections.Generic;

namespace EventTracker.Data
{
    public interface IDataAccess
    {
        public IEnumerable<Event> GetAllEvents();
        public EventDTO GetEventDTOBy(int id);
        public void InsertEvent(EventDTO eventDTO);
        public void UpdateEvent(EventDTO eventDTO);
        public void DeleletEvent(int id);
    }
}
