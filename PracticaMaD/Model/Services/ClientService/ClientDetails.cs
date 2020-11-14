using System;

namespace Es.Udc.DotNet.PracticaMad.Model.Services.ClientService
{
    /// <summary>
    /// VO Class which contains the client details
    /// </summary>
    [Serializable()]
    public class ClientDetails
    {
        #region Properties Region

        public string FirstName { get; private set; }

        public string Lastname { get; private set; }

        public string Email { get; private set; }

        public string ClientLanguage { get; private set; }

        public string ClientAddress { get; private set; }

        public string Rol { get; private set; }

        #endregion Properties Region

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientDetails"/>
        /// class.
        /// </summary>
        /// <param name="firstName">The client's first name.</param>
        /// <param name="lastName">The client's last name.</param>
        /// <param name="email">The client's email.</param>
        /// <param name="clientLanguage">The language.</param>
        /// <param name="clientAddress">The address.</param>
        /// <param name="rol">The role.</param>
        public ClientDetails(string firstName, string lastName, string email,
            string clientLanguage, string clientAddress, string rol)
        {
            this.FirstName = firstName;
            this.Lastname = lastName;
            this.Email = email;
            this.ClientLanguage = clientLanguage;
            this.ClientAddress = clientAddress;
            this.Rol = rol;
        }
    }
}