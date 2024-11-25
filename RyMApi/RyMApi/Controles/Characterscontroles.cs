using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RyMApi.Models;

namespace RyMApi.Controles
{
    public class Characterscontroles
    {
        private HttpClient client;

        public Characterscontroles()
        {
            client = new HttpClient();
        }

        public async Task<Characters> GetAllCharacters()
        {
            try
            {
                Models.Characters characters = new Models.Characters();
                HttpResponseMessage response = await 
                    client.GetAsync("https://rickandmortyapi.com/api/character");
            
                response.EnsureSuccessStatusCode();

                string responseJson = await 
                response.Content.ReadAsStringAsync();

                characters = 
                JsonConvert.DeserializeObject<Models.Characters>
                (responseJson);

                return characters;
            }
            catch (Exception)
            {
                return null;
            }
        }
        
    }
}
