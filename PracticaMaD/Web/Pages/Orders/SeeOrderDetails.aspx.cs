using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.PracticaMad.Model;
using Es.Udc.DotNet.PracticaMad.Model.Service.ClientOrderLineService;
using Es.Udc.DotNet.PracticaMad.Web.HTTP.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Es.Udc.DotNet.PracticaMad.Web.Pages.Orders
{
    public partial class SeeOrderDetails : SpecificCulturePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadGrid();
            }
        }

        private void LoadGrid()
        {
            long orderId = (long)Convert.ToInt32(Request.Params.Get("orderId"));

            IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];

            IClientOrderLineService clientOrderLineservice = (IClientOrderLineService)iocManager.Resolve<IClientOrderLineService>();

            List<ClientOrderLine> l = clientOrderLineservice.GetOrderLines(orderId);

            double price = 0;

            for (int i = 0; i < l.Count; i++)
            {
                price += l.ElementAt(i).totalPrice;
            }

            txtPrizeTotal.Text = ((price)).ToString();

            gvOrderDetails.DataSource = l;
            gvOrderDetails.DataBind();
        }
    }
}