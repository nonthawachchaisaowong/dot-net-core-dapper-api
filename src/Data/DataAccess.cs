using Dapper.Contrib.Extensions;
using EventTracker.Models;
using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EventTracker.Data
{
    public class DataAccess : IDataAccess, IDisposable
    {
        private readonly string _connectionString;
        private IDbConnection _sqlConnection;      

        public DataAccess(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("Default");            
        }

        private IDbConnection GetConnection()
        { 
            return new SqlConnection(_connectionString);
        }

        public void Dispose()
        {
            _sqlConnection.Close();
        }

        public IEnumerable<Event> GetAll()
        {
            try
            {
                using (_sqlConnection = GetConnection())
                {
                    _sqlConnection.Open();
                    var events = _sqlConnection.GetAll<Event>();
                    return events;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Event Get(int id)
        {
            try
            {
                using (var _sqlConnection = GetConnection())
                {
                    _sqlConnection.Open();
                    var e = _sqlConnection.Get<Event>(id);
                    return e;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert(Event e)
        {
            // Assign some value
            e.EventDate = DateTime.Now;
            e.EventLocationId = new Random().Next(1, 10);

            try
            {
                using (_sqlConnection = new SqlConnection(_connectionString))
                {
                    _sqlConnection.Open();
                    _sqlConnection.Insert(e);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Event e)
        {
            try
            {
                using (_sqlConnection = GetConnection())
                {
                    _sqlConnection.Open();
                    _sqlConnection.Update(e);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int id)
        {
            try
            {
                using (_sqlConnection = GetConnection())
                {
                    _sqlConnection.Open();
                    _sqlConnection.Delete(new Event { Id = id });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }       
    }
}
