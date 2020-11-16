using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMad.Model.Services.ClientService
{
    /// <summary>
    /// A Custom VO which keeps the results for a login action.
    /// </summary>
    [Serializable()]
    public class LoginResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginResult"/> class.
        /// </summary>
        /// <param name="clientId">The client id.</param>
        /// <param name="clientName">Client's name.</param>
        /// <param name="encryptedPassword">The encrypted password.</param>
        /// <param name="clientLanguage">The language.</param>
        /// <param name="clientAddress">The address.</param>
        public LoginResult(long clientId, String clientName,
            String encryptedPassword, String clientLanguage, String clientAddress)
        {
            this.ClientId = clientId;
            this.ClientName = clientName;
            this.EncryptedPassword = encryptedPassword;
            this.ClientLanguage = clientLanguage;
            this.ClientAddress = clientAddress;
        }

        #region Properties Region

        /// <summary>
        /// Gets the address code.
        /// </summary>
        /// <value>The address code.</value>
        public string ClientAddress { get; private set; }

        /// <summary>
        /// Gets the encrypted password.
        /// </summary>
        /// <value>The <c>encryptedPassword.</c></value>
        public string EncryptedPassword { get; private set; }

        /// <summary>
        /// Gets the client name.
        /// </summary>
        /// <value>The <c>clientName</c></value>
        public string ClientName { get; private set; }

        /// <summary>
        /// Gets the client language code.
        /// </summary>
        /// <value>The client language code.</value>
        public string ClientLanguage { get; private set; }

        /// <summary>
        /// Gets the client id.
        /// </summary>
        /// <value>The client id.</value>
        public long ClientId { get; private set; }

        #endregion Properties Region

        public override bool Equals(object obj)
        {
            LoginResult target = (LoginResult)obj;

            return (this.ClientId == target.ClientId)
                   && (this.ClientName == target.ClientName)
                   && (this.EncryptedPassword == target.EncryptedPassword)
                   && (this.ClientLanguage == target.ClientLanguage)
                   && (this.ClientAddress == target.ClientAddress);
        }

        // The GetHashCode method is used in hashing algorithms and data
        // structures such as a hash table. In order to ensure that it works
        // properly, it is based on a field that does not change.
        public override int GetHashCode()
        {
            return this.ClientId.GetHashCode();
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"></see> that represents the
        /// current <see cref="T:System.Object"></see>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"></see> that represents the current
        /// <see cref="T:System.Object"></see>.
        /// </returns>
        public override String ToString()
        {
            String strLoginResult;

            strLoginResult =
                "[ clientId = " + ClientId + " | " +
                "clienName = " + ClientName + " | " +
                "encryptedPassword = " + EncryptedPassword + " | " +
                "clientLanguage = " + ClientLanguage + " | " +
                "clientAddress = " + ClientAddress + " ]";

            return strLoginResult;
        }
    }
}