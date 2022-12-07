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
            var uri = _url + "/api/Patient/id/" + id;
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
            var uri = _url + "/api/Patient";
            var reponse = await _httpClient.PostAsJsonAsync(uri, model);
            return reponse.IsSuccessStatusCode;
        }
    }



}

