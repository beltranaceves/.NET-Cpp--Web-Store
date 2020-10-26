using System.Diagnostics;

namespace Es.Udc.DotNet.PracticaMAD.Model.Services.ClientService
{
    /// <summary>
    /// VO Class which contains the client details
    /// </summary>
    [Serializable()]
    public class ClientDetails
    {
        #region Properties Region

        public string ClientLogin { get; private set; }

        public string ClientPassword { get; private set; }

        public string ClientName { get; private set; }

        public string FirstName { get; private set; }

        public string Lastname { get; private set; }

        public string Email { get; private set; }

        public string ClientLanguage { get; private set; }

        public string ClientAddress { get; private set; }

        public string rol { get; private set; }

        #endregion Properties Region

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientDetails"/>
        /// class.
        /// </summary>
        /// <param name="clientLogin">The client's login.</param>
        /// <param name="clientPassword">The client's password.</param>
        /// <param name="clientName">The client's first name.</param>
        /// <param name="firstName">The client's first name.</param>
        /// <param name="lastName">The client's last name.</param>
        /// <param name="email">The client's email.</param>
        /// <param name="language">The language.</param>
        /// <param name="clientAddress">The address.</param>
        /// <param name="rol">The role.</param>
        public ClientDetails(string clientLogin, string clientPassword, string clientName, string firstName,
                string lastName, string email, string language, String clientAddress, string rol)
        {
            this.ClientLogin = clientLogin;
            this.ClientPassword = ClientPassword;
            this.ClientName = clientName;
            this.FirstName = firstName;
            this.Lastname = lastName;
            this.Email = email;
            this.Language = language;
            this.ClientAddress = clientAddress;
            this.rol = rol;
        }
    }
}