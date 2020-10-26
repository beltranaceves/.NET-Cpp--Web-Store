namespace Es.Udc.DotNet.PracticaMaD.Model
{
    using System;
    using System.Text;

    public partial class ClientOrderLine
    {
        public ClientOrderLine()
        {
            //this.clientOps = new HashSet<clientOp>();
        }

        public long orderLineId { get; set; }
        public long orderId { get; set; }
        public long productId  { get; set; }
        public int quantity { get; set; }
        public float price { get; set; }

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

                hash = hash * multiplier + orderLineId.GetHashCode();
                hash = hash * multiplier + orderId.GetHashCode();
                hash = hash * multiplier + productId.GetHashCode();
                hash = hash * multiplier + quantity.GetHashCode();
                hash = hash * multiplier + price.GetHashCode();

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

            ClientOrderLine target = obj as ClientOrderLine;

            return true
               && (this.orderLineId == target.orderLineId)
               && (this.orderId == target.orderId)
               && (this.productId== target.productId)
               && (this.quantity == target.quantity)
               && (this.price== target.price)
               ;

        }


        public static bool operator ==(ClientOrderLine objA, ClientOrderLine objB)
        {
            // Check if the objets are the same client entity
            if (Object.ReferenceEquals(objA, objB))
                return true;

            return objA.Equals(objB);
        }


        public static bool operator !=(ClientOrderLine objA, ClientOrderLine objB)
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
            StringBuilder strClientOrderLine = new StringBuilder();

            strClientOrderLine.Append("[ ");
            strClientOrderLine.Append(" orderLineId = " + orderLineId + " | ");
            strClientOrderLine.Append(" orderId = " + orderId + " | ");
            strClientOrderLine.Append(" productId = " + productId + " | ");
            strClientOrderLine.Append(" quantity = " + quantity + " | ");
            strClientOrderLine.Append(" price = " + price + " | ");
            strClientOrderLine.Append("] ");

            return strClientOrderLine.ToString();
        }


    }
}
