using ClientPatientCliniqueRosemont.Models;
using ClientPatientCliniqueRosemont.Source;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ClientPatientCliniqueRosemont.Controllers
{
   
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly ApiPatient patient;
        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
            patient = new ApiPatient();
        }

        public IActionResult Connexion()
        {
            return View("Connexion");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /* [Route("")]
         [HttpPost]
         public async Task<IActionResult> Login(UtilisateurModel model)
         {
             UtilisateurModel? utilisateur;
             try
             {
                 //utilisateur = await patient.AjouterPatient(model);
             }
             catch
             {
                 ViewBag.messageErreur = "Erreur de connexion avec le serveur";
                 utilisateur = null;
                 return View(model);
             }
             if (utilisateur?.Prenom != null)
             {
                 var utilisateurJson = JsonConvert.SerializeObject(utilisateur);
                 HttpContext.Session.SetInt32("login", utilisateur.Id);
                 HttpContext.Session.SetString("nomLogin", utilisateur.NomUtilisateur);
                 HttpContext.Session.SetString("utilisateur", utilisateurJson);
                 return RedirectToAction("Index", "Main");
             }
             else
             {
                 ViewBag.messageErreur = "Une erreur est survenue durant votre connexion";
                 return View(model);
             }
         }

         [Route("Logoff")]
         public IActionResult Logoff()
         {
             HttpContext.Session.Remove("login");
             HttpContext.Session.Remove("nomLogin");
             return RedirectToAction("Login");
         }

         [Route("Signup")]
         [HttpGet]
         public IActionResult Inscription()
         {
             return View();
         }

         [Route("Signup")]
         [HttpPost]
         public IActionResult Inscription(UtilisateurModel model)
         {
             bool? isRegistered;
             try
             {
                 isRegistered = patient.SignUp(model)?.Result;
             }
             catch
             {
                 ViewBag.messageErreur = "Erreur de connexion avec le serveur";
                 isRegistered = null;
                 return View(model);
             }
             if (isRegistered.HasValue && isRegistered.Value)
             {
                 return View("Login");

             }
             else
             {
                 ViewBag.messageErreur = "Une erreur est survenue durant votre inscription";
                 return View(model);
             }
         }*/
    }
}
