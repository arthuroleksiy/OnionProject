using System;
using Onion_ServiceLayer;
using Onion_ServiceLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Onion_Tests
{
    [TestClass]
    public class RegistrationPageControllerTests
    {
        private readonly RegistratiionPageService registrationPageController = new RegistratiionPageService();

        [TestMethod]
        public void RegistrationRole_IsCorrect()
        {
            var expected = true;
            var actual = registrationPageController.RegisterRole("a", "b", "c", "z", "e");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void RegistrationRole_IfDataCorrect()
        {
            var expected = false;
            var actual = registrationPageController.RegisterRole("a", "b", "c", "petro79", "e");
            Assert.AreEqual(expected, actual);
        }
    }
}
