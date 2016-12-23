using SmartCityApi.Models;
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


namespace SmartCityApi.Controllers
{
    public class CategoriesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        

        // GET: api/Categories
        public IEnumerable<Categorie> GetCategorie()

        {
            if(db.Categorie.Count() == 0)
            {
                Categorie cat = new Categorie() { Libelle = "peinture" };
                Categorie cat2 = new Categorie() { Libelle = "bricolage" };
                Categorie cat3 = new Categorie() { Libelle = "xxx" };
                db.Categorie.Add(cat);
                db.Categorie.Add(cat2);
                db.Categorie.Add(cat3);
                db.SaveChanges();
            }
            return db.Categorie.ToList();
        }

        // GET: api/Categories/5
        [ResponseType(typeof(Categorie))]
        public async Task<IHttpActionResult> GetCategorie(string id)
        {
            Categorie categorie = await db.Categorie.FindAsync(id);
            if (categorie == null)
            {
                return NotFound();
            }

            return Ok(categorie);
        }

        // PUT: api/Categories/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCategorie(string id, Categorie categorie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categorie.Libelle)
            {
                return BadRequest();
            }

            db.Entry(categorie).State = System.Data.Entity.EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategorieExists(id))
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

        // POST: api/Categories
        [ResponseType(typeof(Categorie))]
        public async Task<IHttpActionResult> PostCategorie(Categorie categorie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Categorie.Add(categorie);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CategorieExists(categorie.Libelle))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = categorie.Libelle }, categorie);
        }

        // DELETE: api/Categories/5
        [ResponseType(typeof(Categorie))]
        public async Task<IHttpActionResult> DeleteCategorie(string id)
        {
            Categorie categorie = await db.Categorie.FindAsync(id);
            if (categorie == null)
            {
                return NotFound();
            }

            db.Categorie.Remove(categorie);
            await db.SaveChangesAsync();

            return Ok(categorie);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategorieExists(string id)
        {
            return db.Categorie.Count(e => e.Libelle == id) > 0;
        }
    }
}