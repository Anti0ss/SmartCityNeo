using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetSmartCity
{
    interface Annonce
    {
        long idAnnonce { get; set; }
        String nom { get; set; }
        String description { get; set; }
        DateTime dateDebut { get; set; }
        DateTime dateFin { get; set; }
        String commentaire { get; set; }
        bool disponibilite { get; set; }
       
    }
}
