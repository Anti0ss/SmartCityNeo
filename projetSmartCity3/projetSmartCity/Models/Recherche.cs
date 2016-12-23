using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetSmartCity.Models
{
    public class Recherche
    {
        public string Nom { get; set; }
        public bool Urgence { get; set; }
        public string Disponibilite { get; set; }
        public Categorie Categorie { get; set; }

        public Recherche(string nom, bool urgence, string disponibilite, Categorie categorie)
        {
            this.Nom = nom;
            this.Urgence = urgence;
            this.Disponibilite = disponibilite;
            this.Categorie = categorie;
        }
    }
}
