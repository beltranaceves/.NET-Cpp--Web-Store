<%@ Page Title="" Language="C#" MasterPageFile="~/PracticaMad.Master" AutoEventWireup="true" CodeBehind="AddComment.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMad.Web.Pages.Products.AddComment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_MenuWelcome" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_MenuExplanation" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_MenuLinks" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">

    <div id="form">
        <form id="AddCommentForm" method="POST" runat="server">
            <asp:HyperLink ID="lnkChangePassword" runat="server"
                NavigateUrl="~/Pages/Products/ShowOneProduct.aspx"
                meta:resourcekey="lnkChangePassword" />
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclComment" runat="server" meta:resourcekey="lclComment" /></span><span class="entry">
                        <asp:TextBox ID="txtComment" runat="server" Width="100" Columns="16"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvComment" runat="server"
                            ControlToValidate="txtComment" Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>" /></span>
            </div>

            <div class="button">
                <asp:Button ID="btnAddComment" runat="server" OnClick="BtnAddCommentClick" meta:resourcekey="BtnAddComment" />
            </div>
        </form>
    </div>
</asp:Content>