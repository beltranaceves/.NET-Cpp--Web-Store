namespace Es.Udc.DotNet.PracticaMaD.Model
{
    using System;
    using System.Text;
    

    public partial class CreditCard
    {
        public CreditCard()
        {
            //this.CreditCardOps = new HashSet<CreditCardOp>();
        }

        public long cardId { get; set; }
        public String cardNumber { get; set; }
        public String cardType { get; set; }
        public long verificationCode { get; set; }
        public System.DateTime expeditionDate { get; set; }
        public Boolean isDefaultCard { get; set; }
        public long clientId { get; set; }

        /// <summary>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures 
        /// like a hash table. It uses the Josh Bloch implementation from "Effective Java"
        /// Primary key of entity is not included in the hash calculation to avoid errors
        /// with Entity Framework creation of key values.
        /// </summary>
        /// <returns>
        /// Returns a hash code for this instance.
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int multiplier = 31;
                int hash = GetType().GetHashCode();

                hash = hash * multiplier + cardId.GetHashCode();
                hash = hash * multiplier + cardNumber.GetHashCode();
                hash = hash * multiplier + cardType.GetHashCode();
                hash = hash * multiplier + verificationCode.GetHashCode();
                hash = hash * multiplier + expeditionDate.GetHashCode();
                hash = hash * multiplier + isDefaultCard.GetHashCode();
                hash = hash * multiplier + clientId.GetHashCode();


                return hash;
            }

        }

        /// <summary>
        /// Compare this object against another instance using a value approach (field-by-field) 
        /// </summary>
        /// <remarks>See http://www.loganfranken.com/blog/687/overriding-equals-in-c-part-1/ for detailed info </remarks>
        public override bool Equals(object obj)
        {

            if (ReferenceEquals(null, obj)) return false;        // Is Null?
            if (ReferenceEquals(this, obj)) return true;         // Is same object?
            if (obj.GetType() != this.GetType()) return false;   // Is same type?

            CreditCard target = obj as CreditCard;

            return true
               && (this.cardId == target.cardId)
               && (this.cardNumber == target.cardNumber)
               && (this.cardType == target.cardType)
               && (this.verificationCode == target.verificationCode)
               && (this.expeditionDate== target.expeditionDate)
               && (this.isDefaultCard == target.isDefaultCard)
               && (this.clientId == target.clientId)
               ;

        }


        public static bool operator ==(CreditCard objA, CreditCard objB)
        {
            // Check if the objets are the same CreditCard entity
            if (Object.ReferenceEquals(objA, objB))
                return true;

            return objA.Equals(objB);
        }


        public static bool operator !=(CreditCard objA, CreditCard objB)
        {
            return !(objA == objB);
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
            StringBuilder strCreditCard = new StringBuilder();

            strCreditCard.Append("[ ");
            strCreditCard.Append(" cardId = " + cardId + " | ");
            strCreditCard.Append(" cardNumber = " + cardNumber + " | ");
            strCreditCard.Append(" cardType = " + cardType + " | ");
            strCreditCard.Append(" verificationCode = " + verificationCode + " | ");
            strCreditCard.Append(" expeditionDate = " + expeditionDate + " | ");
            strCreditCard.Append(" isDefaultCard = " + isDefaultCard + " | ");
            strCreditCard.Append(" clientId = " + clientId + " | ");

            return strCreditCard.ToString();
        }


    }
}
