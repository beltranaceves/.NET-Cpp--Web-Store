using Es.Udc.DotNet.PracticaMad.Model;
using Es.Udc.DotNet.PracticaMad.Model.Services.ProductService;
using Es.Udc.DotNet.PracticaMad.Web.HTTP.Session;
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
                long prodId;
                /* Get Product Id */
                try
                {
                    prodId = Int32.Parse(Request.Params.Get("prodId"));
                    ProductDetails productDetails =
                            SessionManager.FindProductDetails(Context, prodId);
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