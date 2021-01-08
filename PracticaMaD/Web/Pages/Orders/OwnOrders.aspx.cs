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
        protected void Page_Load(object sender, EventArgs e)
        {
            int startIndex, count;
            long clientId;
            lnkPrevious.Visible = false;
            lnkNext.Visible = false;
            lblNoOrders.Visible = false;

            /* Get Client Identifier passed as parameter in the request from
             * the previous page
             */
            try
            {
                clientId = Int32.Parse(Request.Params.Get("clientId"));
            }
            catch (ArgumentNullException)
            {
                ClientSession clientSession =
                 SessionManager.GetClientSession(Context);

                clientId = clientSession.ClientId;
            }
            /* Get Start Index */
            try
            {
                startIndex = Int32.Parse(Request.Params.Get("startIndex"));
            }
            catch (ArgumentNullException)
            {
                startIndex = 0;
            }

            /* Get Count */
            try
            {
                count = Int32.Parse(Request.Params.Get("count"));
            }
            catch (ArgumentNullException)
            {
                count = Settings.Default.PracticaMad_defaultCount;
            }

            /* Get the Service */
            IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];
            IClientOrderService clientOrderService = iocManager.Resolve<IClientOrderService>();

            /* Get Orders Info */
            ClientOrderBlock orderBlock =
                clientOrderService.GetClientOrders(clientId, startIndex, count);

            if (orderBlock.ClientOrder.Count == 0)
            {
                lblNoOrders.Visible = true;
                return;
            }

            this.gvOwnOrders.DataSource = orderBlock.ClientOrder;
            this.gvOwnOrders.DataBind();

            /* "Previous" link */
            if ((startIndex - count) >= 0)
            {
                String url =
                    "/Pages/Orders/OwnOrders.aspx" + "?clientId=" + clientId +
                    "&startIndex=" + (startIndex - count) + "&count=" +
                    count;

                this.lnkPrevious.NavigateUrl =
                    Response.ApplyAppPathModifier(url);
                this.lnkPrevious.Visible = true;
            }

            /* "Next" link */
            if (orderBlock.ExistMoreOrders)
            {
                String url =

                   "/Pages/Orders/OwnOrders.aspx" + "?clientId=" + clientId +
                    "&startIndex=" + (startIndex + count) + "&count=" +
                    count;

                this.lnkNext.NavigateUrl =
                    Response.ApplyAppPathModifier(url);
                this.lnkNext.Visible = true;
            }
        }
    }
}