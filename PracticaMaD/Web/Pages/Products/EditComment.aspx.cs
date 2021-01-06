using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.PracticaMad.Model;
using Es.Udc.DotNet.PracticaMad.Model.Services.ProductCommentService;
using Es.Udc.DotNet.PracticaMad.Web.HTTP.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Es.Udc.DotNet.PracticaMad.Web.Pages.Products
{
    public partial class EditComment : SpecificCulturePage
    {
        private ProductCommentDetails prodDetails;

        protected void Page_Load(object sender, EventArgs e)

        {
            if (!IsPostBack)
            {
                long prodId = Int32.Parse(Request.Params.Get("prodId"));

                prodDetails =
                    SessionManager.FindProductComment(Context, prodId);

                List<Tag> tags = SessionManager.GetTags();
                txtComment.Text = prodDetails.CommentText;
                gvTagList.DataSource = tags;
                gvTagList.DataBind();
            }
        }

        protected void BtnDeleteClick(object sender, EventArgs e)
        {
            long prodId = Int32.Parse(Request.Params.Get("prodId"));

            ProductCommentDetails prodDetails =
                SessionManager.FindProductComment(Context, prodId);

            IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];

            IProductCommentService productCommentService = (IProductCommentService)iocManager.Resolve<IProductCommentService>();

            //productCommentService.RemoveComment(prodDetails.CommentId);
        }

        protected void BtnUpdateClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                List<Tag> tags = new List<Tag>();
                var rows = gvTagList.Rows;
                int count = gvTagList.Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    bool isChecked = ((CheckBox)rows[i].FindControl("addTag")).Checked;
                    if (isChecked)
                    {
                        Tag tag = SessionManager.FindTagByName(rows[i].Cells[0].Text);
                        tags.Add(tag);
                    }
                }
                long prodId = Int32.Parse(Request.Params.Get("prodId"));

                prodDetails =
                    SessionManager.FindProductComment(Context, prodId);
                ProductCommentDetails prodDetails2 = new ProductCommentDetails(prodDetails.CommentId, prodDetails.ProductId,
                                                                    txtComment.Text, System.DateTime.Now, prodDetails.ClientId, tags);

                ProductCommentDetails editedComment = SessionManager.EditProductComment(prodDetails2);

                Context.Items.Add("commentEdited", editedComment);
                Server.Transfer(
                    Response.ApplyAppPathModifier("./EditedComment.aspx"));
            }
        }

        protected void BtnAddTag(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    Tag tag;
                    tag = SessionManager.CreateTag(txtTag.Text);
                    txtTag.Text = String.Empty;
                }
                catch (DuplicateInstanceException)
                {
                    lblTagError.Visible = true;
                }
            }
        }
    }
}