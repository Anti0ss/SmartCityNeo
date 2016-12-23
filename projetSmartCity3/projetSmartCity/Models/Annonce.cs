using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetSmartCity.Models
{
    public class Annonce
    {

        
        [Key]
        public int Id_Annonce { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public DateTime Date_de_debut { get; set; }
        public DateTime Date_de_fin { get; set; }
        public bool Urgence { get; set; }
        public string Disponibilite { get; set; }
        public string Type { get; set; }
        public ApplicationUser Utilisateur { get; set; }
        public Categorie Categorie { get; set; }
        public Objet Objet { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
        public Annonce( string Nom, string Description, DateTime Date_de_debut, DateTime Date_de_fin, bool Urgence, string Disponibilite, string Type, ApplicationUser Utilisateur,Categorie Categorie,Objet objet)
        {
            this.Nom = Nom;
            this.Description = Description;
            this.Date_de_debut = Date_de_debut;
            this.Date_de_fin = Date_de_fin;
            this.Urgence = Urgence;
            this.Disponibilite = Disponibilite;
            this.Type = Type;
            this.Utilisateur = Utilisateur;
            this.Categorie = Categorie;
            this.Objet = objet;
          
            
        }

    }
}
