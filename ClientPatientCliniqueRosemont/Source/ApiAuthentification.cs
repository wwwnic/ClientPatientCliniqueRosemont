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
            var uri = _url + "/api/Authentification/Patient";
            var reponse = await _httpClient.PostAsJsonAsync(uri, util);
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
