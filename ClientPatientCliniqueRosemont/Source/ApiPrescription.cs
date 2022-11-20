using ClientPatientCliniqueRosemont.Models;
using Newtonsoft.Json;

namespace ClientCsharpCliniqueRosemont.Source
{
    public class ApiPrescription : ApiConnecteur
    {
        public async Task<PrescriptionModel> GetPrescriptionByIdAsync(int id)
        {
            var uri = _url + "/Prescription/GetById?id=" + id;
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
            var uri = _url + "/Prescription/GetByPatientId?id=" + id;

            var reponse = await _httpClient.GetAsync(uri);
            List<PrescriptionModel> prescriptions = new List<PrescriptionModel>();
            if (reponse.IsSuccessStatusCode)
            {
                var reponseJson = await reponse.Content.ReadAsStringAsync();
                prescriptions = JsonConvert.DeserializeObject<List<PrescriptionModel>>(reponseJson);
            }
            return prescriptions;
        }
    }
}
