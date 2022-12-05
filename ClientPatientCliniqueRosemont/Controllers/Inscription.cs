using ClientPatientCliniqueRosemont.Models;
using Microsoft.AspNetCore.Mvc;
using ClientPatientCliniqueRosemont.Source;

namespace ClientPatientCliniqueRosemont.Controllers
{
    public class Inscription : Controller
    {

        public IActionResult Formulaire()
        {
            return View();
        }

        public async Task<IActionResult> AjouterPatient(PatientModel model)
        {
            var apiInscription = new ApiFormulaire();
            var nouveauPatient = new PatientModel
            {
                Id = model.Id,
                Nom = model.Nom,
                Prenom = model.Prenom,
                Password = model.Password,
                Email = model.Email,
                Ddn = model.Ddn,
                Age = model.Age,
                Sexe = model.Sexe,
                Allergies = model.Allergies
            };
            var inscriptionReussi = await apiInscription.Inscription(nouveauPatient);
            if (nouveauPatient != null)
            {
                ViewBag.message = "Inscription du patient réussi";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.messageErreur = "Erreur de l'inscription du patient";
                return View("Inscription");
            }

        }
    }


}

