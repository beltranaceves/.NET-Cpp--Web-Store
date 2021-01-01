using Es.Udc.DotNet.PracticaMad.Web.HTTP.Session;
using System;

namespace Es.Udc.DotNet.PracticaMad.Web.Pages.User
{
    public partial class Logout : SpecificCulturePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionManager.Logout(Context);

            Response.Redirect("~/Pages/MainPage.aspx");
        }
    }
}