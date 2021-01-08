using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.CategoryDao;
using Es.Udc.DotNet.PracticaMad.Model.Services.ProductService;
using Es.Udc.DotNet.PracticaMad.Model.Services.ShoppingCartService;
using Es.Udc.DotNet.PracticaMad.Web.HTTP.Session;
using Es.Udc.DotNet.PracticaMad.Web.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Es.Udc.DotNet.PracticaMad.Web.Pages.Products
{
    public partial class ShowProductsTag : SpecificCulturePage
    {
        private ObjectDataSource pbpDataSource = new ObjectDataSource();

        protected void Page_Load(object sender, EventArgs e)
        {
            int startIndex, count;

            lnkPrevious.Visible = false;
            lnkNext.Visible = false;
            lblNoProduct.Visible = false;

            /* Get User Identifier passed as parameter in the request from
             * the previous page
             */
            string tag = Convert.ToString(Request.Params.Get("tag"));

            /* Get Start Index */
            try
            {
                startIndex = Int32.Parse(Request.Params.Get("startIndex"));
            }
            catch (ArgumentNullException)
            {
                startIndex = 0;
            }

            /* Get Count */
            try
            {
                count = Int32.Parse(Request.Params.Get("count"));
            }
            catch (ArgumentNullException)
            {
                count = Settings.Default.PracticaMad_defaultCount;
            }

            /* Get the Service */
            IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];
            IProductService productService = iocManager.Resolve<IProductService>();

            /* Get Products Info */

            ProductBlock productBlock =
               productService.FindProductByTag(tag, startIndex, count);

            if (productBlock == null || productBlock.Product.Count == 0)
            {
                lblNoProduct.Visible = true;
                return;
            }

            this.gvProduct.DataSource = productBlock.Product;
            this.gvProduct.DataBind();

            /* "Previous" link */
            if ((startIndex - count) >= 0)
            {
                String url =
                    "/Pages/Products/ShowProductsTag.aspx" + "?tag=" + tag +
                    "&startIndex=" + (startIndex - count) + "&count=" +
                    count;

                this.lnkPrevious.NavigateUrl =
                    Response.ApplyAppPathModifier(url);
                this.lnkPrevious.Visible = true;
            }
            /* "Next" link */
            if (productBlock.ExistMoreProduct)
            {
                String url =

                    "/Pages/Products/ShowProductsTag.aspx" + "?tag=" + tag +
                    "&startIndex=" + (startIndex + count) + "&count=" +
                    count;

                this.lnkNext.NavigateUrl =
                    Response.ApplyAppPathModifier(url);
                this.lnkNext.Visible = true;
            }
        }

        protected void ContactsGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Show")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvProduct.Rows[index];
                long id = Convert.ToInt32(row.Cells[0].Text);

                IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];

                ProductDetails productDetails = SessionManager.FindProductDetails(id);

                String url = null;

                if (productDetails is BooksDetails)
                {
                    BooksDetails b = productDetails as BooksDetails;

                    url = String.Format("./ProductBooksDetails.aspx?prodId={0}", id);
                }
                else if (productDetails is MusicDetails)
                {
                    MusicDetails b = productDetails as MusicDetails;

                    url = String.Format("./ProductMusicDetails.aspx?prodId={0}", id);
                }
                else if (productDetails is FilmsDetails)
                {
                    FilmsDetails b = productDetails as FilmsDetails;

                    url = String.Format("./ProductFilmsDetails.aspx?prodId={0}", id);
                }
                else
                    url = String.Format("./ShowOneProduct.aspx?prodId={0}", id);

                Response.Redirect(Response.ApplyAppPathModifier(url));
            }
            if (e.CommandName == "Add")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvProduct.Rows[index];

                IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];

                IShoppingCartService shoppingCartService = (IShoppingCartService)iocManager.Resolve<IShoppingCartService>();

                long productId = Convert.ToInt32(row.Cells[0].Text);

                var quantity2 = row.Cells[4].FindControl("quantityList") as DropDownList;

                int quantity = Convert.ToInt32(quantity2.SelectedValue);

                shoppingCartService.AddToCart(productId, quantity, SessionManager.shoppingCart);

                Response.Redirect(Request.RawUrl.ToString());
            }
        }
    }
}