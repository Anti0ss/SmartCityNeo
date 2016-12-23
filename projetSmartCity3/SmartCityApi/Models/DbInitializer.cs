using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;

namespace SmartCityApi.Models
{
    class DbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            Categorie Categorie1 = new Categorie()
            {
                Libelle = "Peinture"
            };
            Categorie Categorie2 = new Categorie()
            {
                Libelle = "Outils"
            };
            Categorie Categorie3 = new Categorie()
            {
                Libelle = "Ustensiles de cuisine"
            };
            Categorie Categorie4 = new Categorie()
            {
                Libelle = "Matérielle scolaire"
            };
            Categorie Categorie5 = new Categorie()
            {
                Libelle = "Syllabus/Livre de cours"
            };
            Categorie Categorie6 = new Categorie()
            {
                Libelle = "Matériaux de construction"
            };
            Categorie Categorie7 = new Categorie()
            {
                Libelle = "Bricolage"
               
            };
            Categorie Categorie8 = new Categorie()
            {
                Libelle = "Cuisine"
            
            };
            Categorie Categorie9 = new Categorie()
            {
                Libelle = "Jardinage"
            };
            Categorie Categorie10 = new Categorie()
            {
                Libelle = "Jeux videos"
            };
            Categorie Categorie11 = new Categorie()
            {
                Libelle = "Littérature"
            };
            Categorie Categorie12 = new Categorie()
            {
                Libelle = "Jeux de société"
            };

            context.Categorie.Add(Categorie1);
            context.Categorie.Add(Categorie2);
            context.Categorie.Add(Categorie3);
            context.Categorie.Add(Categorie4);
            context.Categorie.Add(Categorie5);
            context.Categorie.Add(Categorie6);
            context.Categorie.Add(Categorie7);
            context.Categorie.Add(Categorie8);
            context.Categorie.Add(Categorie9);
            context.Categorie.Add(Categorie10);
            context.Categorie.Add(Categorie11);
            context.Categorie.Add(Categorie12);
            context.SaveChanges();
        }
    }
}