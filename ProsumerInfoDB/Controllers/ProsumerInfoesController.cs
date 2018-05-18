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
    public class ProsumerInfoesController : ApiController
    {
        private ProsumerInfoDBContext db = new ProsumerInfoDBContext();

        // GET: api/ProsumerInfoes
        public IQueryable<ProsumerInfo> GetProsumerInfoes()
        {
            return db.ProsumerInfoes;
        }

        // GET: api/ProsumerInfoes/5
        [ResponseType(typeof(ProsumerInfo))]
        public IHttpActionResult GetProsumerInfo(int id)
        {
            ProsumerInfo prosumerInfo = db.ProsumerInfoes.Find(id);
            if (prosumerInfo == null)
            {
                return NotFound();
            }

            return Ok(prosumerInfo);
        }

        // PUT: api/ProsumerInfoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProsumerInfo(int id, ProsumerInfo prosumerInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prosumerInfo.ProsumerID)
            {
                return BadRequest();
            }

            db.Entry(prosumerInfo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProsumerInfoExists(id))
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

        // POST: api/ProsumerInfoes
        [ResponseType(typeof(ProsumerInfo))]
        public IHttpActionResult PostProsumerInfo(ProsumerInfo prosumerInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProsumerInfoes.Add(prosumerInfo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = prosumerInfo.ProsumerID }, prosumerInfo);
        }

        // DELETE: api/ProsumerInfoes/5
        [ResponseType(typeof(ProsumerInfo))]
        public IHttpActionResult DeleteProsumerInfo(int id)
        {
            ProsumerInfo prosumerInfo = db.ProsumerInfoes.Find(id);
            if (prosumerInfo == null)
            {
                return NotFound();
            }

            db.ProsumerInfoes.Remove(prosumerInfo);
            db.SaveChanges();

            return Ok(prosumerInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProsumerInfoExists(int id)
        {
            return db.ProsumerInfoes.Count(e => e.ProsumerID == id) > 0;
        }
    }
}