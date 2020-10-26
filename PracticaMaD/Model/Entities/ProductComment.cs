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

    public partial class ProductComment
    {
        public ProductComment()
        {
            //this.CreditCardOps = new HashSet<CreditCardOp>();
        }

        public long commentId { get; set; }
        public long productId { get; set; }
        public String comentText { get; set; }
        public System.DateTime commentDate { get; set; }
        public long tagId { get; set; }
        public long commentId { get; set; }



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

                hash = hash * multiplier + commentId.GetHashCode();
                hash = hash * multiplier + productId.GetHashCode();
                hash = hash * multiplier + comentText.GetHashCode();
                hash = hash * multiplier + commentDate.GetHashCode();
                hash = hash * multiplier + CreditCardAddress.GetHashCode();
                hash = hash * multiplier + tagId.GetHashCode();
                hash = hash * multiplier + commentId.GetHashCode();
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

            ProductComment target = obj as ProductComment;

            return true
               && (this.commentId == target.commentId)
               && (this.productId == target.productId)
               && (this.comentText == target.comentText)
               && (this.commentDate == target.commentDate)
               && (this.tagId == target.tagId)
               && (this.commentId == target.commentId)
               ;

        }




        public static bool operator ==(ProductComment objA, ProductComment objB)
        {
            // Check if the objets are the same CreditCard entity
            if (Object.ReferenceEquals(objA, objB))
                return true;

            return objA.Equals(objB);
        }


        public static bool operator !=(ProductComment objA, ProductComment objB)
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
            strCreditCard.Append(" CommentId = " + commentId + " | ");
            strCreditCard.Append(" ProductId = " + productId + " | ");
            strCreditCard.Append(" ComentText = " + comentText + " | ");
            strCreditCard.Append(" CommentDate = " + commentDate + " | ");
            strCreditCard.Append(" TagId = " + tagId + " | ");
            strCreditCard.Append(" CommentId = " + commentId + " | ");
            strCreditCard.Append("] ");

            return strCreditCard.ToString();
        }


    }

}
