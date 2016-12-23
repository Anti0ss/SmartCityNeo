using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetSmartCity.Models
{
    public class AnnonceCreateModel
    {
        public string IdUser { get; set; }
        public int IdCategorie { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public DateTime Date_de_debut { get; set; }
        public DateTime Date_de_fin { get; set; }
        public bool Urgence { get; set; }
        public string Disponibilite { get; set; }
        public string Type { get; set; }
        public string NomObj { get; set; }
        public string Etat { get; set; }
        public string Commentaire { get; set; }
        public AnnonceCreateModel(string idUser, int idCategorie, string nom, string description, DateTime date_de_debut, DateTime date_de_fin, bool urgence, string disponibilite, string type, string nomObj = null, string etat = null, string commentaire = null)
        {
            this.IdUser = idUser;
            this.IdCategorie = idCategorie;
            this.Nom = nom;
            this.Description = description;
            this.Date_de_debut = date_de_debut;
            this.Date_de_fin = date_de_fin;
            this.Urgence = urgence;
            this.Disponibilite = disponibilite;
            this.Type = type;
            this.NomObj = nomObj;
            this.Etat = etat;
            this.Commentaire = commentaire;
        }
        
        
    }
}
