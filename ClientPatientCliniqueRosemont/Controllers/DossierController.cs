using ClientCsharpCliniqueRosemont.Source;
using ClientPatientCliniqueRosemont.Models;
using ClientPatientCliniqueRosemont.Source;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Xml;

namespace ClientPatientCliniqueRosemont.Controllers
{
    public class DossierController : Controller
    {

        private readonly ApiPrescription API_PRES = new ApiPrescription();

        private readonly ApiPatient API_PAT = new ApiPatient();

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> VoirDossier(int id)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.Prescription = await API_PRES.GetPrescriptionByPatientIdAsync(id);
            mymodel.Patient = await API_PAT.GetPatientByIdAsync(id);
            return View(mymodel);
        }

        public IActionResult VoirFormulaireAjouterPrescription()
        {
            return View();
        }

        //recuperer les ID medecin dans la session et id patient dans la vue
        public async Task<IActionResult> AjouterPrescription(PrescriptionModel model)
        {
            var nouvellePres = new PrescriptionModel
            {
                Id = 1,
                Id_medecin = 1,
                Id_patient = 1,
                Description = model.Description,
                Notes = model.Notes,
                References = model.References
            };
            bool isSucces = await API_PRES.AddMedicalInformation(nouvellePres);
            if (isSucces)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.messageErreur = "Erreur";
                return View("VoirFormulaireAjouterPrescription");
            }
        }
    }
}
