using ClientPatientCliniqueRosemont.Models;
using ClientPatientCliniqueRosemont.Source;
using Microsoft.AspNetCore.Mvc;

namespace ClientPatientCliniqueRosemont.Controllers
{
    public class Authentification : Controller
    {

        /*
         * Permet de redirigier vers la vue connexion
         * 
         * @return Views/Authentification/VoirConnexion.cshtml
         */

        public IActionResult VoirConnexion()
        {
            return View();
        }

        /*
         * (Est appelé par le button du formulaire dans VoirConnexion)
         * Permet de vérifier l'utilisateur via l'api
         * @return Views/Home/Index ou la vue VoirConnexion avec un msg d'erreur
         */
        public async Task<IActionResult> SeConnecter(int id, string password)
        {
            var apiConn = new ApiAuthentification();
            var utilisateurPotentiel = new UtilisateurModel
            {
                Id = id,
                Password = password
            };
            var connexionEstReussi = await apiConn.Connexion(utilisateurPotentiel);
            if (connexionEstReussi)
            {
                ViewBag.message = "Connexion du patient réussi";
                HttpContext.Session.SetInt32("id", id);
                return RedirectToAction("VoirDossier", "Dossier");
            }
            else
            {
                ViewBag.messageErreur = "Information invalide";
                return View("VoirConnexion");
            }
        }

        public IActionResult VoirEnregistrementPatient()
        {
            return View();
        }

        public async Task<IActionResult> EnregistrementPatient(string nom, string prenom, string email, string password, string ddn, string age, string sexe, string allergies)
        {
            var apiConn = new ApiPatient();
            var patient = new PatientModel()
            {
                Password = password,
                Nom = nom,
                Prenom = prenom,
                Email = email,
                Ddn = ddn,
                Age = int.Parse(age),
                Sexe = sexe,
                Allergies = allergies
            };
            var inscriptionReussi = await apiConn.AjouterPatient(patient);
            if (inscriptionReussi)
            {
                ViewBag.message = "Inscription du patient réussi";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.messageErreur = "Erreur lors de l'inscription du patient, veuillez réesayer à nouveau";
                return View("VoirEnregistrementPatient");
            }
        }
        public IActionResult VoirEnregistrementMedecin()
        {
            return View();
        }

        public async Task<IActionResult> EnregistrementMedecin(string nom, string prenom, string email, string password)
        {
            var apiConn = new ApiMedecin();
            var medecin = new MedecinModel()
            {
                Password = password,
                Nom = nom,
                Prenom = prenom,
                Email = email,
            };
            var inscriptionReussi = await apiConn.AjouterMedecin(medecin);
            if (inscriptionReussi)
            {
                ViewBag.message = "Inscription du medecin réussi";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.messageErreur = "Erreur lors de l'inscription du medecin, veuillez réesayer à nouveau";
                return View("VoirEnregistrementMedecin");
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("id");
            return RedirectToAction("Index", "Home");
        }
    }
}
