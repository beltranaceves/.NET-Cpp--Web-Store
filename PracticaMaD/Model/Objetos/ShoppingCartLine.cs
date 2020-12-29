using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMad.Model.Objetos
{
    public class ShoppingCartLine
    {
            /// <summary>
            /// productId referes to the id of the product the customer is buying.
            /// </summary>
            public long productId { get; set; }

            /// <summary>
            /// Number of units of the product that are being bought
            /// </summary>
            public int quantity { get; set; }


            /// <summary>
            /// It represents the unitary price of the product being bought
            /// </summary>
            public double price { get; set; }
            
            /// <summary>
            /// forGift specifies if the customer wants the product to be packed for gift or not
            /// </summary>
            public bool forGift { get; set; }

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
        
                    hash = hash * multiplier + productId.GetHashCode();
                    hash = hash * multiplier + quantity.GetHashCode();
                    hash = hash * multiplier + price.GetHashCode();
                    hash = hash * multiplier + (forGift ? 1 : 0);
                
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
                
                ShoppingCartLine target = obj as ShoppingCartLine;
        
                return true
                &&  (this.productId == target.productId )       
                &&  (this.quantity == target.quantity )       
                &&  (this.price == target.price )       
                &&  (this.forGift == target.forGift )            
                ;
        
            }
        
        
            public static bool operator ==(ShoppingCartLine  objA, ShoppingCartLine  objB)
            {
                // Check if the objets are the same ShoppingCartLine entity
                if(Object.ReferenceEquals(objA, objB))
                    return true;
        
                return objA.Equals(objB);
        }
        
        
            public static bool operator !=(ShoppingCartLine  objA, ShoppingCartLine  objB)
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
                StringBuilder strShoppingCartLine = new StringBuilder();

            strShoppingCartLine.Append("[ ");
            strShoppingCartLine.Append(" productId = " + productId + " | " );       
            strShoppingCartLine.Append(" quantity = " + quantity + " | " );       
            strShoppingCartLine.Append(" price = " + price + " | " );       
            strShoppingCartLine.Append(" forGift = " + forGift + " | " );            
                strShoppingCartLine.Append("] ");    
        
                return strShoppingCartLine.ToString();
            }
        
        
        }
   
}
