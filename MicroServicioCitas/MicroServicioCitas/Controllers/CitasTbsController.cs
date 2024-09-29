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
using MicroServicioCitas.Models;

namespace MicroServicioCitas.Controllers
{
    public class CitasTbsController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/CitasTbs
        public IQueryable<CitasTb> GetCitasTb()
        {
            return db.CitasTb;
        }

        // GET: api/CitasTbs/5
        [ResponseType(typeof(CitasTb))]
        public IHttpActionResult GetCitasTb(int id)
        {
            CitasTb citasTb = db.CitasTb.Find(id);
            if (citasTb == null)
            {
                return NotFound();
            }

            return Ok(citasTb);
        }

        // PUT: api/CitasTbs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCitasTb(int id, CitasTb citasTb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != citasTb.CitasId)
            {
                return BadRequest();
            }

            db.Entry(citasTb).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CitasTbExists(id))
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

        // POST: api/CitasTbs
        [ResponseType(typeof(CitasTb))]
        public IHttpActionResult PostCitasTb(CitasTb citasTb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CitasTb.Add(citasTb);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = citasTb.CitasId }, citasTb);
        }

        // DELETE: api/CitasTbs/5
        [ResponseType(typeof(CitasTb))]
        public IHttpActionResult DeleteCitasTb(int id)
        {
            CitasTb citasTb = db.CitasTb.Find(id);
            if (citasTb == null)
            {
                return NotFound();
            }

            db.CitasTb.Remove(citasTb);
            db.SaveChanges();

            return Ok(citasTb);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CitasTbExists(int id)
        {
            return db.CitasTb.Count(e => e.CitasId == id) > 0;
        }



    }
}