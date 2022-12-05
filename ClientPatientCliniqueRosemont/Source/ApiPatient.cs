using ClientCsharpCliniqueRosemont.Source;
using ClientPatientCliniqueRosemont.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace ClientPatientCliniqueRosemont.Source
{
    public class ApiPatient : ApiConnecteur
    {
        public async Task<PatientModel> GetPatientByIdAsync(int id)
        {
            var uri = _url + "/Patient/GetById?id=" + id;
            var reponse = await _httpClient.GetAsync(uri);
            PatientModel patient = new PatientModel();
            if (reponse.IsSuccessStatusCode)
            {
                var reponseJson = await reponse.Content.ReadAsStringAsync();
                patient = JsonConvert.DeserializeObject<PatientModel>(reponseJson);
            }
            return patient;
        }

        public async Task<bool> AjouterPatient(PatientModel model)
        {
            var uri = _url + "/Patient/add";

            var UtilJson = JsonConvert.SerializeObject(model);
            var contenu = new StringContent(UtilJson, Encoding.UTF8, "application/json");
            var reponse = await _httpClient.PutAsync(uri, contenu);
            return reponse.IsSuccessStatusCode;
        }
    }
}
