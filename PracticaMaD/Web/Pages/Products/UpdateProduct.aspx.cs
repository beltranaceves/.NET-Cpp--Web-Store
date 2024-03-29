﻿using Es.Udc.DotNet.PracticaMad.Model.Services.ProductService;
using Es.Udc.DotNet.PracticaMad.Web.HTTP.Session;
using System;
using System.Web.UI;

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
                ProductDetails productDetails =
                    new ProductDetails(prodId, txtProductName.Text, Convert.ToDouble(txtPrice.Text), System.DateTime.Now, Convert.ToInt32(txtStock.Text), productDetails2.CategoryName);

                SessionManager.UpdateProductDetails(prodId, productDetails);

                Response.Redirect(
                    Response.ApplyAppPathModifier("~/Pages/Products/ShowOneProduct.aspx?prod=updated&prodId=" + prodId));
            }
        }
    }
}