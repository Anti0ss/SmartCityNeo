using Newtonsoft.Json;
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
    class CategorieService
    {
        public async Task<IEnumerable<Categorie>> GetCategorie()
        {
            var pc = new HttpClient();
            pc.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AppApi.Token);
            var json = await pc.GetStringAsync(new Uri(AppApi.AddresseApi + "/api/Categories"));
            Categorie[] retourData = JsonConvert.DeserializeObject<Categorie[]>(json);
            return retourData;
        }
    }
}
