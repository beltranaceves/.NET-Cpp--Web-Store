using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.PracticaMad.Model;
using Es.Udc.DotNet.PracticaMad.Model.Services.ClientService;
using Es.Udc.DotNet.PracticaMad.Model.Services.ProductCommentService;
using Es.Udc.DotNet.PracticaMad.Model.Services.ProductService;
using Es.Udc.DotNet.PracticaMad.Web.HTTP.Session;
using Es.Udc.DotNet.PracticaMad.Web.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Es.Udc.DotNet.PracticaMad.Web.Pages.Products
{
    public partial class ProductBooksDetails : SpecificCulturePage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadGrid();
            }
        }


        private void LoadGrid()
        {
            int startIndex, count;
            string updated;

            IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];

            IProductService productService = iocManager.Resolve<IProductService>();

            long prodId;

            prodId =Int32.Parse(Request.Params.Get("prodId"));

            ProductDetails productDetails = SessionManager.FindProductDetails(prodId);

            BooksDetails bk = productDetails as BooksDetails;

            
            cellAuthor.Text = bk.Author;
            cellPages.Text = bk.Pages.ToString();
            cellISBN.Text =   bk.ISBN.ToString();
            cellEditorial.Text = bk.Editorial;

            cellProductName.Text = bk.ProductName;
            cellProductPrize.Text = bk.Price.ToString();
            cellProductCategory.Text = bk.CategoryName;

            /* Get Start Index */
            try
            {
                startIndex = Int32.Parse(Request.Params.Get("startIndex"));
            }
            catch (ArgumentNullException)
            {
                startIndex = 0;
            }
            try
            {
                updated = Request.Params.Get("prod");
                lblEditedProduct.Visible = true;
            }
            catch (ArgumentNullException)
            {
                lblEditedProduct.Visible = false;
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
            IProductCommentService productCommentService = iocManager.Resolve<IProductCommentService>();

            ProductCommentBlock productCommentBlock =
                    productCommentService.FindByProductId(prodId, startIndex, count);

            this.gvComment.DataSource = productCommentBlock.ProductComment;
            this.gvComment.DataBind();


            if (SessionManager.IsClientAuthenticated(Context))
            { //If Client has a comment -> Edit
              //If Client doesn't have a comment -> Create
                if (SessionManager.ExistCommentFromClient(Context, prodId))
                {
                    btnEditComment.Visible = true;
                    btnAddComment.Visible = false;
                }
                else
                {
                    btnAddComment.Visible = true;
                    btnEditComment.Visible = false;
                }

                //Edit the product, only ADMIN users
                ClientDetails client = SessionManager.FindClientDetails(Context);
                if (client.Rol == "ADMIN")
                {
                    btnEditProduct.Visible = true;
                }
                else
                {
                    btnEditProduct.Visible = false;
                }
            }
        }

        protected void BtnAddCommentClick(object sender, EventArgs e)
            {
                if (Page.IsValid)
                {
                    try
                    {
                        long prodId = Int32.Parse(Request.Params.Get("prodId"));
                        /* Do action. */
                        String url =
                            String.Format("./AddComment.aspx?prodId=" + prodId);

                        Response.Redirect(Response.ApplyAppPathModifier(url));
                    }
                    catch (ArgumentNullException)
                    {
                        lblInvalidProduct.Visible = true;
                    }
                }
            }

            protected void BtnEditCommentClick(object sender, EventArgs e)
            {
                if (Page.IsValid)
                {
                    try
                    {
                        long prodId = Int32.Parse(Request.Params.Get("prodId"));

                        /* Do action. */
                        String url =
                            String.Format("./EditComment.aspx?prodId=" + prodId);

                        Response.Redirect(Response.ApplyAppPathModifier(url));
                    }
                    catch (ArgumentNullException)
                    {
                        lblInvalidProduct.Visible = true;
                    }
                }
            }

            protected void BtnEditProductClick(object sender, EventArgs e)
            {
                if (Page.IsValid)
                {
                    try
                    {
                        long prodId = Int32.Parse(Request.Params.Get("prodId"));

                        /* Do action. */
                        String url =
                            String.Format("./UpdateBooks.aspx?prodId=" + prodId);

                        Response.Redirect(Response.ApplyAppPathModifier(url));
                    }
                    catch (ArgumentNullException)
                    {
                        lblInvalidProduct.Visible = true;
                    }
                }
            }

        }
}