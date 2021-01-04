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
                ProductDetails productDetails =
                 SessionManager.FindProductDetails(Context);
                cellProductName.Text = productDetails.ProductName;
                cellProductPrize.Text = productDetails.Price.ToString();
                if (SessionManager.ExistCommentFromClient(Context))
                {
                    btnAddComment.Visible = false;
                }
                else
                {
                    btnEditComment.Visible = false;
                }
            }
        }

        protected void BtnAddCommentClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                /* Do action. */
                String url =
                    String.Format("./AddComment.aspx");

                Response.Redirect(Response.ApplyAppPathModifier(url));
            }
        }

        protected void BtnEditCommentClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                /* Do action. */
                String url =
                    String.Format("./EditComment.aspx");

                Response.Redirect(Response.ApplyAppPathModifier(url));
            }
        }
    }
}