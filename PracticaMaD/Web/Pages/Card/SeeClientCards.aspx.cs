using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.PracticaMad.Web.HTTP.Session;
using System;
using System.Data;
using System.Reflection;
using System.Web;
using System.Web.UI.WebControls;

namespace Es.Udc.DotNet.PracticaMaD.Web.Pages.Card
{
    public partial class SeeClientCards : SpecificCulturePage
    {
        ObjectDataSource pbpDataSource = new ObjectDataSource();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadGrid();
            }
        }

        private void LoadGrid()
        {
            try
            {
                pbpDataSource.ObjectCreating += PbpDataSource_ObjectCreating;

                pbpDataSource.TypeName = "Es.Udc.DotNet.PracticaMad.Model.Services.CreditCardService.IcreditCardService";

                pbpDataSource.EnablePaging = true;

                pbpDataSource.SelectMethod = "";

                string clientId = SessionManager.GetClientSession(Context).ClientId.ToString();

                pbpDataSource.SelectParameters.Add("clientId", DbType.Int32, clientId);

                pbpDataSource.SelectCountMethod = "";

                pbpDataSource.StartRowIndexParameterName = "startIndex";
                pbpDataSource.MaximumRowsParameterName = "count";


          

                gvCardList.AllowPaging = true;
                gvCardList.PageSize = 5;
                gvCardList.DataSource = pbpDataSource;
                gvCardList.Columns[3].Visible = true;
                gvCardList.Columns[4].Visible = true;
                gvCardList.DataBind();
                gvCardList.Columns[3].Visible = false;
                gvCardList.Columns[4].Visible = false;

            }
            catch (TargetInvocationException)
            {

            }
        }

        protected void changeDefaultCard_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void gvCardList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void PbpDataSource_ObjectCreating(object sender, ObjectDataSourceEventArgs e)
        {


        }

        protected void changeDefaultCard_DataBinding(object sender, EventArgs e)
        {

        }

        protected void gvCardList_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }
    }
}