using Es.Udc.DotNet.PracticaMad.Model.Services.ProductService;
using Es.Udc.DotNet.PracticaMad.Web.HTTP.Session;
using System;
using System.Web.UI;

namespace Es.Udc.DotNet.PracticaMad.Web.Pages.Products
{
    public partial class UpdateFilms : SpecificCulturePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    long prodId = Int32.Parse(Request.Params.Get("prodId"));
                    ProductDetails productDetails =
                    SessionManager.FindProductDetails(prodId);

                    FilmsDetails f = productDetails as FilmsDetails;

                   
                    txtProductName.Text = f.ProductName;
                    txtStock.Text = f.Stock.ToString();
                    txtPrice.Text = f.Price.ToString();

                    txtDirector.Text = f.Director;
                    txtFilmYear.Text = f.FilmYear.ToString();
                    txtDuration.Text = f.Duration.ToString();
                    txtGenere.Text = f.Genere;


                }
                catch (ArgumentNullException)
                {
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the btnUpdate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance
        /// containing the event data.</param>
        protected void BtnUpdateClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                long prodId = Int32.Parse(Request.Params.Get("prodId"));
                ProductDetails productDetails2 =
                    SessionManager.FindProductDetails(prodId);


                FilmsDetails productDetails = new FilmsDetails(prodId, txtProductName.Text, Convert.ToDouble(txtPrice.Text), System.DateTime.Now, Convert.ToInt32(txtStock.Text), productDetails2.CategoryName,
                   txtDirector.Text, Convert.ToInt32(txtFilmYear.Text), Convert.ToInt32(txtDuration.Text), txtGenere.Text);




                SessionManager.UpdateFilmsDetails(prodId, productDetails);

                Response.Redirect(
                    Response.ApplyAppPathModifier("~/Pages/Products/ProductFilmsDetails.aspx?prod=updated&prodId=" + prodId));
            }
        }
    }
}