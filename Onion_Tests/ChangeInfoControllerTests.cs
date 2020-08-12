using Microsoft.VisualStudio.TestTools.UnitTesting;
using Onion_ServiceLayer;
using Onion_DomainLayer;
using Onion_PersistanceLayer;
using System.Threading;

namespace Onion_Tests
{
    [TestClass]
    public class ChangeInfoBLLTests
    {

        [TestMethod]
        [DataRow(3,"Tif")]
        public void ChangeName_IsChanged(int id, string value)
        {
            ChangeInfoService changeInfoController = new ChangeInfoService();
            var expected = "Tif";
            changeInfoController.ChangeName(id, value);
            var actual = MockRegisteredUserRepository.GetUserById(id).Name;
            Thread.Sleep(375);
            Assert.AreEqual(expected, actual);
        
        }


        [TestMethod]
        [DataRow(2, "Fayi")]
        public void ChangeSurname_IsChanged(int id, string value)
        {
            ChangeInfoService changeInfoController = new ChangeInfoService();
            var expected = "Fayi";
            changeInfoController.ChangeSurame(id, value);
            var actual = MockRegisteredUserRepository.GetUserById(id).Surname;

            Thread.Sleep(300);
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        [DataRow(1, "555")]
        public void ChangeTelephone_IsChanged(int id, string value)
        {
            ChangeInfoService changeInfoController = new ChangeInfoService();
            var expected = "555";
            changeInfoController.ChangeTelephone(id, value);
            var actual = MockRegisteredUserRepository.GetUserById(id).TelephoneNumber;
            Thread.Sleep(225);
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        [DataRow(4, "kitty")]
        public void ChangeLogin_IsChanged(int id, string value)
        {
            ChangeInfoService changeInfoController = new ChangeInfoService();
            var expected = "kitty";
            changeInfoController.ChangeLogin(id, value);
            var actual = MockRegisteredUserRepository.GetUserById(id).Login;

            Thread.Sleep(150);
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        [DataRow(5, "you")]
        public void ChangePassword_IsChanged(int id, string value)
        {
            ChangeInfoService changeInfoController = new ChangeInfoService();
            var expected = "you";
            changeInfoController.ChangePassword(id, value);
            var actual = MockRegisteredUserRepository.GetUserById(id).Password;
            Thread.Sleep(75);
            Assert.AreEqual(expected, actual);

        }
       
    }
}
