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
               return Ok(db.Flights.Where(flight => flight.ID == id).FirstOrDefault());
            }

            return NotFound();
        }


    }
}
