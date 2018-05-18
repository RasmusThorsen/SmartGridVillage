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
    public class SmartGridInfoesController : ApiController
    {
        private SmartGridInfoDBContext db = new SmartGridInfoDBContext();

        // GET: api/SmartGridInfoes
        public IQueryable<SmartGridInfo> GetSmartGridInfoes()
        {
            return db.SmartGridInfoes;
        }

        // GET: api/SmartGridInfoes/5
        [ResponseType(typeof(SmartGridInfo))]
        public IHttpActionResult GetSmartGridInfo(int id)
        {
            SmartGridInfo smartGridInfo = db.SmartGridInfoes.Find(id);
            if (smartGridInfo == null)
            {
                return NotFound();
            }

            return Ok(smartGridInfo);
        }

        // PUT: api/SmartGridInfoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSmartGridInfo(int id, SmartGridInfo smartGridInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != smartGridInfo.SmartGridId)
            {
                return BadRequest();
            }

            db.Entry(smartGridInfo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SmartGridInfoExists(id))
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

        // POST: api/SmartGridInfoes
        [ResponseType(typeof(SmartGridInfo))]
        public IHttpActionResult PostSmartGridInfo(SmartGridInfo smartGridInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SmartGridInfoes.Add(smartGridInfo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = smartGridInfo.SmartGridId }, smartGridInfo);
        }

        // DELETE: api/SmartGridInfoes/5
        [ResponseType(typeof(SmartGridInfo))]
        public IHttpActionResult DeleteSmartGridInfo(int id)
        {
            SmartGridInfo smartGridInfo = db.SmartGridInfoes.Find(id);
            if (smartGridInfo == null)
            {
                return NotFound();
            }

            db.SmartGridInfoes.Remove(smartGridInfo);
            db.SaveChanges();

            return Ok(smartGridInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SmartGridInfoExists(int id)
        {
            return db.SmartGridInfoes.Count(e => e.SmartGridId == id) > 0;
        }
    }
}