using ClientPatientCliniqueRosemont.Models;

namespace ClientPatientCliniqueRosemont.Services
{
    public class PatientServiceImpl : PatientService
    {
        private List<PatientModel> patients;

        private List<UtilisateurModel> utilisateurs;

        public PatientServiceImpl()
        {
            utilisateurs = new List<UtilisateurModel>()
            {
                new UtilisateurModel{
                    Id = 3,
                    Password = "bob"
                },
                new UtilisateurModel
                {
                    Id = 4,
                    Password = "prog"
                }
            };


            patients = new List<PatientModel> {
                new PatientModel
                {
                    Id = 1,
                    Nom = "Lazarte",
                    Prenom = "Nicolas",
                    Password = "nicolas123",
                    Email = "nicolaslv22@hotmail.com",
                    Ddn = "18/12/2000",
                    Age = 21,
                    Sexe = "Homme",
                    Allergies = "Non"
                },
                new PatientModel
                {
                    Id = 2,
                    Nom = "Burdet",
                    Prenom = "Benjamin",
                    Password = "ben0973!",
                    Email = "benrioux@gmail.com",
                    Ddn = "02/04/2001",
                    Age = 21,
                    Sexe = "Homme",
                    Allergies = "Pénicilline"
                },
            };
        }
        public PatientModel Login(int id, string password)
        {
            return patients.SingleOrDefault(a => a.Id == id && a.Password == password);
        }

        public UtilisateurModel Connecter(int id, string password)
        {
            return utilisateurs.SingleOrDefault(a => a.Id == id && a.Password == password);
        }
    }
}
