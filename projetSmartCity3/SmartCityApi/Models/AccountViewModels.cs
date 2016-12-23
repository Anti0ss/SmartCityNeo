using System;
using System.Collections.Generic;

namespace SmartCityApi.Models
{
    // Models returned by AccountController actions.

    public class ExternalLoginViewModel
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public string State { get; set; }
    }

    public class ManageInfoViewModel
    {
        public string LocalLoginProvider { get; set; }

        public string Email { get; set; }

        public IEnumerable<UserLoginInfoViewModel> Logins { get; set; }

        public IEnumerable<ExternalLoginViewModel> ExternalLoginProviders { get; set; }
    }

    public class UserInfoViewModel
    {
        public string Email { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        public DateTime Date_de_Naissance { get; set; }

        public string Adr_Numero_de_rue { get; set; }

        public string Adr_Nom_de_Rue { get; set; }

        public int Adr_Code_Postal { get; set; }

        public string Adr_Localite { get; set; }

        public bool HasRegistered { get; set; }

        public string LoginProvider { get; set; }
    }

    public class UserLoginInfoViewModel
    {
        public string LoginProvider { get; set; }

        public string ProviderKey { get; set; }
    }
}
