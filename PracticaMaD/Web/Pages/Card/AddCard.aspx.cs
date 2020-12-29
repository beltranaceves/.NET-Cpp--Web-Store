using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.ModelUtil.IoC;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Es.Udc.DotNet.PracticaMad.Web.HTTP.Session;
using Es.Udc.DotNet.PracticaMad.Model.Services.CreditCardService;

namespace Es.Udc.DotNet.PracticaMaD.WebApplication.Pages.Card
{
    public partial class AddCard : SpecificCulturePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                for (int i = 1; i < 13; i++)
                {
                    dropMonth.Items.Add(i.ToString());
                }


                for (int i = DateTime.Now.Year; i <= (DateTime.Now.Year + 10); i++)
                {
                    dropYear.Items.Add(i.ToString());
                }

               
            }
        }

        protected void btnAddCard_Click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {
                try
                {
                    if (txtCreditCardNumber.Text.Count() == 16)
                    {

                        IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];
                        ICreditCardService creditCardService = (ICreditCardService)iocManager.Resolve<ICreditCardService>();

                        string creditCardNumber = txtCreditCardNumber.Text.ToString();

                        string cardType;

                        bool defC;

                        if (chBVisa.Checked == true)
                            cardType = "Visa";
                        else if (chBMasterCard.Checked)
                            cardType = "MasterCard";
                        else
                            throw new Exception("cardType");

                        long cv = long.Parse(txtCV.Text);
                        if (txtCV.Text.Count() != 3)
                            throw new Exception("cv");

                        string date = dropMonth.SelectedItem.Text + "/" + dropYear.SelectedItem.Text;

                        if (defCard.Checked == true)
                            defC = true;
                         else
                            defC = false;

                        CreditCardDetails newCard = new CreditCardDetails(creditCardNumber, cardType, cv, date, defC,0);

                        creditCardService.AddCard(SessionManager.GetClientSession(Context).ClientId, newCard);

                    
                    }
                    else
                    {
                        lblCreditCardNumberFormat.Visible = true;
                    }
                }
                
                catch (DuplicateInstanceException)
                {
                    lblCreditCardNumberError.Visible = true;
                }
                catch (Exception w)
                {
                    if (w.Message.Equals("cv"))
                        lblCVError.Visible = true;
                    else
                        lblCardTypeError.Visible = true;
                }
            }
        }

        protected void dropYear_Load(object sender, EventArgs e)
        {

        }

        protected void dropMonth_Load(object sender, EventArgs e)
        {

        }

        protected void chBVisa_CheckedChanged(object sender, EventArgs e)
        {
            chBVisa.Checked = false;
        }

        protected void chBMasterCard_CheckedChanged(object sender, EventArgs e)
        {
            chBMasterCard.Checked = false;
        }
    }
}