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
            var uri = _url + "/Medecin/add";

            var UtilJson = JsonConvert.SerializeObject(model);
            var contenu = new StringContent(UtilJson, Encoding.UTF8, "application/json");
            var reponse = await _httpClient.PutAsync(uri, contenu);
            return reponse.IsSuccessStatusCode;
        }

    }
}
