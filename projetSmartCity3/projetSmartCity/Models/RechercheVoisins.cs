using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetSmartCity.Models
{
    public class RechercheVoisins
    {
        public string Nom { get; set; }
        public string Type { get; set; }
        public string Disponibilite { get; set; }
        public Categorie Categorie { get; set; }

        public RechercheVoisins(string nom,string type,string disponibilite, Categorie categorie)
        {
            this.Nom = nom;
            this.Type = type;
            this.Disponibilite = disponibilite;
            this.Categorie = categorie;
        }
    }
}
