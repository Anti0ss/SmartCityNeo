using Newtonsoft.Json;
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
    class ObjetService
    {
        private HttpClient pc;
        private ApplicationError erreur;

        public ObjetService()
        {
            pc = new HttpClient();
            erreur = new ApplicationError();
        }

        public async Task<IEnumerable<Objet>> GetObjet()
        {
            pc.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AppApi.Token);
            var json = await pc.GetStringAsync(new Uri(AppApi.AddresseApi + "/api/Objets"));
            Objet[] dataRetour = JsonConvert.DeserializeObject<Objet[]>(json);
            return dataRetour;
        }
    }
}
