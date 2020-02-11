using AutoMapper;
using EventTracker.Data;
using EventTracker.Dtos;
using EventTracker.Models;

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace EventTracker.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IDataAccess _dataAccess;
        private readonly IMapper _mapper;

        public EventController(IDataAccess dataAccess, IMapper mapper)
        {
            _dataAccess = dataAccess;
            _mapper = mapper;
        }

        // GET: api/Event
        [HttpGet]
        public IActionResult Get()
        {
            var events =_dataAccess.GetAll();

            var model = _mapper.Map<IList<EventDTO>>(events);

            return Ok(model);             
        }

        // GET: api/Event/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var e = _dataAccess.Get(id);

            var model = _mapper.Map<EventDTO>(e);

            return Ok(model);    
            
        }

        // POST: api/Event
        [HttpPost]
        public IActionResult Post([FromBody] EventDTO value)
        {
            var e = _mapper.Map<Event>(value);

            try
            {             
                _dataAccess.Insert(e);
                return Ok();
            }
            catch (Exception ex)
            {
             
                return BadRequest(new { message = ex.Message });
            }          
        }

        // PUT: api/Event/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EventDTO value)
        {
            var ori = _dataAccess.Get(id);

            // Keep original data
            var e = _mapper.Map<Event>(value);
            e.Id = id;
            e.EventLocationId = ori.EventLocationId;
            e.EventDate = ori.EventDate;   
            
            try
            {
                // update event 
                _dataAccess.Update(e);
                return Ok();
            }
            catch (Exception ex)
            {              
                return BadRequest(new { message = ex.Message });
            }          
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _dataAccess.Delete(id);

            return Ok();
        }
    }
}
