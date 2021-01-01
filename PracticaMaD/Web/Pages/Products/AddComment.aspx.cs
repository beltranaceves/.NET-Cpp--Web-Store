using Es.Udc.DotNet.PracticaMad.Model;
using Es.Udc.DotNet.PracticaMad.Web.HTTP.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Es.Udc.DotNet.PracticaMad.Web.Pages.Products
{
    public partial class AddComment : SpecificCulturePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void BtnAddCommentClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                ProductComment createdComment = SessionManager.AddProductComment(Context,
                    txtComment.Text);
                Context.Items.Add("commentCreated", createdComment);
                Server.Transfer(
                    Response.ApplyAppPathModifier("./CommentAdded.aspx"));
            }
        }
    }
}