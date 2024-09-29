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
using MSPersona.Models;

namespace MSPersona.Controllers
{
    public class PersonasTbsController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/PersonasTbs
        public IQueryable<PersonasTb> GetPersonasTb()
        {
            return db.PersonasTb;
        }

        // GET: api/PersonasTbs/5
        [ResponseType(typeof(PersonasTb))]
        public IHttpActionResult GetPersonasTb(int id)
        {
            PersonasTb personasTb = db.PersonasTb.Find(id);
            if (personasTb == null)
            {
                return NotFound();
            }

            return Ok(personasTb);
        }

        // PUT: api/PersonasTbs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPersonasTb(int id, PersonasTb personasTb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personasTb.Id)
            {
                return BadRequest();
            }

            db.Entry(personasTb).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonasTbExists(id))
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

        // POST: api/PersonasTbs
        [ResponseType(typeof(PersonasTb))]
        public IHttpActionResult PostPersonasTb(PersonasTb personasTb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PersonasTb.Add(personasTb);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = personasTb.Id }, personasTb);
        }

        // DELETE: api/PersonasTbs/5
        [ResponseType(typeof(PersonasTb))]
        public IHttpActionResult DeletePersonasTb(int id)
        {
            PersonasTb personasTb = db.PersonasTb.Find(id);
            if (personasTb == null)
            {
                return NotFound();
            }

            db.PersonasTb.Remove(personasTb);
            db.SaveChanges();

            return Ok(personasTb);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonasTbExists(int id)
        {
            return db.PersonasTb.Count(e => e.Id == id) > 0;
        }
    }
}