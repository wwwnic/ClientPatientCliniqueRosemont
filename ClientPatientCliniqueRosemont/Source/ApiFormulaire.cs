using ClientCsharpCliniqueRosemont.Source;
using ClientPatientCliniqueRosemont.Models;
using Newtonsoft.Json;
using System.Text;

namespace ClientPatientCliniqueRosemont.Source
{
    public class ApiFormulaire : ApiConnecteur
    {
        public async Task<bool> Inscription(PatientModel util)
        {
            var uri = _url + "/Patient/Inscription";

            var UtilJson = JsonConvert.SerializeObject(util);
            var contenu = new StringContent(UtilJson, Encoding.UTF8, "application/json");
            var reponse = await _httpClient.PostAsync(uri, contenu);
            var estInscrit = false;
            if (reponse.IsSuccessStatusCode)
            {
                var stringRead = await reponse.Content.ReadAsStringAsync();
                estInscrit = bool.Parse(stringRead);
            }
            return estInscrit;
        }
    }
}

