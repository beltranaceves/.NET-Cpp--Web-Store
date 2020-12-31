using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Es.Udc.DotNet.PracticaMad.Web.HTTP.Session
{
    public class CreditCardSession
    {

        private long cardId;
        private String cardNumber;

        public long CardId
        {
            get { return cardId; }
            set { cardId = value; }
        }

        public String CardNumber
        {
            get { return cardNumber; }
            set { cardNumber = value; }
        }



    }
}