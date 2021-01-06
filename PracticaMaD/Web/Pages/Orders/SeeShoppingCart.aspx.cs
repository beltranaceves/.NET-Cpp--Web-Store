using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.PracticaMad.Model.Objetos;
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
    public partial class SeeShoppingCart : System.Web.UI.Page
    {
        private List<ShoppingCartLine> f = new List<ShoppingCartLine>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                f = SessionManager.shoppingCart.shoppingCartLines;

                double price = 0;

                for (int i = 0; i < SessionManager.shoppingCart.shoppingCartLines.Count; i++)
                {
                    price += SessionManager.shoppingCart.shoppingCartLines.ElementAt(i).totalPrice;
                }

                txtPrizeTotal.Text = ((price)).ToString();

                //AnhadirDatos();

                LoadGrid2();
            }
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

            f = SessionManager.shoppingCart.shoppingCartLines;

            gvShoppingCart.DataSource = f;

            gvShoppingCart.DataBind();

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

            f = SessionManager.shoppingCart.shoppingCartLines;

            gvShoppingCart.DataSource = f;

            gvShoppingCart.DataBind();

            LoadGrid2();
        }

        protected void btnToPay_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Orders/ManageOrder.aspx");
        }

        protected void gvShoppingCart_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = gvShoppingCart.Rows[e.NewSelectedIndex];

            long productId = (long)Convert.ToInt32(row.Cells[0].Text);

            IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];

            IShoppingCartService shop = (IShoppingCartService)iocManager.Resolve<IShoppingCartService>();

            for (int i = 0; i < SessionManager.shoppingCart.shoppingCartLines.Count; i++)
            {
                if (SessionManager.shoppingCart.shoppingCartLines.ElementAt(i).productId == productId)

                    shop.RemoveFromCart(SessionManager.shoppingCart.shoppingCartLines.ElementAt(i), SessionManager.shoppingCart);
            }

            gvShoppingCart.DataSource = SessionManager.shoppingCart.shoppingCartLines;
            gvShoppingCart.DataBind();
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
                    //Pendiente hacer el for gift

                    //long productId = Convert.ToInt32(e.Row.Cells[0].Text);

                    //ProductDetails productDetails = SessionManager.GetProductFromCart(productId);

                    //forGift.Checked = productDetails.forGift;
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

        protected void gvShoppingCart_RowCreated(object sender, EventArgs e)
        {
        }

        private void LoadGrid2()
        {
            f = SessionManager.shoppingCart.shoppingCartLines;

            gvShoppingCart.DataSource = f;
            gvShoppingCart.DataBind();
        }
    }
}