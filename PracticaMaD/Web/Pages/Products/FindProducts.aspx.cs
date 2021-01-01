using System;
using System.Web.UI;
using Es.Udc.DotNet.PracticaMad.Model.Services.Exceptions;
using Es.Udc.DotNet.PracticaMad.Web.HTTP.Session;
using Es.Udc.DotNet.ModelUtil.Exceptions;
using System.Web.Security;
using System.Web.UI.WebControls;
using Es.Udc.DotNet.PracticaMad.Web.Properties;
using System.Data;
using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.PracticaMad.Model.Services.ProductService;
using System.Web;
using System.Reflection;

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