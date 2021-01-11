using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.ModelUtil.IoC;
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
            lblTagError.Visible = false;

            if (!IsPostBack)
            {
                try
                {
                    long prodId = Int32.Parse(Request.Params.Get("prodId"));
                    List<Tag> tags = SessionManager.GetTags();
                    gvTagList.DataSource = tags;
                    gvTagList.DataBind();
                }
                catch (ArgumentNullException)
                {
                }
            }
        }

        protected void BtnAddCommentClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                long prodId = Int32.Parse(Request.Params.Get("prodId"));
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

                ProductComment createdComment = SessionManager.AddProductComment(Context, prodId,
                        txtComment.Text, tags);
                SessionManager.TagProductComment(createdComment.commentId, tags);
                Context.Items.Add("commentCreated", createdComment);
                Server.Transfer(
                    Response.ApplyAppPathModifier("./CommentAdded.aspx"));
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
                    List<Tag> tags = SessionManager.GetTags();
                    gvTagList.DataSource = tags;
                    gvTagList.DataBind();
                }
                catch (DuplicateInstanceException)
                {
                    lblTagError.Visible = true;
                }
            }
        }
        
    }
}