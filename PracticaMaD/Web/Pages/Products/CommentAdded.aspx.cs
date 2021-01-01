using Es.Udc.DotNet.PracticaMad.Model;
using Es.Udc.DotNet.PracticaMad.Web.HTTP.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Es.Udc.DotNet.PracticaMad.Web.Pages.Products
{
    public partial class CommentAdded : SpecificCulturePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductComment commentAdded = (ProductComment)Context.Items["commentCreated"];
            lblCommentCreatedId.Text = commentAdded.commentId.ToString();
        }
    }
}