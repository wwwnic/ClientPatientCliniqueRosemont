using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientPatientCliniqueRosemont.Source;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientPatientCliniqueRosemont.Models;

namespace ClientPatientCliniqueRosemont.Source.Tests
{
    [TestClass()]
    public class ApiAuthentificationTests
    {
        [TestMethod()]
        public void ConnexionTest()
        {
            UtilisateurModel user = new UtilisateurModel();
            user.Password = "testPrice";
            user.Id = 1;

            ApiAuthentification test = new ApiAuthentification();
            Task<bool> attendu = test.Connexion(user);
            Assert.AreEqual(true, attendu);
        }
    }
}