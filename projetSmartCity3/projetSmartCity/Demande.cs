using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetSmartCity
{
    class Demande : Annonce
    {
        public long idAnnonce { get; set; }
        public String nom { get; set; }
        public String description { get; set; }
        public DateTime dateDebut { get; set; }
        public DateTime dateFin { get; set; }
        public String commentaire { get; set; }
        public bool disponibilite { get; set; }
        public bool urgence{ get; set; }
    
    }
}
