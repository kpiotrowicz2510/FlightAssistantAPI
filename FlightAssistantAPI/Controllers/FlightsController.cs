using FlightAssistantAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FlightAssistantAPI.Controllers
{
    [RoutePrefix("flights")]
    public class FlightsController : ApiController
    {
        [HttpGet]
        [Route("flight/{id}")]
        public IHttpActionResult GetFlight(int id)
        {
            using (var db = new FlightAssistantContext())
            {
                var flightData = db.Flights.Include("StartAirport").Include("EndAirport").Include("Events").Where(flight => flight.ID == id).First();
                if (flightData != null)
                {
                    return Ok(flightData);
                }
            }

            return NotFound();
        }


    }
}
