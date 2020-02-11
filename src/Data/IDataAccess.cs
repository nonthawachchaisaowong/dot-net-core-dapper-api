using EventTracker.Dtos;
using EventTracker.Models;
using System.Collections.Generic;

namespace EventTracker.Data
{
    public interface IDataAccess
    {
        public IEnumerable<Event> GetAll();
        public Event Get(int id);
        public void Insert(Event e);
        public void Update(Event e);
        public void Delete(int id);
    }
}
