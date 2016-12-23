using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetSmartCity.Models
{
    public class ApplicationUser
    {


        
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime Date_de_Naissance { get; set; }
        public string Adr_Numero_de_rue { get; set; }
        public string Adr_Nom_de_Rue { get; set; }
        public int Adr_Code_Postal { get; set; }
        public string Adr_Localite { get; set; }
        public string Numero_de_Telephone { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public int NbPoints { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public object LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string Id { get; set; }
        public string UserName { get; set; }

        //public string RowVersion { get; set; }

    }
}


