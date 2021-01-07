using Es.Udc.DotNet.PracticaMad.Model.Services.ProductService;
using Es.Udc.DotNet.PracticaMad.Web.HTTP.Session;
using System;
using System.Web.UI;

namespace Es.Udc.DotNet.PracticaMad.Web.Pages.Products
{
    public partial class UpdateBooks : SpecificCulturePage
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

                    BooksDetails bk = productDetails as BooksDetails;

                   
                    txtProductName.Text = bk.ProductName;
                    txtStock.Text = bk.Stock.ToString();
                    txtPrice.Text = bk.Price.ToString();
                    txtAuthor.Text = bk.Author;
                    txtPages.Text = bk.Pages.ToString();
                    txtISBN.Text = bk.ISBN.ToString();
                    txtEditorial.Text = bk.Editorial;
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


                BooksDetails productDetails = new BooksDetails(prodId, txtProductName.Text, Convert.ToDouble(txtPrice.Text), System.DateTime.Now, Convert.ToInt32(txtStock.Text), productDetails2.CategoryName,
                   txtAuthor.Text, Convert.ToInt32(txtPages.Text), Convert.ToInt32(txtISBN.Text), txtEditorial.Text);




                SessionManager.UpdateBooksDetails(prodId, productDetails);

                Response.Redirect(
                    Response.ApplyAppPathModifier("~/Pages/Products/ProductBooksDetails.aspx?prod=updated&prodId=" + prodId));
            }
        }
    }
}