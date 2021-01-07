using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.PracticaMad.Model;
using Es.Udc.DotNet.PracticaMad.Model.Objetos;
using Es.Udc.DotNet.PracticaMad.Model.Services.ClientOrderService;
using Es.Udc.DotNet.PracticaMad.Model.Services.ClientService;
using Es.Udc.DotNet.PracticaMad.Model.Services.CreditCardService;
using Es.Udc.DotNet.PracticaMad.Model.Services.ProductService;
using Es.Udc.DotNet.PracticaMad.Model.Services.ShoppingCartService;
using Es.Udc.DotNet.PracticaMad.Web.HTTP.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Es.Udc.DotNet.PracticaMad.Web.Pages.Orders
{
    public partial class ManageOrder : SpecificCulturePage
    {
        ObjectDataSource pbpDataSource = new ObjectDataSource();
       
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

                double price = 0;

                for (int i = 0; i < SessionManager.shoppingCart.shoppingCartLines.Count; i++)
                {

                    price += SessionManager.shoppingCart.shoppingCartLines.ElementAt(i).totalPrice;
                }

                
                txtPrizeTotal.Text = ((price)).ToString();


                lblClientAddres.Text = SessionManager.FindClientDetails(Context).ClientAddress;

                txtAddress.Text = "Direccion";

                ManageLabels();

                LoadGrid();
             
                LoadGrid2();

     
              
            }

            

        }

        private void ManageLabels()
        {

            //Inicialmente escondemos los campos de la opcion de 
            //a;adir una nueva direccion o tarjeta, estos se vuelven visibles
            //cuando se hace click en sus botones
            txtCreditCardNumber.Text = "1111111111111111";
            txtCV.Text = "111";
            txtDescription.Text = "Descripcion";


            chBCredit.Visible = false;
            chBDebit.Visible = false;
            txtCreditCardNumber.Visible = false;
            dropMonth.Visible = false;
            dropYear.Visible = false;
            txtCV.Visible = false;
            txtAddress.Visible = false;

            lclCardNumber.Visible = false;
            lclCardType.Visible = false;
            lclExpirationDate.Visible = false;
            lclCV.Visible = false;

            lclAddress.Visible = false;
            CloseAddres.Visible = false;
            ButtonCreditCardClose.Visible = false;

            lblNoCards.Visible = false;
            lblShoppingCartEmpty.Visible = false;

        }

        protected void gvProductsToPay_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //e.Row.Cells[3].Visible = false;
        }

        protected void gvProductsToPay_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
           
        }

        protected void btnAddres_Click(object sender, EventArgs e)
        {
            txtAddress.Visible = true;
            CloseAddres.Visible = true;
            lclAddress.Visible = true;

        }

        protected void btnCloseAddres_Click(object sender, EventArgs e)
        {
            txtAddress.Visible = false;
            CloseAddres.Visible = false;
            lclAddress.Visible = false;
        }

        protected void btnCreditCard_Click(object sender, EventArgs e)
        {

            chBCredit.Visible = true;
            chBDebit.Visible = true;
            txtCreditCardNumber.Visible = true;
            dropMonth.Visible = true;
            dropYear.Visible = true;
            txtCV.Visible = true;

            lclCardNumber.Visible = true;
            lclCardType.Visible = true;
            lclExpirationDate.Visible = true;
            lclCV.Visible = true;

            ButtonCreditCardClose.Visible = true;

            gvCards.Visible = false;
        }


        protected void btnCreditCardClose_Click(object sender, EventArgs e)
        {

            chBCredit.Visible = false;
            chBDebit.Visible = false;
            txtCreditCardNumber.Visible = false;
            dropMonth.Visible = false;
            dropYear.Visible = false;
            txtCV.Visible = false;

            lclCardNumber.Visible = false;
            lclCardType.Visible = false;
            lclExpirationDate.Visible = false;
            lclCV.Visible = false;

            ButtonCreditCardClose.Visible = false;

            gvCards.Visible = true;


        }


        protected void btnToPay_Click(object sender, EventArgs e)
        {
             IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];

             IClientOrderService orderService = (IClientOrderService)iocManager.Resolve<IClientOrderService>();
             ICreditCardService creditCardService = (ICreditCardService)iocManager.Resolve<ICreditCardService>();

            long clientId = SessionManager.GetClientSession(Context).ClientId;

            long cardId = 0;

            string addres = null;



            //Comrpobamos si cogemos la direccion por defecto (dejando addres a null)
            //o si quiere una en concreto
            if (lclAddress.Visible == true)
                     addres = txtAddress.Text;


                 //Comprobamos si el cliente desea pagar con una tarejata nueva
                 //si no fuese asi el valro de cardId seria null y se cogeria la de por defecto 
                 if (chBCredit.Visible == true)
                 {
                    string cardType = null;

                    if (chBCredit.Checked)
                         cardType = "Credit";
                     else if (chBDebit.Checked)
                         cardType = "Debit";
                   

                     long cv = long.Parse(txtCV.Text);
                     if (txtCV.Text.Count() != 3)
                         throw new Exception("cv");

                     string date = dropMonth.SelectedItem.Text + "/" + dropYear.SelectedItem.Text;

                     var newCard = new CreditCardDetails(txtCreditCardNumber.Text, cardType, cv, date, false, clientId);

                     SessionManager.AddCard(Context, newCard);

                     cardId = creditCardService.GetCardFromNumber(txtCreditCardNumber.Text).cardId;

                 }

                 else
                 {
                    CreditCardDetails card = creditCardService.GetClientDefaultCard(clientId);
                    cardId = creditCardService.GetCardFromNumber(card.CardNumber).cardId;
                 }



            IShoppingCartService shop = (IShoppingCartService)iocManager.Resolve<IShoppingCartService>();

            orderService.CreateOrder(clientId, cardId, txtDescription.Text, addres, SessionManager.shoppingCart);

            SessionManager.DeleteShoppingCart();

            Server.Transfer(Response.ApplyAppPathModifier("./PurchaseConfirmation.aspx"));



        }

        protected void quantityList_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            DropDownList drop = sender as DropDownList;

            int units = Convert.ToInt32(drop.SelectedItem.Text);

            GridViewRow row = drop.NamingContainer as GridViewRow;

            long productId = (long)Convert.ToInt32(row.Cells[0].Text);

            IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];

            IShoppingCartService shop = (IShoppingCartService)iocManager.Resolve<IShoppingCartService>();


            for (int i = 0; i < SessionManager.shoppingCart.shoppingCartLines.Count; i++)
            {
                if (SessionManager.shoppingCart.shoppingCartLines.ElementAt(i).productId == productId)

                    shop.UpdateNumberOfUnits(SessionManager.shoppingCart.shoppingCartLines.ElementAt(i), SessionManager.shoppingCart, units);
            }

           List<ShoppingCartLine> f = SessionManager.shoppingCart.shoppingCartLines;

           gvShoppingCart.DataSource = f;

           gvShoppingCart.DataBind();


            double price = 0;
            for (int i = 0; i < SessionManager.shoppingCart.shoppingCartLines.Count; i++)
            {

                price += SessionManager.shoppingCart.shoppingCartLines.ElementAt(i).price * SessionManager.shoppingCart.shoppingCartLines.ElementAt(i).quantity;
            }
           
            txtPrizeTotal.Text = ((decimal)price).ToString();

           
            Response.Redirect(Request.RawUrl.ToString());
        }

        protected void cbForGift_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox c = sender as CheckBox;
            GridViewRow row = c.NamingContainer as GridViewRow;

            long productId = (long)Convert.ToInt32(row.Cells[0].Text);

            IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];

            IShoppingCartService shop = (IShoppingCartService)iocManager.Resolve<IShoppingCartService>();


            for (int i = 0; i < SessionManager.shoppingCart.shoppingCartLines.Count; i++)
            {
                if (SessionManager.shoppingCart.shoppingCartLines.ElementAt(i).productId == productId)
                {
                    if (SessionManager.shoppingCart.shoppingCartLines.ElementAt(i).forGift == true)
                         shop.UpdateForGiftStatus(SessionManager.shoppingCart.shoppingCartLines.ElementAt(i), SessionManager.shoppingCart, false);
                    else
                        shop.UpdateForGiftStatus(SessionManager.shoppingCart.shoppingCartLines.ElementAt(i), SessionManager.shoppingCart, true);

                }


            }

            List<ShoppingCartLine> f = SessionManager.shoppingCart.shoppingCartLines;

            gvShoppingCart.DataSource = f;

            gvShoppingCart.DataBind();

            LoadGrid2();

        }

        protected void selectPayMent_DataBinding(object sender, EventArgs e)
        {
        }

        protected void selectPayMent_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void gvCards_PageIndexChanging(object sender, EventArgs e)
        {
        }

        protected void gvCards_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            gvCards.PageIndex = e.NewSelectedIndex;
            gvCards.DataBind();
        }

        protected void btnCredirCard_Click(object sender, EventArgs e)
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

 

        protected void gvShoppingCart_RowCreated(object sender, EventArgs e)
        {
        }

        protected void gvShoppingCart_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = gvShoppingCart.Rows[e.NewSelectedIndex];

            long productId = (long)Convert.ToInt32(row.Cells[0].Text);

            IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];

            IShoppingCartService shop = (IShoppingCartService)iocManager.Resolve<IShoppingCartService>();


            SessionManager.DeleteShoppingCartOneRow(productId);



            gvShoppingCart.DataSource = SessionManager.shoppingCart.shoppingCartLines;
            gvShoppingCart.DataBind();

            if (SessionManager.shoppingCart.shoppingCartLines.Count <= 0)

                btnPay.Visible = false;


            Response.Redirect(Request.RawUrl.ToString());


        }

        protected void gvShoppingCart_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            {
                var units = e.Row.Cells[6].FindControl("quantityList") as DropDownList;
                if (units != null)
                {
                    if (Convert.ToInt32(e.Row.Cells[3].Text) <= 10)
                    {
                        units.SelectedValue = e.Row.Cells[3].Text;
                    }
                    else
                    {
                        units.SelectedValue = "1";
                    }
                }

                var forGift = e.Row.Cells[3].FindControl("cbForGift") as CheckBox;
                if (forGift != null)
                {

   
                }
            }






        }


        protected void cbForGift_DataBinding(object sender, EventArgs e)
        {
            CheckBox c = sender as CheckBox;
            GridViewRow row = c.NamingContainer as GridViewRow;

            long productId = (long)Convert.ToInt32(row.Cells[0].Text);


            for (int i = 0; i < SessionManager.shoppingCart.shoppingCartLines.Count; i++)
            {
                if (SessionManager.shoppingCart.shoppingCartLines.ElementAt(i).productId == productId &&
                    SessionManager.shoppingCart.shoppingCartLines.ElementAt(i).forGift == true)
                    c.Checked = true;

            }

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

            ICreditCardService creditCardService = (ICreditCardService)iocManager.Resolve<ICreditCardService>();

            CreditCard card = creditCardService.GetCardFromNumber(row.Cells[0].Text);

            SessionManager.ChangeDefaultCard(Context, card.cardId);

            LoadGrid();
        }

        private void LoadGrid()
        {
            List<CreditCardDetails> userCards = SessionManager.GetAllCards(Context);

            if (userCards.Count == 0)
            {
                lblNoCards.Visible = true;
                return;
            }

            gvCards.DataSource = userCards;
            gvCards.DataBind();

             
        }

        private void LoadGrid2()
        {

            if (SessionManager.shoppingCart.shoppingCartLines.Count == 0)
            {
                lblShoppingCartEmpty.Visible = true;
                return;
            }

            List<ShoppingCartLine> f = SessionManager.shoppingCart.shoppingCartLines;


            gvShoppingCart.DataSource = f;
            gvShoppingCart.DataBind();


        }
    }
}
