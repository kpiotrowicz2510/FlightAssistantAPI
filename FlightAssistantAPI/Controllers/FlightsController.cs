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
                    for(int i = 1; i < flightData.Events.Count-1; i++)
                    {
                        if (flightData.Events[i-1].IsDone&&flightData.Events[i+1].IsPending)
                        {
                            flightData.Events[i].IsActive = true;
                        }
                        
                    }
                    return Ok(flightData);
                }
            }
            //nie
            return NotFound();
        }


    }
}
