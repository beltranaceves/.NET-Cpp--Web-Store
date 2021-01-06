using System;
using System.Collections.Generic;
using System.Web.UI;
using Es.Udc.DotNet.PracticaMad.Web.HTTP.Session;

namespace Es.Udc.DotNet.PracticaMad.Web.Pages.Products
{
    public partial class FindProducts : SpecificCulturePage

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
            cats.Add("-");
            this.comboCategory.DataSource = cats;
            this.comboCategory.DataBind();
            this.comboCategory.SelectedValue = "-";
        }

        protected void BtnFindClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                /* Get data. */
                string keyword = this.txtKeyword.Text;
                string cat = this.comboCategory.SelectedValue;
                /* Do action. */
                String url =
                    String.Format("./ShowProducts.aspx?keyword={0}&cat={1}", keyword, cat);

                Response.Redirect(Response.ApplyAppPathModifier(url));
            }
        }
    }
}