using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using IRLWeather.Models;

namespace IRLWeather.Controllers
{
    // ../weather/..                                       // using attribute based routing
    [RoutePrefix("weathers")]
    public class WeathersController : ApiController
    {
        private IRLWeatherContext db = new IRLWeatherContext();

        // get data about all weather
        // GET:/Weathers/all
        [Route("all")]
        public IQueryable<Weather> GetWeathers()
        {
            return db.Weathers;
        }

        // GET: api/Weathers/5
        [ResponseType(typeof(Weather))]
        public IHttpActionResult GetWeather(int id)
        {
            Weather weather = db.Weathers.Find(id);
            if (weather == null)
            {
                return NotFound();
            }

            return Ok(weather);
        }

        // Get weathers for a specified city to be returned (having same specified routing key)
        // GET: Weathers/city/Belfast
        // GET: Weathers/city/Cork
        // GET: Weathers/city/Donnegal
        // GET: Weathers/city/Dublin
        // GET: Weathers/city/Galway
        // GET: Weathers/city/Limerick
        // GET: Weathers/city/Waterford
        [Route("city/{city}")]
        [ResponseType(typeof(Weather))]
        public IHttpActionResult GetWeatherByCity(String city)
        {
            // LINQ query 
            IEnumerable<Weather> weather = db.Weathers.Where(w => w.City.ToUpper() == city.ToUpper());

            if (weather == null)
            {
                return NotFound();
            }

            return Ok(weather);
        }

        // PUT: api/Weathers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWeather(int id, Weather weather)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != weather.Id)
            {
                return BadRequest();
            }

            db.Entry(weather).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeatherExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Weathers
        [ResponseType(typeof(Weather))]
        public IHttpActionResult PostWeather(Weather weather)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Weathers.Add(weather);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = weather.Id }, weather);
        }

        // DELETE: api/Weathers/5
        [ResponseType(typeof(Weather))]
        public IHttpActionResult DeleteWeather(int id)
        {
            Weather weather = db.Weathers.Find(id);
            if (weather == null)
            {
                return NotFound();
            }

            db.Weathers.Remove(weather);
            db.SaveChanges();

            return Ok(weather);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WeatherExists(int id)
        {
            return db.Weathers.Count(e => e.Id == id) > 0;
        }
    }
}