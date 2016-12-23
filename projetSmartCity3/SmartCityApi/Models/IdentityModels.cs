using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Data.Entity;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartCityApi.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {   
        //Attention problème pas de key primaire!!!
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime? Date_de_Naissance { get; set; }
        public string Adr_Numero_de_rue { get; set; }
        public string Adr_Nom_de_Rue { get; set; }
        public int Adr_Code_Postal { get; set; }
        public string Adr_Localite { get; set; }
        public int Numero_de_Telephone { get; set; }
        public int NbPoints { get; set; }
        

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }
    public class Objet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Objet { get; set; }
        public string Nom { get; set; }
        public string Etat { get; set; }
        public string Commentaire { get; set; }
        

    }
    public class Categorie
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCategorie { get; set; }
        [Required]
        public string Libelle { get; set; }
      

    }
   
    public class Annonce
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Annonce { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public DateTime Date_de_debut { get; set; }
        public DateTime Date_de_fin { get; set; }
        public bool Urgence { get; set; }
        public string Disponibilite { get; set; }
        public string Type { get; set; }
        public virtual ApplicationUser Utilisateur { get; set; }
        public virtual Categorie Categorie { get; set; }
        public virtual Objet Objet { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }

    }
    public class AnnonceCreateModel
    {
       
        public string IdUser { get; set; }
        public int IdCategorie { get; set; }
        public int IdSousCategorie { get; set; }
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
        
    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
        {
           
            // constructeur provenant de SmartCityContext    
            //DbSet provenant de SmartCityContext 

            public DbSet<Annonce> Annonce { get; set; }
            public DbSet<Categorie> Categorie { get; set; }
            public DbSet<Objet> Objet { get; set; }
            public ApplicationDbContext() : 
            base("AzureConnection", throwIfV1Schema: false)
            {
               
                
                 //Database.SetInitializer<ApplicationDbContext>(new DropCreateDatabaseAlways<ApplicationDbContext>());
            
             }


            public static ApplicationDbContext Create()
            {
                return new ApplicationDbContext();
            }

        
    }
}