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
            if (id != prosumerInfo.ProsumerID)
            {
                return BadRequest();
            }

            ProsumerInfo prosumer = db.ProsumerInfoes.Find(id);
            
            //For Prosumer
            prosumer.Type = prosumerInfo.Type;

            //Prosumer Address
            prosumer.Address.Street = prosumerInfo.Address.Street;
            prosumer.Address.City = prosumerInfo.Address.City;
            prosumer.Address.Country = prosumerInfo.Address.Country;
            prosumer.Address.ZipCode = prosumerInfo.Address.ZipCode;
            prosumer.Address.HouseNumber = prosumerInfo.Address.HouseNumber;

            //Prosumer Owner
            prosumer.Owner.FirstName = prosumerInfo.Owner.FirstName;
            prosumer.Owner.MiddleName = prosumerInfo.Owner.MiddleName;
            prosumer.Owner.LastName = prosumerInfo.Owner.LastName;
            prosumer.Owner.Email = prosumerInfo.Owner.Email;
            prosumer.Owner.PhoneNumber = prosumerInfo.Owner.PhoneNumber;

            //Prosumer Production
            prosumer.Production.AverageProduction = prosumerInfo.Production.AverageProduction;
            prosumer.Production.AverageConsumer = prosumerInfo.Production.AverageConsumer;
            prosumer.Production.Balance = prosumerInfo.Production.Balance;

            for (int i = 0; i < prosumer.Production.EnergySources.Count; i++)
            {
                prosumer.Production.EnergySources[i].Source = prosumerInfo.Production.EnergySources[i].Source;
            }

            //Prosumer Production Energysources
            if (prosumer.Production.EnergySources.Count != prosumerInfo.Production.EnergySources.Count)
            {
                for (int i = prosumer.Production.EnergySources.Count; i < prosumerInfo.Production.EnergySources.Count; i++)
                {
                    prosumer.Production.EnergySources.Add(new EnergySource()
                    {
                        Source = prosumerInfo.Production.EnergySources[i].Source
                    });
                }
            }

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

            db.Owners.Remove(prosumerInfo.Owner);
            db.EnergySources.RemoveRange(prosumerInfo.Production.EnergySources);
            db.Productions.Remove(prosumerInfo.Production);
            db.Addresses.Remove(prosumerInfo.Address);
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