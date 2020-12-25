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

        public String FirstName { get; private set; }

        public String FirstSurname { get; private set; }

        public String LastSurname { get; private set; }

        public String Email { get; private set; }

        public String ClientLanguage { get; private set; }

        public String ClientAddress { get; private set; }

        public String Country { get; private set; }

        #endregion Properties Region

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientDetails"/>
        /// class.
        /// </summary>
        /// <param name="firstName">The client's first name.</param>
        /// <param name="firstSurname">The client's  first surname.</param>
        /// <param name="lastSurname">The client's last surname.</param>
        /// <param name="email">The client's email.</param>
        /// <param name="clientLanguage">The language.</param>
        /// <param name="clientAddress">The address.</param>
        /// <param name="country">The country of the Language.</param>
        public ClientDetails(String firstName, String firstSurname, String lastSurname, String email,
            String clientLanguage, String clientAddress, String country)
        {
            this.FirstName = firstName;
            this.FirstSurname = firstSurname;
            this.LastSurname = lastSurname;
            this.Email = email;
            this.ClientLanguage = clientLanguage;
            this.ClientAddress = clientAddress;
            this.Country = country;
        }

        public override bool Equals(object obj)
        {
            ClientDetails target = (ClientDetails)obj;

            return (this.FirstName == target.FirstName)
                  && (this.FirstSurname == target.FirstSurname)
                  && (this.LastSurname == target.LastSurname)
                  && (this.Email == target.Email)
                  && (this.ClientLanguage == target.ClientLanguage)
                  && (this.ClientAddress == target.ClientAddress)
                  && (this.Country == target.Country);
        }

        // The GetHashCode method is used in hashing algorithms and data
        // structures such as a hash table. In order to ensure that it works
        // properly, we suppose that the FirstName does not change.
        public override int GetHashCode()
        {
            return this.FirstName.GetHashCode();
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
            String strClientDetails;

            strClientDetails =
                "[ firstName = " + FirstName + " | " +
                "firstSurname = " + FirstSurname + " | " +
                "lastSurname = " + LastSurname + " | " +
                "email = " + Email + " | " +
                "clientLanguage = " + ClientLanguage + " | " +
                "clientAddress = " + ClientAddress + " | " +
                "country = " + Country + " ]";

            return strClientDetails;
        }
    }
}