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
using MicroServicioReceta.Models;

namespace MicroServicioReceta.Controllers
{
    public class RecetasTbsController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/RecetasTbs
        public IQueryable<RecetasTb> GetRecetasTb()
        {
            return db.RecetasTb;
        }

        // GET: api/RecetasTbs/5
        [ResponseType(typeof(RecetasTb))]
        public IHttpActionResult GetRecetasTb(int id)
        {
            RecetasTb recetasTb = db.RecetasTb.Find(id);
            if (recetasTb == null)
            {
                return NotFound();
            }

            return Ok(recetasTb);
        }

        // PUT: api/RecetasTbs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRecetasTb(int id, RecetasTb recetasTb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != recetasTb.RecetasId)
            {
                return BadRequest();
            }

            db.Entry(recetasTb).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecetasTbExists(id))
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

        // POST: api/RecetasTbs
        [ResponseType(typeof(RecetasTb))]
        public IHttpActionResult PostRecetasTb(RecetasTb recetasTb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RecetasTb.Add(recetasTb);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = recetasTb.RecetasId }, recetasTb);
        }

        // DELETE: api/RecetasTbs/5
        [ResponseType(typeof(RecetasTb))]
        public IHttpActionResult DeleteRecetasTb(int id)
        {
            RecetasTb recetasTb = db.RecetasTb.Find(id);
            if (recetasTb == null)
            {
                return NotFound();
            }

            db.RecetasTb.Remove(recetasTb);
            db.SaveChanges();

            return Ok(recetasTb);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RecetasTbExists(int id)
        {
            return db.RecetasTb.Count(e => e.RecetasId == id) > 0;
        }
    }
}