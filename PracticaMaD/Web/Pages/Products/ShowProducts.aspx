<%@ Page Title="" Language="C#" MasterPageFile="~/PracticaMad.Master" AutoEventWireup="true" CodeBehind="ShowProducts.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMad.Web.Pages.Products.ShowProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_MenuExplanation" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_MenuLinks" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <br />
    <p>
        <asp:Label ID="lblNoProduct" meta:resourcekey="lblNoProduct" runat="server" Visible="false"></asp:Label>
    </p>

    <form runat="server">

        <asp:GridView ID="gvProduct" runat="server" CssClass="products" GridLines="None"
            AutoGenerateColumns="False"
            OnRowCommand="ContactsGridView_RowCommand"
            OnSelectedIndexChanging="gvProduct_SelectedIndexChanging">
            <Columns>
                <asp:BoundField DataField="ProductId" ItemStyle-CssClass="Hide" />
                <asp:BoundField DataField="ProductName" HeaderText="<%$ Resources:Common, productName %>" />
                <asp:BoundField DataField="RegisterDate" HeaderText="<%$ Resources:Common, productDate %>" />
                <asp:BoundField DataField="Price" HeaderText="<%$ Resources:Common, prize %>" />
                <asp:BoundField DataField="Price" HeaderText="<%$ Resources:Common, prize %>" />
                <asp:ButtonField CommandName="Show" runat="server" meta:resourcekey="btnShowProduct" />
                <asp:CommandField ShowSelectButton="True" SelectText="Buy Product" meta:resourcekey="CommandFieldResource3" />
            </Columns>
        </asp:GridView>
        <br />
    </form>

    <!-- "Previous" and "Next" links. -->
    <div class="previousNextLinks">
        <span class="previousLink">
            <asp:HyperLink ID="lnkPrevious" Text="<%$ Resources:Common, Previous %>" runat="server"
                Visible="False"></asp:HyperLink>
        </span><span class="nextLink">
            <asp:HyperLink ID="lnkNext" Text="<%$ Resources:Common, Next %>" runat="server" Visible="False"></asp:HyperLink>
        </span>
    </div>

    <br />
    <br />
</asp:Content>