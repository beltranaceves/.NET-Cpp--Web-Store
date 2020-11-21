using System;

namespace Es.Udc.DotNet.PracticaMad.Model.Services.ProductService
{
    /// <summary>
    /// VO Class which contains the product details
    /// </summary>
    [Serializable()]
    public class ProductDetails
    {
        #region Properties Region

        public String productName { get; private set; }

        public double price { get; private set; }

        public System.DateTime registerDate { get; private set; }

        public int stock { get; private set; }

        public long categoryId{ get; private set; }

        #endregion Properties Region

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductDetails"/>
        /// class.
        /// </summary>
        /// <param name="firstName">The product's first name.</param>
        /// <param name="firstSurname">The product's  first surname.</param>
        /// <param name="lastSurname">The product's last surname.</param>
        /// <param name="email">The product's email.</param>
        /// <param name="productLanguage">The language.</param>
        /// <param name="productAddress">The address.</param>
        /// <param name="rol">The role.</param>
        public ProductDetails(String firstName, String firstSurname, String lastSurname, String email,
            String productLanguage, String productAddress, String rol)
        {
            this.FirstName = firstName;
            this.FirstSurname = firstSurname;
            this.LastSurname = lastSurname;
            this.Email = email;
            this.ProductLanguage = productLanguage;
            this.ProductAddress = productAddress;
            this.Rol = rol;
        }

        public override bool Equals(object obj)
        {
            ProductDetails target = (ProductDetails)obj;

            return (this.FirstName == target.FirstName)
                  && (this.FirstSurname == target.FirstSurname)
                  && (this.LastSurname == target.LastSurname)
                  && (this.Email == target.Email)
                  && (this.ProductLanguage == target.ProductLanguage)
                  && (this.ProductAddress == target.ProductAddress)
                  && (this.Rol == target.Rol);
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
            String strProductDetails;

            strProductDetails =
                "[ firstName = " + FirstName + " | " +
                "firstSurname = " + FirstSurname + " | " +
                "lastSurname = " + LastSurname + " | " +
                "email = " + Email + " | " +
                "productLanguage = " + ProductLanguage + " | " +
                "productAddress = " + ProductAddress + " | " +
                "rol = " + Rol + " ]";

            return strProductDetails;
        }
    }
}