<%@ Page Title="" Language="C#" MasterPageFile="~/PracticaMad.Master" AutoEventWireup="true" CodeBehind="ShowOneProduct.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMad.Web.Pages.Products.ShowOneProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_MenuWelcome" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_MenuExplanation" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_MenuLinks" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <asp:Table CssClass="productDetails" ID="TableProductInfo" runat="server">
        <asp:TableRow runat="server">
            <asp:TableHeaderCell ID="cellCaptionProductName" runat="server" Text="<%$ Resources:Common, productName %>"></asp:TableHeaderCell>
            <asp:TableCell ID="cellProductName" runat="server"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableHeaderCell ID="cellCaptionProductPrize" runat="server" Text="<%$ Resources:Common, prize %>"></asp:TableHeaderCell>
            <asp:TableCell ID="cellProductPrize" runat="server"></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <form id="AddCommentForm" method="post" runat="server">
        <div class="button">
            <asp:Button ID="btnAddComment" runat="server" meta:resourcekey="btnAddComment" OnClick="BtnAddCommentClick" />
        </div>
    </form>
</asp:Content>