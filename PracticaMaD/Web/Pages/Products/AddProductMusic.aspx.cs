using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.PracticaMad.Model;
using Es.Udc.DotNet.PracticaMad.Model.Services.ProductService;
using Es.Udc.DotNet.PracticaMad.Web.HTTP.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Es.Udc.DotNet.PracticaMad.Web.Pages.Products
{
    public partial class AddProductMusic : SpecificCulturePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void BtnAddProductClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    int price;
                    if (!int.TryParse(TextPrice.Text, out price)) price = 0;
                    int units;
                    if (!int.TryParse(TextUnits.Text, out units)) units = 0;

                    ProductDetails createdProduct = SessionManager.AddProductMusic(TextProductName.Text, price, DateTime.Now, units, "Libros", TextArtist.Text, TextGenre.Text, TextType.Text);
                    Response.Redirect("~/Pages/MainPage.aspx");
                }
                catch (DuplicateInstanceException)
                {
                    
                }
            }
        }

    }
}