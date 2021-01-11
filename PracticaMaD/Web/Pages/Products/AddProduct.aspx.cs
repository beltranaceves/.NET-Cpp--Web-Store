using System;
using System.Collections.Generic;
using System.Web.UI;
using Es.Udc.DotNet.PracticaMad.Web.HTTP.Session;

namespace Es.Udc.DotNet.PracticaMad.Web.Pages.Products
{
    public partial class AddProduct : SpecificCulturePage

    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UpdateComboCategory();
            }
        }

        /// <summary>
        /// Loads the categories in the comboBox in the *selectedCategory*.
        /// Also, the selectedCategory will appear selected in the
        /// ComboBox
        /// </summary>
        private void UpdateComboCategory()
        {
            List<string> cats = SessionManager.GetCategories();
            cats.RemoveAt(0);
            cats.RemoveAt(cats.Count-1);
            cats.RemoveAt(cats.Count-1);
            cats.Add("-");
            this.comboCategory1.DataSource = cats;
            this.comboCategory1.DataBind();
            this.comboCategory1.SelectedValue = "-";
        }

        protected void BtnFindClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                /* Get data. */
                string cat = this.comboCategory1.SelectedValue;
                /* Do action. */
                String url;
                if (cat != "-") {
                    Response.Redirect("AddProductMusic.aspx");
                }

                Response.Redirect("FeatureNotImplemented.aspx");
            }
        }
    }
}