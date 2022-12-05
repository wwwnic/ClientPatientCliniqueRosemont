using ClientPatientCliniqueRosemont.Models;

namespace ClientPatientCliniqueRosemont.Services
{
    public interface PatientService
    {
        public PatientModel Login(int id, string password);

        public UtilisateurModel Connecter(int id, string password);
    }
}
