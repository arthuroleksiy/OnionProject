
namespace Onion_DomainLayer
{
    /// <summary>
    /// Derivered class from <see cref="IRegisteredUser"/>
    /// </summary>
    public class RegisteredUser: IRegisteredUser
    {
        /// <summary>
        /// User id.
        /// </summary>
        public int RegisteresUserId { get; set; }

        /// <summary>
        /// User name.
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// User surname.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// User telephone.
        /// </summary>
        public string TelephoneNumber { get; set; }

        /// <summary>
        /// User login.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// User password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisteredUser"/> class.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="telephoneNumber"></param>
        /// <param name="login"></param>
        /// <param name="password"></param>
        public RegisteredUser(int id, string name, string surname, string telephoneNumber, string login, string password)
        {
            this.RegisteresUserId = id;
            this.Name = name;
            this.Surname = surname;
            this.TelephoneNumber = telephoneNumber;
            this.Login = login;
            this.Password = password;
        }
    }
}
