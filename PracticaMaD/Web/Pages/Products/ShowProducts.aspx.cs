using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.PracticaMad.Model;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.CategoryDao;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ProductDao;
using Es.Udc.DotNet.PracticaMad.Model.Objetos;
using Es.Udc.DotNet.PracticaMad.Model.Services.ProductService;
using Es.Udc.DotNet.PracticaMad.Model.Services.ShoppingCartService;
using Es.Udc.DotNet.PracticaMad.Web.HTTP.Session;
using Es.Udc.DotNet.PracticaMad.Web.Properties;
using System;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Es.Udc.DotNet.PracticaMad.Web.Pages.Products
{
    public partial class ShowProducts : SpecificCulturePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int startIndex, count;

            lnkPrevious.Visible = false;
            lnkNext.Visible = false;
            lblNoProduct.Visible = false;

            /* Get User Identifier passed as parameter in the request from
             * the previous page
             */
            string keyword = Convert.ToString(Request.Params.Get("keyword"));

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

            IProductDao productDao = (IProductDao)iocManager.Resolve<IProductDao>();

            ICategoryDao categoryDao = (ICategoryDao)iocManager.Resolve<ICategoryDao>();

            /* Get Accounts Info */
            ProductBlock productBlock =
                productService.FindProductByProductNameKeyword(keyword, startIndex, count);

            if (productBlock.Product.Count == 0)
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
                    "/Pages/Products/ShowProducts.aspx" + "?keyword=" + keyword +
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

                    "/Pages/Products/ShowProducts.aspx" + "?keyword=" + keyword +
                    "&startIndex=" + (startIndex + count) + "&count=" +
                    count;

                this.lnkNext.NavigateUrl =
                    Response.ApplyAppPathModifier(url);
                this.lnkNext.Visible = true;
            }
        }

        protected void gvProduct_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = gvProduct.Rows[e.NewSelectedIndex];

            //string pName = row.Cells[0].Text;

            IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];

            IShoppingCartService shoppingCartService = (IShoppingCartService)iocManager.Resolve<IShoppingCartService>();

            //IProductService productService = (IProductService)iocManager.Resolve<IProductService>();

            //Product p = productService.productByName(pName);

            long productId = (long)Convert.ToInt32(row.Cells[0].Text);


            shoppingCartService.AddToCart(productId, 1, SessionManager.shoppingCart);

            Response.Redirect(Request.RawUrl.ToString());
        }

        protected void ContactsGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Show")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvProduct.Rows[index];
                long id = Convert.ToInt32(row.Cells[0].Text);

                /* Do action. */
                String url =
                    String.Format("./ShowOneProduct.aspx?prodId={0}", id);

                Response.Redirect(Response.ApplyAppPathModifier(url));
            }
        }
    }
}