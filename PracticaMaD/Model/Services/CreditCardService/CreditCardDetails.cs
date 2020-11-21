using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMad.Model.Services.CreditCardService
{
    [Serializable()]
    public class CreditCardDetails
    {
        #region Properties region

        public string CardNumber { get;}

        public string CardType { get; }

        public long VerificationCode { get; }

        public string ExpeditionDate { get; }

        public bool DefaultCard { get; }

        public long ClientId { get; }


        #endregion

        public CreditCardDetails(string cardNumber, string cardType,long verificationCode,string expeditionDate,
        bool defaultCard, long clientId)
        {
            this.CardNumber = cardNumber;
            this.CardType = cardType;
            this.VerificationCode = verificationCode;
            this.ExpeditionDate = expeditionDate;
            this.DefaultCard = defaultCard;
            this.ClientId = clientId;
        }

        public CreditCardDetails(string cardNumber, int verificationCode, string expeditionDate, string cardType)
        {
            this.CardNumber = cardNumber;
            this.VerificationCode = verificationCode;
            this.ExpeditionDate = expeditionDate;
            this.CardType = cardType;
        }
    }
}
