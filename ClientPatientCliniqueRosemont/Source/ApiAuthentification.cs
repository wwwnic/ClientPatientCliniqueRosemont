using ClientCsharpCliniqueRosemont.Source;
using ClientPatientCliniqueRosemont.Models;
using Newtonsoft.Json;
using System.Text;

namespace ClientPatientCliniqueRosemont.Source
{
    public class ApiAuthentification : ApiConnecteur
    {
        public async Task<bool> Connexion(UtilisateurModel util)
        {
            var uri = _url + "/Patient/Login";

            var UtilJson = JsonConvert.SerializeObject(util);
            var contenu = new StringContent(UtilJson, Encoding.UTF8, "application/json");
            var reponse = await _httpClient.PostAsync(uri, contenu);
            var estConnecte = false;
            if (reponse.IsSuccessStatusCode)
            {
                var stringRead = await reponse.Content.ReadAsStringAsync();
                estConnecte = bool.Parse(stringRead);
            }
            return estConnecte;
        }
    }
}
