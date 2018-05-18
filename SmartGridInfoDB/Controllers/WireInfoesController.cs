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
    public class WireInfoesController : ApiController
    {
        private SmartGridInfoDBContext db = new SmartGridInfoDBContext();

        // GET: api/WireInfoes
        public IQueryable<WireInfo> GetWireInfoes()
        {
            return db.WireInfoes;
        }

        // GET: api/WireInfoes/5
        [ResponseType(typeof(WireInfo))]
        public IHttpActionResult GetWireInfo(int id)
        {
            WireInfo wireInfo = db.WireInfoes.Find(id);
            if (wireInfo == null)
            {
                return NotFound();
            }

            return Ok(wireInfo);
        }

        // PUT: api/WireInfoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWireInfo(int id, WireInfo wireInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != wireInfo.WireId)
            {
                return BadRequest();
            }

            db.Entry(wireInfo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WireInfoExists(id))
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

        // POST: api/WireInfoes
        [ResponseType(typeof(WireInfo))]
        public IHttpActionResult PostWireInfo(WireInfo wireInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.WireInfoes.Add(wireInfo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = wireInfo.WireId }, wireInfo);
        }

        // DELETE: api/WireInfoes/5
        [ResponseType(typeof(WireInfo))]
        public IHttpActionResult DeleteWireInfo(int id)
        {
            WireInfo wireInfo = db.WireInfoes.Find(id);
            if (wireInfo == null)
            {
                return NotFound();
            }

            db.WireInfoes.Remove(wireInfo);
            db.SaveChanges();

            return Ok(wireInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WireInfoExists(int id)
        {
            return db.WireInfoes.Count(e => e.WireId == id) > 0;
        }
    }
}