using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using SmartCityApi.Models;

namespace SmartCityApi.Controllers
{
    public class ObjetsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Objets
        public IEnumerable<Objet> GetObjet()
        {
            return db.Objet.ToList();
        }

        // GET: api/Objets/5
        [ResponseType(typeof(Objet))]
        public async Task<IHttpActionResult> GetObjet(int id)
        {
            Objet objet = await db.Objet.FindAsync(id);
            if (objet == null)
            {
                return NotFound();
            }

            return Ok(objet);
        }

        // PUT: api/Objets/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutObjet(int id, Objet objet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != objet.Id_Objet)
            {
                return BadRequest();
            }

            db.Entry(objet).State = System.Data.Entity.EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObjetExists(id))
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

        // POST: api/Objets
        [ResponseType(typeof(Objet))]
        public async Task<IHttpActionResult> PostObjet(Objet objet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Objet.Add(objet);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = objet.Id_Objet }, objet);
        }

        // DELETE: api/Objets/5
        [ResponseType(typeof(Objet))]
        public async Task<IHttpActionResult> DeleteObjet(int id)
        {
            Objet objet = await db.Objet.FindAsync(id);
            if (objet == null)
            {
                return NotFound();
            }

            db.Objet.Remove(objet);
            await db.SaveChangesAsync();

            return Ok(objet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ObjetExists(int id)
        {
            return db.Objet.Count(e => e.Id_Objet == id) > 0;
        }
    }
}