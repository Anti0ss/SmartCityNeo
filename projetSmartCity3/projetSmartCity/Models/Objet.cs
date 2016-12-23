using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetSmartCity.Models
{

    public class Objet
    {
        [Key]
        public int Id_Objet { get; set; }
        public string Nom { get; set; }
        public string Etat { get; set; }
        public string Commentaire { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }

    }
}
