using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using projetSmartCity.Error;
using projetSmartCity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace projetSmartCity.DAO
{
    class AnnonceService
    {
        private HttpClient pc;
        private ApplicationError erreur;

        public AnnonceService()
        {
            pc = new HttpClient();
            erreur = new ApplicationError();
        }

        public async Task<IEnumerable<Annonce>> GetAnnonce()
        {
            pc.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AppApi.Token);
            var json = await pc.GetStringAsync(new Uri(AppApi.AddresseApi+"/api/Annonces"));
            Annonce[] dataRetour = JsonConvert.DeserializeObject<Annonce[]>(json);
            return dataRetour; 
        }
        public async Task<ApplicationError> PostAnnonce(AnnonceCreateModel annonce)
        {
            pc.BaseAddress = new Uri(AppApi.AddresseApi + "/api/Annonces");
            pc.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AppApi.Token);
            try
            {
                var reponse = pc.PostAsJsonAsync(pc.BaseAddress, annonce).Result;
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
        
    }
}
