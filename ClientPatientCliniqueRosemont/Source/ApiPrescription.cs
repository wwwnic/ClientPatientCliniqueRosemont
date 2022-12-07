using ClientPatientCliniqueRosemont.Models;
using Newtonsoft.Json;
using System.Text;

namespace ClientCsharpCliniqueRosemont.Source
{
    public class ApiPrescription : ApiConnecteur
    {
        public async Task<PrescriptionModel> GetPrescriptionByIdAsync(int id)
        {
            var uri = _url + "/api/Prescription/" + id;
            var reponse = await _httpClient.GetAsync(uri);
            PrescriptionModel prescription = new PrescriptionModel();
            if (reponse.IsSuccessStatusCode)
            {
                var reponseJson = await reponse.Content.ReadAsStringAsync();
                prescription = JsonConvert.DeserializeObject<PrescriptionModel>(reponseJson);
            }
            return prescription;
        }

        public async Task<List<PrescriptionModel>> GetPrescriptionByPatientIdAsync(int id)
        {
            var uri = _url + "/api/Prescription/ByPatientId/" + id;

            var reponse = await _httpClient.GetAsync(uri);
            List<PrescriptionModel> prescriptions = new List<PrescriptionModel>();
            if (reponse.IsSuccessStatusCode)
            {
                var reponseJson = await reponse.Content.ReadAsStringAsync();
                prescriptions = JsonConvert.DeserializeObject<List<PrescriptionModel>>(reponseJson);
            }
            return prescriptions;
        }

        public async Task<bool> AddMedicalInformation(PrescriptionModel pres)
        {
            var reponse = await _httpClient.PostAsJsonAsync(_url + "/api/Prescription", pres);
            return reponse.IsSuccessStatusCode;

        }


    }
}
