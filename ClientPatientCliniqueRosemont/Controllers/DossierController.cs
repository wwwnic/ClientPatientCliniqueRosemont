using ClientCsharpCliniqueRosemont.Source;
using ClientPatientCliniqueRosemont.Source;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace ClientPatientCliniqueRosemont.Controllers
{
    public class DossierController : Controller
    {

        private readonly ApiPrescription api_pres = new ApiPrescription();

        private readonly ApiPatient api_pat = new ApiPatient();

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> VoirDossier(int id)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.Prescription = await api_pres.GetPrescriptionByPatientIdAsync(id);
            mymodel.Patient = await api_pat.GetPatientByIdAsync(id);
            return View(mymodel);
        }
    }
}
