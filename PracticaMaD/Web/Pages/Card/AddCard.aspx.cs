using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.PracticaMad.Model.Services.CreditCardService;
using Es.Udc.DotNet.PracticaMad.Web.HTTP.Session;
using System;
using System.Linq;
using System.Web.UI;

namespace Es.Udc.DotNet.PracticaMad.Web.Pages.Card
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
                    string result = i.ToString().Substring(2);
                    dropYear.Items.Add(result);
                }
                lblRepeted.Visible = false;
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
                        long clientId = Convert.ToInt32(Request.Params.Get("clientId"));
                        string creditCardNumber = txtCreditCardNumber.Text.ToString();
                        string cardType;
                        bool defC;

                        if (chBCredit.Checked)
                            cardType = "Credit";
                        else if (chBDebit.Checked)
                            cardType = "Debit";
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

                        CreditCardDetails newCard = new CreditCardDetails(creditCardNumber, cardType, cv, date, defC, clientId);

                        SessionManager.AddCard(Context, newCard);

                        Server.Transfer(Response.ApplyAppPathModifier("./CardSuccesfulyAdded.aspx"));


                    }
                    else
                    {
                        lblCreditCardNumberFormat.Visible = true;
                    }
                }
                catch (DuplicateInstanceException)
                {
                    lblRepeted.Visible = true;
                }
            }
        }

        protected void dropYear_Load(object sender, EventArgs e)
        {
        }

        protected void dropMonth_Load(object sender, EventArgs e)
        {
        }

        protected void chBCredit_CheckedChanged(object sender, EventArgs e)
        {
            chBDebit.Checked = false;
        }

        protected void chBDebit_CheckedChanged(object sender, EventArgs e)
        {
            chBCredit.Checked = false;
        }

        protected void chBdefCard_CheckedChanged(object sender, EventArgs e)
        {
            /// defCard.Checked = false;
        }
    }
}