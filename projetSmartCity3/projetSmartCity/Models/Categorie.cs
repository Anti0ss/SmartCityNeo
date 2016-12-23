using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetSmartCity.Models
{
    public class Categorie
    {
        
        [Key]
        public int IdCategorie { get; set; }
        public string Libelle { get; set; }
       
        [Timestamp]
        public byte[] RowVersion { get; set; }

        


    }
}
