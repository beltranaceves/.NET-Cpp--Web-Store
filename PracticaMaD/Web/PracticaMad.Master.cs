using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.PracticaMad.Model;
using Es.Udc.DotNet.PracticaMad.Model.Services.TagService;
using Es.Udc.DotNet.PracticaMad.Web.HTTP.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
                if (lnkAddProduct != null)
                    lnkAddProduct.Visible = false;
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
            if (!IsPostBack)
            {
                IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];

                ITagService tagService = (ITagService)iocManager.Resolve<ITagService>();
                List<Tag> tags = tagService.GetMoreUsedTags();

                if (tags == null)
                {
                    tagLinks.Visible = false;
                }
                else {  
                    if (tags.Count() == 5)
                    {
                        Tag5.Text = tags.ElementAt(4).tagName;
                        String url =
                                    String.Format("~/Pages/Products/ShowProductsTag.aspx?tag=" + Tag5.Text);
                        Tag5.NavigateUrl = url;
                        int tamaño = tags.ElementAt(4).timesUsed;
                        if (tamaño > 50)
                        {
                            tamaño = 50;
                        }
                        if (tamaño < 10)
                        {
                            tamaño = 10;
                        }
                        Tag5.Attributes.CssStyle.Add("font-size", tamaño.ToString() + "px");
                    }
                    if (tags.Count() >= 4)
                    {
                        Tag4.Text = tags.ElementAt(3).tagName;
                        String url =
                                    String.Format("~/Pages/Products/ShowProductsTag.aspx?tag=" + Tag4.Text);
                        Tag4.NavigateUrl = url;
                        int tamaño = tags.ElementAt(3).timesUsed;
                        if (tamaño > 50)
                        {
                            tamaño = 50;
                        }
                        if (tamaño < 10)
                        {
                            tamaño = 10;
                        }
                        Tag4.Attributes.CssStyle.Add("font-size", tamaño.ToString() + "px");
                    }
                    if (tags.Count() >= 3)
                    {
                        Tag3.Text = tags.ElementAt(2).tagName;
                        String url =
                                    String.Format("~/Pages/Products/ShowProductsTag.aspx?tag=" + Tag3.Text);
                        Tag3.NavigateUrl = url;
                        int tamaño = tags.ElementAt(2).timesUsed;
                        if (tamaño > 50)
                        {
                            tamaño = 50;
                        }
                        if (tamaño < 10)
                        {
                            tamaño = 10;
                        }
                        Tag3.Attributes.CssStyle.Add("font-size", tamaño.ToString() + "px");
                    }
                    if (tags.Count() >= 2)
                    {
                        Tag2.Text = tags.ElementAt(1).tagName;
                        String url =
                                    String.Format("~/Pages/Products/ShowProductsTag.aspx?tag=" + Tag2.Text);
                        Tag2.NavigateUrl = url;
                        int tamaño = tags.ElementAt(1).timesUsed;
                        if (tamaño > 50)
                        {
                            tamaño = 50;
                        }
                        if (tamaño < 10)
                        {
                            tamaño = 10;
                        }
                        Tag2.Attributes.CssStyle.Add("font-size", tamaño.ToString() + "px");
                    }
                    if (tags.Count() >= 1)
                    {
                        Tag1.Text = tags.ElementAt(0).tagName;
                        String url =
                                    String.Format("~/Pages/Products/ShowProductsTag.aspx?tag=" + Tag1.Text);
                        Tag1.NavigateUrl = url;
                        int tamaño = tags.ElementAt(0).timesUsed;
                        if (tamaño > 50)
                        {
                            tamaño = 50;
                        }
                        if (tamaño < 10)
                        {
                            tamaño = 10;
                        }
                        Tag1.Attributes.CssStyle.Add("font-size", tamaño.ToString() + "px");
                    }
                }
            }
        }
    }
}