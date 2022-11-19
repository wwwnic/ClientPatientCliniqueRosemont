using ClientCsharpCliniqueRosemont.Source;
using Microsoft.AspNetCore.Mvc;

namespace ClientPatientCliniqueRosemont.Controllers
{
    public class PrescriptionController : Controller
    {

        private readonly ApiPrescription api = new ApiPrescription();

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> VoirPrescription(int id)
        {
            var pres = await api.GetPrescriptionByIdAsync(id);
            return View(pres);
        }
    }
}
