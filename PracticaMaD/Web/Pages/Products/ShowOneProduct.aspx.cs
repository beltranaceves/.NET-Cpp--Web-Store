using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.PracticaMad.Model;
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
    public partial class ShowOneProduct : SpecificCulturePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    int startIndex, count;
                    long prodId;
                    lnkPrevious.Visible = false;
                    lnkNext.Visible = false;
                    prodId = Int32.Parse(Request.Params.Get("prodId"));
                    ProductDetails productDetails =
                            SessionManager.FindProductDetails(Context, prodId);
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
                    IProductCommentService productCommentService = iocManager.Resolve<IProductCommentService>();

                    /* Get Comments */
                    ProductCommentBlock productCommentBlock =
                        productCommentService.FindByProductId(prodId, startIndex, count);

                    if (productCommentBlock.ProductComment.Count == 0)
                    {
                        lblInvalidProduct.Visible = true;
                        return;
                    }

                    this.gvComment.DataSource = productCommentBlock.ProductComment;
                    this.gvComment.DataBind();

                    /* "Previous" link */
                    if ((startIndex - count) >= 0)
                    {
                        String url =
                            "/Pages/Products/ShowOneProducts.aspx" + "?prodId=" + prodId +
                            "&startIndex=" + (startIndex - count) + "&count=" +
                            count;

                        this.lnkPrevious.NavigateUrl =
                            Response.ApplyAppPathModifier(url);
                        this.lnkPrevious.Visible = true;
                    }

                    /* "Next" link */
                    if (productCommentBlock.ExistMoreProductComment)
                    {
                        String url =

                            "/Pages/Products/ShowProducts.aspx" + "?prodId=" + prodId +
                            "&startIndex=" + (startIndex + count) + "&count=" +
                            count;

                        this.lnkNext.NavigateUrl =
                            Response.ApplyAppPathModifier(url);
                        this.lnkNext.Visible = true;
                    }

                    /* Get Product Id */

                    cellProductName.Text = productDetails.ProductName;
                    cellProductPrize.Text = productDetails.Price.ToString();
                    if (SessionManager.ExistCommentFromClient(Context, prodId))
                    {
                        btnAddComment.Visible = false;
                    }
                    else
                    {
                        btnEditComment.Visible = false;
                    }
                }
                catch (ArgumentNullException)
                {
                    lblInvalidProduct.Visible = true;
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
    }
}