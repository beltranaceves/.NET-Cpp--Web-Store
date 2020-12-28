using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMad.Model.Services.CreditCardService
{
    [Serializable()]
    public class CreditCardDetails
    {
        #region Properties region

        public string CardNumber { get; }

        public string CardType { get; }

        public long VerificationCode { get; }

        public string ExpeditionDate { get; }

        public bool DefaultCard { get; }

        public long ClientId { get; }

        #endregion Properties region

        public CreditCardDetails(string cardNumber, string cardType, long verificationCode, string expeditionDate,
        bool defaultCard, long clientId)
        {
            this.CardNumber = cardNumber;
            this.CardType = cardType;
            this.VerificationCode = verificationCode;
            this.ExpeditionDate = expeditionDate;
            this.DefaultCard = defaultCard;
            this.ClientId = clientId;
        }

        public override bool Equals(object obj)
        {
            CreditCardDetails target = (CreditCardDetails)obj;

            return (this.CardNumber == target.CardNumber)
                  && (this.CardType == target.CardType)
                  && (this.VerificationCode == target.VerificationCode)
                  && (this.ExpeditionDate == target.ExpeditionDate)
                  && (this.DefaultCard == target.DefaultCard)
                  && (this.ClientId == target.ClientId);
        }

        // The GetHashCode method is used in hashing algorithms and data
        // structures such as a hash table. In order to ensure that it works
        // properly, we suppose that the CardNumbeer does not change.
        public override int GetHashCode()
        {
            return this.CardNumber.GetHashCode();
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
            String strCreditCardDetails;

            strCreditCardDetails =
                "[ cardNumber = " + CardNumber + " | " +
                "cardType = " + CardType + " | " +
                "verificationCode = " + VerificationCode + " | " +
                "expeditionDate = " + ExpeditionDate + " | " +
                "defaultCard = " + DefaultCard + " | " +
                "clientId = " + ClientId + " ]";

            return strCreditCardDetails;
        }
    }
}