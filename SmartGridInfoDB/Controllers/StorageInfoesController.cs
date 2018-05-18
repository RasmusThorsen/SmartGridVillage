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
    public class StorageInfoesController : ApiController
    {
        private SmartGridInfoDBContext db = new SmartGridInfoDBContext();

        // GET: api/StorageInfoes
        public IQueryable<StorageInfo> GetStorageInfoes()
        {
            return db.StorageInfoes;
        }

        // GET: api/StorageInfoes/5
        [ResponseType(typeof(StorageInfo))]
        public IHttpActionResult GetStorageInfo(int id)
        {
            StorageInfo storageInfo = db.StorageInfoes.Find(id);
            if (storageInfo == null)
            {
                return NotFound();
            }

            return Ok(storageInfo);
        }

        // PUT: api/StorageInfoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStorageInfo(int id, StorageInfo storageInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != storageInfo.StorageId)
            {
                return BadRequest();
            }

            db.Entry(storageInfo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StorageInfoExists(id))
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

        // POST: api/StorageInfoes
        [ResponseType(typeof(StorageInfo))]
        public IHttpActionResult PostStorageInfo(StorageInfo storageInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StorageInfoes.Add(storageInfo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = storageInfo.StorageId }, storageInfo);
        }

        // DELETE: api/StorageInfoes/5
        [ResponseType(typeof(StorageInfo))]
        public IHttpActionResult DeleteStorageInfo(int id)
        {
            StorageInfo storageInfo = db.StorageInfoes.Find(id);
            if (storageInfo == null)
            {
                return NotFound();
            }

            db.StorageInfoes.Remove(storageInfo);
            db.SaveChanges();

            return Ok(storageInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StorageInfoExists(int id)
        {
            return db.StorageInfoes.Count(e => e.StorageId == id) > 0;
        }
    }
}