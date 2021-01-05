using Es.Udc.DotNet.PracticaMad.Model.Services.ProductCommentService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Es.Udc.DotNet.PracticaMad.Web.Pages.Products
{
    public partial class EditedComment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductCommentDetails commentAdded = (ProductCommentDetails)Context.Items["commentEdited"];
            lblCommentEditedId.Text = commentAdded.CommentId.ToString();
        }
    }
}