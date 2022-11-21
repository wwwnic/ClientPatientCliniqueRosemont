using ClientPatientCliniqueRosemont.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace ClientPatientCliniqueRosemont.Controllers
{
    public class InscriptionController : Controller
    {
        public IActionResult Inscription()
        {
            return View("Inscription");
        }


    }
}
