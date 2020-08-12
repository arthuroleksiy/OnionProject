using System;
using Onion_PresentationLayer;
using Onion_ServiceLayer;
using Onion_DomainLayer;


namespace Onion_PresentationLayer
{
    class RegistrationPagePL
    {
        public Func<string, string, string, string, string, bool> registerUser;
        private readonly RegistratiionPageService registrationPageController = new RegistratiionPageService();
        private readonly EnterPagePL enterPageView = new EnterPagePL();

        /// <summary>
        /// Default constructor
        /// </summary>
        public RegistrationPagePL()
        {
            registerUser += registrationPageController.RegisterRole;
        }
        /// <summary>
        /// Process of registration
        /// </summary>
        public void Output()
        {

            Console.WriteLine("User Registartion:");
            Console.WriteLine();

            Console.WriteLine("Name:");
            var Name = Console.ReadLine();
            Console.WriteLine("Surname:");
            var Surname = Console.ReadLine();
            Console.WriteLine("Telephone number:");
            var Telephone = Console.ReadLine();
            Console.WriteLine("Enter login:");
            var Login = Console.ReadLine();
            Console.WriteLine("Password:");
            var Password = Console.ReadLine();
            var result = registerUser(Name, Surname, Telephone, Login, Password);
            RegistrationResult(result);

        }
        /// <summary>
        /// Registration result
        /// </summary>
        /// <param name="result"></param>
        public void RegistrationResult(bool result)
        {
            if (result)
                Console.WriteLine("User have been regitered");
            else
                Console.WriteLine("User haven't been regitered");

            enterPageView.Output();
            enterPageView.Choise();
        }
    }
}
