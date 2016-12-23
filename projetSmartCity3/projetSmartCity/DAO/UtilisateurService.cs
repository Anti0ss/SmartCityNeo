using Newtonsoft.Json;
using projetSmartCity.Error;
using projetSmartCity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace projetSmartCity.DAO
{
    class UtilisateurService
    {
        private HttpClient pc;
        private ApplicationError erreur;

        public UtilisateurService()
        {
            pc = new HttpClient();
            erreur = new ApplicationError();
        }


        public async Task<ApplicationUser> GetUtilisateur()
        {
            pc.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AppApi.Token);
            var json = await pc.GetStringAsync(new Uri(AppApi.AddresseApi + "/api/Account/UtilisateurInfos"));
            ApplicationUser dataRetour = JsonConvert.DeserializeObject<ApplicationUser>(json);
            return dataRetour;
        }

        public async Task<ApplicationError> PostUtilisateur(RegisterBindingModel u)
        {
            pc.BaseAddress = new Uri(AppApi.AddresseApi + "/api/Account/Register");
            
            try
            {
              
                var reponse = pc.PostAsJsonAsync(pc.BaseAddress, u).Result;
                if (reponse.IsSuccessStatusCode)
                {
                    erreur.errorMessage = reponse.Content.ReadAsStringAsync().Result;
                    erreur.ok = reponse.IsSuccessStatusCode;
                    return erreur;
                }
                else
                {
                    erreur.errorMessage = reponse.Content.ReadAsStringAsync().Result;
                    erreur.ok = reponse.IsSuccessStatusCode;
                    return erreur;
                }

            }
            catch(Exception e)
            {
                erreur.errorMessage = e.ToString();
                erreur.ok = false;
                return erreur;
            }

        }
        public async Task<ApplicationError> GetToken(string email, string mdp)
        {
            var form = new Dictionary<string, string>
            {
                {"grant_type","password"},
                {"username",email},
                {"password",mdp},
            };
            try
            {
                var tokenReponse = pc.PostAsync(new Uri(AppApi.AddresseApi + "/token"), new FormUrlEncodedContent(form)).Result;
                if (tokenReponse.IsSuccessStatusCode)
                {
                    erreur.ok = tokenReponse.IsSuccessStatusCode;
                    var token = tokenReponse.Content.ReadAsAsync<Token>(new[] { new JsonMediaTypeFormatter() }).Result;
                    pc.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);
                    erreur.errorMessage = token.AccessToken;
                    AppApi.Token = token.AccessToken;
                    var reponseAutorise = pc.GetAsync(new Uri(AppApi.AddresseApi + "/api/Values")).Result;
                    return erreur;
                }
                else
                {
                    erreur.errorMessage = tokenReponse.Content.ReadAsStringAsync().Result;
                    erreur.ok = tokenReponse.IsSuccessStatusCode;
                    return erreur;
                }
            }
            catch (Exception e)
            {
                erreur.errorMessage = e.ToString();
                erreur.ok = false;
                return erreur;
            }
        }
    }
}
