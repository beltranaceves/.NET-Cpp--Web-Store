using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.PracticaMad.Model.Services.ProductService;
using Es.Udc.DotNet.PracticaMad.Web.HTTP.Session;
using Es.Udc.DotNet.PracticaMad.Web.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Es.Udc.DotNet.PracticaMad.Web.Pages.Products
{
    public partial class ShowProducts : SpecificCulturePage
    {
        private ObjectDataSource pbpDataSource = new ObjectDataSource();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // ObjectCreating is executed before ObjectDataSource creates
                // an instance of the type used as DataSource (ProductService).
                // We need to intercept this call to replace the standard creation
                // procedure (a new ProductService() sentence) to use the Unity
                // Container that allows to complete the dependences (productDao,...)
                pbpDataSource.ObjectCreating += this.PbpDataSource_ObjectCreating;

                pbpDataSource.TypeName = "Es.Udc.DotNet.PracticaMad.Model.Services.ProductService.IProductService";

                pbpDataSource.EnablePaging = true;

                pbpDataSource.SelectMethod = "FindProductByProductNameKeyword";

                /* Get Keyword */
                String keyword = Convert.ToString(Request.Params.Get("keyword"));

                pbpDataSource.SelectParameters.Add("keyword", DbType.Int64, keyword);

                pbpDataSource.SelectCountMethod =
                    "CountProductByProductNameKeyword";
                pbpDataSource.StartRowIndexParameterName =
                    "startIndex";
                pbpDataSource.MaximumRowsParameterName =
                    "count";

                gvProduct.AllowPaging = true;
                gvProduct.PageSize = 5;

                gvProduct.DataSource = pbpDataSource;
                gvProduct.DataBind();
            }
            catch (TargetInvocationException)
            {
                lblInvalidProduct.Visible = true;
            }
        }

        protected void GvProductPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProduct.PageIndex = e.NewPageIndex;

            gvProduct.DataBind();
        }

        protected void PbpDataSource_ObjectCreating(object sender, ObjectDataSourceEventArgs e)
        {
            /* Get the Service */
            IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];
            IProductService productService = iocManager.Resolve<IProductService>();

            e.ObjectInstance = productService;
        }
    }
}