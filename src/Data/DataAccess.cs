using Dapper;
using EventTracker.Dtos;
using EventTracker.Models;
using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EventTracker.Data
{
    public class DataAccess : IDataAccess, IDisposable
    {
        private readonly SqlConnection _sqlConnection;
        private readonly IConfiguration _config;

        public DataAccess(IConfiguration config)
        {
            _config = config;
            _sqlConnection = new SqlConnection(_config.GetConnectionString("Default"));
        }

        public void DeleletEvent(int id)
        {
            try
            {
                using (_sqlConnection)
                {
                    _sqlConnection.Execute("DELETE FROM Event WHERE Id = @Id", new { Id = id });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public IEnumerable<Event> GetAllEvents()
        {
            try
            {
                using (_sqlConnection)
                {
                    return _sqlConnection.Query<Event>("SELECT * FROM Event");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public EventDTO GetEventDTOBy(int id)
        {
            try
            {
                using (_sqlConnection)
                {
                    return _sqlConnection.QueryFirst<EventDTO>("SELECT * FROM Event WHERE Id = @Id", new { Id = id });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void InsertEvent(EventDTO eventDTO)
        {
            try
            {
                using (_sqlConnection)
                {
                    _ = _sqlConnection.Execute("INSERT INTO Event (EventLocationId, EventName, EventDate) " +
                        "VALUES(@EventLocationId, @EventName, GETUTCDATE())",
                        new { EventLocationId = new Random().Next(1, 10), EventName = eventDTO.EventName });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void UpdateEvent(EventDTO eventDTO)
        {
            try
            {
                using (_sqlConnection)
                {
                    _sqlConnection.Execute("UPDATE Event SET EventName = @EventName WHERE Id = @Id", new { EventName = eventDTO.EventName, eventDTO.Id });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            _sqlConnection.Close();
        }
    }
}
