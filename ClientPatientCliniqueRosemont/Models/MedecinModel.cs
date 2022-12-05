using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace ClientPatientCliniqueRosemont.Models
{
    public class MedecinModel
    {

        public int Id { get; set; }

        public string Nom { get; set; } = "no name";

        public string Prenom { get; set; } = "no first name";

        public string Password { get; set; }

        public string Email { get; set; } = "no email";

    }
}
