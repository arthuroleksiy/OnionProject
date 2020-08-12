using Onion_DomainLayer;
using System;
using Onion_PersistanceLayer;


namespace Onion_ServiceLayer
{
    /// <summary>
    /// Enter page class with business logic
    /// </summary>
    public class EnterPageService
    {
        /// <summary>
        /// Gets logged user type
        /// </summary>
        /// <returns>Type value</returns>
        public Type GetLoggedUser() {
            return MockActiveUserRepository.WhoISLogged();
        }

    }
}
