using Es.Udc.DotNet.PracticaMad.Model;
using Es.Udc.DotNet.PracticaMad.Web.HTTP.Session;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Es.Udc.DotNet.PracticaMad.Web
{
    public partial class PracticaMad : System.Web.UI.MasterPage
    {
        public static readonly String CLIENT_SESSION_ATTRIBUTE = "clientSession";

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    List<Tag> tags = SessionManager.GetTags();
            //    gvTags.DataSource = tags;
            //    gvTags.DataBind();
            //}
            if (!SessionManager.IsClientAuthenticated(Context))
            {
                if (lblDash2 != null)
                    lblDash2.Visible = false;
                if (lnkUpdate != null)
                    lnkUpdate.Visible = false;
                if (lblDash3 != null)
                    lblDash3.Visible = false;
                if (lnkLogout != null)
                    lnkLogout.Visible = false;
                if (lnkOwnOrders != null)
                    lnkOwnOrders.Visible = false;
                if (lnkAddCard != null)
                    lnkAddCard.Visible = false;
                if (lnkSeeMyCards != null)
                    lnkSeeMyCards.Visible = false;
                if (lnkShoppingCart != null)
                    lnkShoppingCart.Visible = false;
            }
            else
            {
                if (lblWelcome != null)
                    lblWelcome.Text =
                        GetLocalResourceObject("lblWelcome.Hello.Text").ToString()
                        + " " + SessionManager.GetClientSession(Context).FirstName;
                if (lblDash1 != null)
                    lblDash1.Visible = false;
                if (lnkAuthenticate != null)
                    lnkAuthenticate.Visible = false;
            }
        }
    }
}