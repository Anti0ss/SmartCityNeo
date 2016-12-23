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
using System.Security.Claims;

namespace SmartCityApi.Controllers
{
    public class AnnoncesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: api/Annonces
        public IEnumerable<Annonce> GetAnnonces()
        {
            return db.Annonce.ToList();
        }

        // GET: api/Annonces/5
        [ResponseType(typeof(Annonce))]
        public async Task<IHttpActionResult> GetAnnonce(int id)
        {
            Annonce annonce = await db.Annonce.FindAsync(id);
            if (annonce == null)
            {
                return NotFound();
            }

            return Ok(annonce);
        }

        // PUT: api/Annonces/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAnnonce(int id, Annonce annonce)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != annonce.Id_Annonce)
            {
                return BadRequest();
            }

            db.Entry(annonce).State = System.Data.Entity.EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnnonceExists(id))
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

        // POST: api/Annonces
        [ResponseType(typeof(Annonce))]
        public async Task<IHttpActionResult> PostAnnonce(AnnonceCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var identity = User.Identity as ClaimsIdentity;
            Claim identityClaim = identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            ApplicationUser user = db.Users.FirstOrDefault(u => u.Id == identityClaim.Value);
            Annonce annonce = new Annonce() { Nom=model.Nom,Description=model.Description,Date_de_debut=model.Date_de_debut,Date_de_fin=model.Date_de_fin,Urgence=model.Urgence,Disponibilite=model.Disponibilite,Type=model.Type};
            annonce.Objet = new Objet() { Nom = model.NomObj, Etat = model.Etat, Commentaire = model.Commentaire };
            annonce.Utilisateur = user;
            annonce.Categorie = await db.Categorie.FindAsync(model.IdCategorie);
            db.Annonce.Add(annonce);
            await db.SaveChangesAsync();
            
           

            return Created("api/Annonces", annonce);
        }

        // DELETE: api/Annonces/5
        [ResponseType(typeof(Annonce))]
        public async Task<IHttpActionResult> DeleteAnnonce(int id)
        {
            Annonce annonce = await db.Annonce.FindAsync(id);
            if (annonce == null)
            {
                return NotFound();
            }

            db.Annonce.Remove(annonce);
            await db.SaveChangesAsync();

            return Ok(annonce);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AnnonceExists(int id)
        {
            return db.Annonce.Count(e => e.Id_Annonce == id) > 0;
        }
    }
}