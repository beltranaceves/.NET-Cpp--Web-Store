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
    public partial class UpdateProduct : SpecificCulturePage
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

                    txtProductName.Text = productDetails.ProductName;
                    txtStock.Text = productDetails.Stock.ToString();
                    txtPrice.Text = productDetails.Price.ToString();

                    /* Combo box initialization */
                    UpdateComboCategory(productDetails.CategoryName);
                }
                catch (ArgumentNullException)
                {
                }
            }
        }

        /// <summary>
        /// Loads the categories in the comboBox in the *selectedCategory*.
        /// Also, the selectedCategory will appear selected in the
        /// ComboBox
        /// </summary>
        private void UpdateComboCategory(String selectedCategory)
        {
            this.comboCategory.DataSource = SessionManager.GetCategories();
            this.comboCategory.DataBind();
            this.comboCategory.SelectedValue = selectedCategory;
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
                ProductDetails productDetails =
                    new ProductDetails(prodId, txtProductName.Text, Convert.ToDouble(txtPrice.Text), System.DateTime.Now, Convert.ToInt32(txtStock.Text), comboCategory.SelectedValue);

                SessionManager.UpdateProductDetails(prodId, productDetails);

                Response.Redirect(
                    Response.ApplyAppPathModifier("~/Pages/Products/ShowOneProduct.aspx?prod=updated&prodId=" + prodId));
            }
        }
    }
}