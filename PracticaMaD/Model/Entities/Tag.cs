//------------------------------------------------------------------------------
// <auto-generated>
//     Este c�digo se gener� a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicaci�n.
//     Los cambios manuales en este archivo se sobrescribir�n si se regenera el c�digo.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Es.Udc.DotNet.PracticaMaD.Model
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    public partial class Tag
    {
        public Tag()
        {
            //this.CreditCardOps = new HashSet<CreditCardOp>();
        }

        public long tagId { get; set; }
        public long tagName { get; set; }




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

                hash = hash * multiplier + tagId.GetHashCode();
                hash = hash * multiplier + tagName.GetHashCode();
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

            Tag target = obj as Tag;

            return true
               && (this.tagId == target.tagId)
               && (this.tagName == target.tagName)
               ;

        }




        public static bool operator ==(Tag objA, Tag objB)
        {
            // Check if the objets are the same CreditCard entity
            if (Object.ReferenceEquals(objA, objB))
                return true;

            return objA.Equals(objB);
        }


        public static bool operator !=(Tag objA, Tag objB)
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
            strCreditCard.Append(" TagId = " + tagId + " | ");
            strCreditCard.Append(" TagName = " + tagName + " | ");
            strCreditCard.Append("] ");

            return strCreditCard.ToString();
        }


    }

}
