using Microsoft.VisualStudio.TestTools.UnitTesting;

using Onion_ServiceLayer;

namespace Onion_Tests
{
    [TestClass]
    public class LoginPageControllerTests
    {
        private readonly LoginPageService loginPageController = new LoginPageService();

        public LoginPageControllerTests()
        {

        }
        
        [TestMethod]
        public void CheckData_Resturn_is_Correect()
        {
            var result = loginPageController.CheckData("petro79", "ukr234");
            Assert.AreEqual(true, result);
        }


        [TestMethod]
        public void Login_IsAssert()
        {
            var expected = true;
            var actual = loginPageController.ISCorrectLogin("petro79", "ukr234");
            Assert.AreEqual(expected, actual);
        }

    }
}
