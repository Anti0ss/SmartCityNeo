using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetSmartCity.Models
{

    public class Utilisateur
    {


        [Key]
        public string Email { get; set; }
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


        [Timestamp]
        public byte[] RowVersion { get; set; }

        public Utilisateur( string Adresse_mail, string Nom, string Prenom, DateTime Date_de_Naissance, string Adr_Numero_de_rue, string Adr_Nom_de_Rue, int Adr_Code_Postal, string Adr_Localite, string Numero_de_Telephone,string Mot_de_passe,string Mot_de_passe2,int NbPoints=0)
        {
            this.Email = Adresse_mail;
            this.Nom = Nom;
            this.Prenom = Prenom;
            this.Date_de_Naissance = Date_de_Naissance;
            this.Adr_Numero_de_rue = Adr_Numero_de_rue;
            this.Adr_Nom_de_Rue = Adr_Nom_de_Rue;
            this.Adr_Code_Postal = Adr_Code_Postal;
            this.Adr_Localite = Adr_Localite;
            this.Numero_de_Telephone = Numero_de_Telephone;
            this.Password = Mot_de_passe;
            this.ConfirmPassword = Mot_de_passe2;
           
        }
       


    }
}

