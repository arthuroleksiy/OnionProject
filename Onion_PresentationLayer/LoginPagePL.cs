using System;
using Onion_PresentationLayer;
using Onion_ServiceLayer;
using Onion_DomainLayer;


namespace Onion_PresentationLayer
{
    class LoginPagePL
    {

        public Func<string, string, bool> LoginUser;
        public LoginPageService LoginPageController = new LoginPageService();
        public string Login { get; set; }
        public string Password { get; set; }

        public LoginPagePL()
        {
            LoginUser += LoginPageController.ISCorrectLogin;
        }

        public void LoginProcess()
        {
            Output();
            StartSignIn();

            EnterPagePL enterPageView = new EnterPagePL();
            enterPageView.Output();
            enterPageView.Choise();
        }
        public void Output()
        {
            Console.WriteLine("Enter login:");
            Login = Console.ReadLine();
            Console.WriteLine("Password:");
            Password = Console.ReadLine();

        }

        public void StartSignIn()
        {

            if (LoginUser(Login, Password))
            {
                Console.WriteLine("Successfull authentififcation");
                LoginPageController.Login = Login;
            }
            else
                Console.WriteLine("Authentififcation failed");
        }
    }
}
