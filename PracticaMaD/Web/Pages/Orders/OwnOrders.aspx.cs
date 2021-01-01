using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.PracticaMad.Web.HTTP.Session;
using System;
using System.Data;
using System.Reflection;
using System.Web;
using System.Web.UI.WebControls;
using Es.Udc.DotNet.PracticaMad.Model.Services.ClientOrderService;
using Es.Udc.DotNet.PracticaMad.Web.Properties;

namespace Es.Udc.DotNet.PracticaMad.Web.Pages.Orders
{
    public partial class OwnOrders : SpecificCulturePage
    {
        private ObjectDataSource pbpDataSource = new ObjectDataSource();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // ObjectCreating is executed before ObjectDataSource creates
                // an instance of the type used as DataSource (AccountService).
                // We need to intercept this call to replace the standard creation
                // procedure (a new AccountService() sentence) to use the Unity
                // Container that allows to complete the dependences (accountDao,...)

                pbpDataSource.ObjectCreating += this.PbpDataSource_ObjectCreating;

                pbpDataSource.TypeName =
                     Settings.Default.ObjectDS_OwnOrders_Service;

                pbpDataSource.EnablePaging = true;

                pbpDataSource.SelectMethod =
                    Settings.Default.ObjectDS_OwnOrders_SelectMethod;

                /* Get Client Identifier */
                long clientId = Convert.ToInt32(Request.Params.Get("clientId"));

                pbpDataSource.SelectParameters.Add("clientId", DbType.Int64, clientId.ToString());

                pbpDataSource.SelectCountMethod =
                    Settings.Default.ObjectDS_OwnOrders_CountMethod;
                pbpDataSource.StartRowIndexParameterName =
                    Settings.Default.ObjectDS_OwnOrders_StartIndexParameter;
                pbpDataSource.MaximumRowsParameterName =
                    Settings.Default.ObjectDS_OwnOrders_CountParameter;

                gvOwnOrders.AllowPaging = true;
                gvOwnOrders.PageSize = Settings.Default.PracticaMad_defaultCount;

                gvOwnOrders.DataSource = pbpDataSource;
                gvOwnOrders.DataBind();
            }
            catch (TargetInvocationException)
            {
                lblInvalidClient.Visible = true;
            }
        }

        protected void GvOwnOrdersPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvOwnOrders.PageIndex = e.NewPageIndex;
            gvOwnOrders.DataBind();
        }

        protected void PbpDataSource_ObjectCreating(object sender, ObjectDataSourceEventArgs e)
        {
            /* Get the Service */
            IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];
            IClientOrderService clientOrderService = iocManager.Resolve<IClientOrderService>();

            e.ObjectInstance = clientOrderService;
        }
    }
}