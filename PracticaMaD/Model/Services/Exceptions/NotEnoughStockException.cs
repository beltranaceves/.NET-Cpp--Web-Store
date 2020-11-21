using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMad.Model.Services.Exceptions
{
    public class NotEnoughStockException : Exception

    {
        public NotEnoughStockException(String name, int stock)
             : base(name + " " +  stock)
        {

        }
    }
}
