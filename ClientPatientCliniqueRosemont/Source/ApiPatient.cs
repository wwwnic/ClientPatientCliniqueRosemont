using ClientCsharpCliniqueRosemont.Source;
using ClientPatientCliniqueRosemont.Models;
using Newtonsoft.Json;
using System.Net.Http;

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

        public async Task<PatientModel> AjouterPatient(UtilisateurModel model)
        {
            var uri = _url + "/Patient/Add?id=" + model;
            var reponse = await _httpClient.GetAsync(uri);
            PatientModel patient = new PatientModel();
            if (reponse.IsSuccessStatusCode)
            {
                var reponseJson = await reponse.Content.ReadAsStringAsync();
                patient = JsonConvert.DeserializeObject<PatientModel>(reponseJson);
            }
            return patient;
        }

    }
}
