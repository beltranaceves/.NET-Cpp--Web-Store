using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.PracticaMad.Model;
using Es.Udc.DotNet.PracticaMad.Model.Services.CreditCardService;
using Es.Udc.DotNet.PracticaMad.Web.HTTP.Session;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;

namespace Es.Udc.DotNet.PracticaMad.Web.Pages.Card
{
    public partial class SeeClientCards : SpecificCulturePage
    {
        private ObjectDataSource pbpDataSource = new ObjectDataSource();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadGrid();
            }
        }

        private void LoadGrid()
        {
            lblNoCards.Visible = false;

            List<CreditCardDetails> userCards = SessionManager.GetAllCards(Context);

            if (userCards.Count == 0)
            {
                lblNoCards.Visible = true;
                return;
            }
            gvCardList.DataSource = userCards;
            gvCardList.DataBind();
        }

        protected void gvCardList_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            gvCardList.PageIndex = e.NewSelectedIndex;
            gvCardList.DataBind();
        }

        protected void ChangeDefaultCard_DataBinding(object sender, EventArgs e)
        {
            CheckBox c = sender as CheckBox;
            GridViewRow row = c.NamingContainer as GridViewRow;

            if (c != null && row.Cells[4].Text.Equals("True"))
                c.Checked = true;
        }

        protected void ChangeDefaultCard_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox c = sender as CheckBox;
            GridViewRow row = c.NamingContainer as GridViewRow;

            string cardNumber = row.Cells[0].Text;
            long usrId = SessionManager.GetClientSession(Context).ClientId;

            IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];

            ICreditCardService cardService = (ICreditCardService)iocManager.Resolve<ICreditCardService>();

            CreditCard card = cardService.GetCardFromNumber(row.Cells[0].Text);

            SessionManager.ChangeDefaultCard(Context, card.cardId);

            LoadGrid();
        }
    }
}