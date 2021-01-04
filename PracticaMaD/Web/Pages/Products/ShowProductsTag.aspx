<%@ Page Title="" Language="C#" MasterPageFile="~/PracticaMad.Master" AutoEventWireup="true" CodeBehind="ShowProductsTag.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMad.Web.Pages.Products.ShowProductsTag" %>

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
        <asp:GridView ID="gvProduct" runat="server" CssClass="products"
            AutoGenerateColumns="False"
            OnPageIndexChanging="Gv^ProductPageIndexChanging"
            ShowHeaderWhenEmpty="True">
            <Columns>
                <asp:BoundField DataField="ProductName" HeaderText="<%$ Resources:, productName %>" />
            </Columns>
        </asp:GridView>
    </form>

    <br />
    <br />
</asp:Content>