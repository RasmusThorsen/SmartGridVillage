using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SmartGridInfoDB.Models;

namespace SmartGridInfoDB.Controllers
{
    public class SmartMetersController : ApiController
    {
        private SmartGridInfoDBContext db = new SmartGridInfoDBContext();

        // GET: api/SmartMeters
        public IQueryable<SmartMeter> GetSmartMeters()
        {
            return db.SmartMeters;
        }

        // GET: api/SmartMeters/5
        [ResponseType(typeof(SmartMeter))]
        public IHttpActionResult GetSmartMeter(int id)
        {
            var smartMeter = db.SmartMeters.Include(s => s.Adress).Select(s => new SmartMeterDTO()
            {
                City = s.Adress.City,
                Housenumber = s.Adress.Housenumber,
                Manufacturer = s.Manufacturer,
                PostalCode = s.Adress.PostalCode,
                SerialId = s.SerialId,
                Streetname = s.Adress.Streetname
            });

            if (smartMeter == null)
            {
                return NotFound();
            }

            return Ok(smartMeter);
        }

        // PUT: api/SmartMeters/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSmartMeter(int id, SmartMeter smartMeter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != smartMeter.SmartMeterId)
            {
                return BadRequest();
            }

            db.Entry(smartMeter).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SmartMeterExists(id))
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

        // POST: api/SmartMeters
        [ResponseType(typeof(SmartMeter))]
        public IHttpActionResult PostSmartMeter(SmartMeter smartMeter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SmartMeters.Add(smartMeter);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = smartMeter.SmartMeterId }, smartMeter);
        }

        // DELETE: api/SmartMeters/5
        [ResponseType(typeof(SmartMeter))]
        public IHttpActionResult DeleteSmartMeter(int id)
        {
            SmartMeter smartMeter = db.SmartMeters.Find(id);

            if (smartMeter == null)
            {
                return NotFound();
            }

            db.Adresses.Remove(smartMeter.Adress);
            db.SmartMeters.Remove(smartMeter);
            db.SaveChanges();

            return Ok(smartMeter);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SmartMeterExists(int id)
        {
            return db.SmartMeters.Count(e => e.SmartMeterId == id) > 0;
        }
    }
}