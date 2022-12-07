using ClientCsharpCliniqueRosemont.Source;
using ClientPatientCliniqueRosemont.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;


namespace ClientPatientCliniqueRosemont.Source
{
    public class ApiMedecin : ApiConnecteur
    {
        public async Task<bool> AjouterMedecin(MedecinModel model)
        {
            var uri = _url + "/api/Medecin";

            var reponse = await _httpClient.PostAsJsonAsync(uri, model);
            return reponse.IsSuccessStatusCode;
        }

    }
}
