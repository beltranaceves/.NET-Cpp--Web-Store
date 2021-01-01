using System;
using System.Web.UI;
using Es.Udc.DotNet.PracticaMad.Web.HTTP.Session;

namespace Es.Udc.DotNet.PracticaMad.Web.Pages.Products
{
    public partial class FindProducts : SpecificCulturePage

    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void BtnFindClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                /* Get data. */
                string keyword = this.txtKeyword.Text;

                /* Do action. */
                String url =
                    String.Format("./ShowProducts.aspx?keword={0}", keyword);

                Response.Redirect(Response.ApplyAppPathModifier(url));
            }
        }
    }
}