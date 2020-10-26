using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6_Tutorial_CodeFirst
{
    [Table("EF6CodeFirst.Account")]
    public class Account
    {
        public Account() { }

        [Key]
        public long accId { get; set; }
        public long usrId { get; set; }
        public double balance { get; set; }

        // Navigation Properties
        public ICollection<AccountOp> AccountOps { get; set; }

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
            StringBuilder strAccount = new StringBuilder();

            strAccount.Append("[ ");
            strAccount.Append(" accId = " + accId + " | ");
            strAccount.Append(" usrId = " + usrId + " | ");
            strAccount.Append(" balance = " + balance + " | ");
            strAccount.Append("] ");

            return strAccount.ToString();
        }
    }

    [Table("EF6CodeFirst.AccountOp")]
    public class AccountOp
    {
        public AccountOp() { }

        [Key]
        public long accOpId { get; set; }

        [ForeignKey("Account")]
        public long accId { get; set; }
        public DateTime date { get; set; }
        public byte type { get; set; }
        public double amount { get; set; }

        // Navigation Properties
        public Account Account { get; set; }

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
            StringBuilder strAccountOp = new StringBuilder();

            strAccountOp.Append("[ ");
            strAccountOp.Append(" accOpId = " + accOpId + " | ");
            strAccountOp.Append(" accId = " + accId + " | ");
            strAccountOp.Append(" date = " + date + " | ");
            strAccountOp.Append(" type = " + type + " | ");
            strAccountOp.Append(" amount = " + amount + " | ");
            strAccountOp.Append("] ");

            return strAccountOp.ToString();
        }

    }

}