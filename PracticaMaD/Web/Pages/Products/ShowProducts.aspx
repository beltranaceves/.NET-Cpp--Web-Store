<%@ Page Title="" Language="C#" MasterPageFile="~/PracticaMad.Master" AutoEventWireup="true" CodeBehind="ShowProducts.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMad.Web.Pages.Products.ShowProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_MenuExplanation" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_MenuLinks" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <br />
    <p>
        <asp:Label ID="lblInvalidProduct" meta:resourcekey="lblInvalidProduct" runat="server" Visible="false"></asp:Label>
    </p>
    <form runat="server">

        <asp:GridView ID="gvProduct" runat="server"
            AutoGenerateColumns="True"
            OnPageIndexChanging="GvProductPageIndexChanging"
            ShowHeaderWhenEmpty="True">
            <Columns>
            </Columns>
        </asp:GridView>
        <br />
        <!-- "Previous" and "Next" links. -->
    </form>
    <br />
    <br />
</asp:Content>