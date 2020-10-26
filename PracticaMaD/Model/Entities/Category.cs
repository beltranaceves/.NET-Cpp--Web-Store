namespace Es.Udc.DotNet.PracticaMaD.Model
{
    using System;
    using System.Text;

    public partial class Category
    {
        public Category()
        {
            //this.clientOps = new HashSet<clientOp>();
        }

        public long categoryId { get; set; }
        public String categoryName { get; set; }
    

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

                hash = hash * multiplier + categoryId.GetHashCode();
                hash = hash * multiplier + categoryName.GetHashCode();


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

            Category target = obj as Category;

            return true
               && (this.categoryId== target.categoryId)
               && (this.categoryName == target.categoryName)

               ;

        }


        public static bool operator ==(Category objA, Category objB)
        {
            // Check if the objets are the same client entity
            if (Object.ReferenceEquals(objA, objB))
                return true;

            return objA.Equals(objB);
        }


        public static bool operator !=(Category objA, Category objB)
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
            StringBuilder strCategory = new StringBuilder();

            strCategory.Append("[ ");
            strCategory.Append(" categoryId = " + categoryId + " | ");
            strCategory.Append(" categoryName = " + categoryName + " | ");
    
            strCategory.Append("] ");

            return strCategory.ToString();
        }


    }
}
