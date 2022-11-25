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
                HttpContext.Session.SetInt32("id", id);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.messageErreur = "Information invalide";
                return View("VoirConnexion");
            }
        }

    }
}
