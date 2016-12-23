using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetSmartCity
{
    class User
    {
        public long idUtilisateur { get; set; }
        public String nom { get; set; }
        public String prenom { get; set; }
        public DateTime dateNaiss { get; set; }
        public String numRue { get; set; }
        public String nomRue { get; set; }
        public int codePostal { get; set; }
        public String localite { get; set; }
        public String mail { get; set; }
        public int numTel { get; set; }
        public String mdp { get; set; }
        public double coordGPS { get; set; }
        public int nbPoints { get; set; }
    }
}
