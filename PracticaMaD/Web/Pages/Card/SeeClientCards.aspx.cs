using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.PracticaMad.Model;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.CreditCardDao;
using Es.Udc.DotNet.PracticaMad.Model.Services.CreditCardService;
using Es.Udc.DotNet.PracticaMad.Web.HTTP.Session;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Web;
using System.Web.UI.WebControls;

namespace Es.Udc.DotNet.PracticaMad.Web.Pages.Card
{
    public partial class SeeClientCards : SpecificCulturePage
    {
        ObjectDataSource pbpDataSource = new ObjectDataSource();

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

            List <CreditCardDetails> userCards = SessionManager.GetAllCards(Context);

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


        protected void changeDefaultCard_DataBinding(object sender, EventArgs e)
        {
            CheckBox c = sender as CheckBox;
            GridViewRow row = c.NamingContainer as GridViewRow;

            if (c != null && row.Cells[4].Text.Equals("True"))
                c.Checked = true;
        }


        protected void changeDefaultCard_CheckedChanged(object sender, EventArgs e)
        {


            CheckBox c = sender as CheckBox;
            GridViewRow row = c.NamingContainer as GridViewRow;
      
            string cardNumber = row.Cells[0].Text;
            long usrId = SessionManager.GetClientSession(Context).ClientId;

            IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];

            ICreditCardDao cardDao = (ICreditCardDao)iocManager.Resolve<ICreditCardDao>();

            CreditCard card = cardDao.FindByCreditCardNumber(row.Cells[0].Text);

            SessionManager.ChangeDefaultCard(Context,card.cardId);
            
            LoadGrid();
            
        }


        protected void gvAllCards_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = gvCardList.Rows[e.NewSelectedIndex];
            long cardId = Convert.ToInt64(row.Cells[0].Text);

            IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];

            ICreditCardDao cardDao = (ICreditCardDao)iocManager.Resolve<ICreditCardDao>();

            CreditCard card = cardDao.FindByCreditCardNumber(row.Cells[0].Text);

            cardDao.Remove(card.cardId);

            Response.Redirect(Request.RawUrl.ToString());


        }


    }
}