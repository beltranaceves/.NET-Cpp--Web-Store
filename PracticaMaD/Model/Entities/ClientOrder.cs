namespace Es.Udc.DotNet.PracticaMaD.Model
{
    using System;
    using System.Text;

    public partial class ClientOrder
    {
        public ClientOrder()
        {
            //this.clientOps = new HashSet<clientOp>();
        }

        public long orderId { get; set; }
        public System.DateTime orderDate { get; set; }
        public String orderName { get; set; }
        public long creditCardId { get; set; }
        public String clientOrderAddress { get; set; }
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

                hash = hash * multiplier + orderId.GetHashCode();
                hash = hash * multiplier + orderDate.GetHashCode();
                hash = hash * multiplier + orderName.GetHashCode();
                hash = hash * multiplier + creditCardId.GetHashCode();
                hash = hash * multiplier + clientOrderAddress.GetHashCode();
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

            ClientOrder target = obj as ClientOrder;

            return true
               && (this.orderId== target.orderId)
               && (this.orderName == target.orderName)
               && (this.orderDate == target.orderDate)
               && (this.creditCardId== target.creditCardId)
               && (this.clientOrderAddress == target.clientOrderAddress)
               && (this.clientId == target.clientId)
               ;

        }


        public static bool operator ==(ClientOrder objA, ClientOrder objB)
        {
            // Check if the objets are the same client entity
            if (Object.ReferenceEquals(objA, objB))
                return true;

            return objA.Equals(objB);
        }


        public static bool operator !=(ClientOrder objA, ClientOrder objB)
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
            StringBuilder strClientOrder = new StringBuilder();

            strClientOrder.Append("[ ");
            strClientOrder.Append(" orderId = " + orderId + " | ");
            strClientOrder.Append(" orderDate = " + orderDate + " | ");
            strClientOrder.Append(" orderName = " + orderName + " | ");
            strClientOrder.Append(" creditCardId = " + creditCardId + " | ");
            strClientOrder.Append(" clientOrderAddress = " + clientOrderAddress + " | ");
            strClientOrder.Append(" clientId = " + clientId + " | ");
            strClientOrder.Append("] ");

            return strClientOrder.ToString();
        }


    }
}
