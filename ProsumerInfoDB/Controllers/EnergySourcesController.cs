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
using ProsumerInfoDB.Models;

namespace ProsumerInfoDB.Controllers
{
    public class EnergySourcesController : ApiController
    {
        private ProsumerInfoDBContext db = new ProsumerInfoDBContext();

        // GET: api/EnergySources
        public IQueryable<EnergySource> GetEnergySources()
        {
            return db.EnergySources;
        }

        // GET: api/EnergySources/5
        [ResponseType(typeof(EnergySource))]
        public IHttpActionResult GetEnergySource(int id)
        {
            EnergySource energySource = db.EnergySources.Find(id);
            if (energySource == null)
            {
                return NotFound();
            }

            return Ok(energySource);
        }

        // PUT: api/EnergySources/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEnergySource(int id, EnergySource energySource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != energySource.EnergyID)
            {
                return BadRequest();
            }

            db.Entry(energySource).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnergySourceExists(id))
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

        // POST: api/EnergySources
        [ResponseType(typeof(EnergySource))]
        public IHttpActionResult PostEnergySource(EnergySource energySource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EnergySources.Add(energySource);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = energySource.EnergyID }, energySource);
        }

        // DELETE: api/EnergySources/5
        [ResponseType(typeof(EnergySource))]
        public IHttpActionResult DeleteEnergySource(int id)
        {
            EnergySource energySource = db.EnergySources.Find(id);
            if (energySource == null)
            {
                return NotFound();
            }

            db.EnergySources.Remove(energySource);
            db.SaveChanges();

            return Ok(energySource);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EnergySourceExists(int id)
        {
            return db.EnergySources.Count(e => e.EnergyID == id) > 0;
        }
    }
}