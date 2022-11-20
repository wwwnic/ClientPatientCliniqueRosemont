using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;

namespace ClientPatientCliniqueRosemont.Models
{
    public class PrescriptionModel
    {
        public int Id { get; set; }

        public int Id_medecin { get; set; }

        public int Id_patient { get; set; }

        [Display(Name = "Prescription")]
        public string Description { get; set; } = "";

        [Display(Name = "Note")]
        public string Notes { get; set; } = "";

        [Display(Name = "Reference")]
        public string References { get; set; } = "";

    }
}
