using EventTracker.Data;
using EventTracker.Dtos;
using EventTracker.Models;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EventTracker.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IDataAccess _dataAccess;

        public EventController(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        // GET: api/Event
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return _dataAccess.GetAllEvents();
        }

        // GET: api/Event/5
        [HttpGet("{id}", Name = "Get")]
        public EventDTO Get(int id)
        {
            return _dataAccess.GetEventDTOBy(id);
        }

        // POST: api/Event
        [HttpPost]
        public void Post([FromBody] EventDTO value)
        {
            _dataAccess.InsertEvent(value);
        }

        // PUT: api/Event/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] EventDTO value)
        {
            value.Id = id;
            _dataAccess.UpdateEvent(value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _dataAccess.DeleletEvent(id);
        }
    }
}
