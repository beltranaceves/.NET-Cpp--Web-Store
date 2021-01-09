<%@ Page Title="" Language="C#" MasterPageFile="~/PracticaMad.Master" AutoEventWireup="true" CodeBehind="ShowProducts.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMad.Web.Pages.Products.ShowProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_MenuExplanation" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <br />
  

    <form runat="server">

          <p>
        <asp:Label ID="lblNoProduct" meta:resourcekey="lblNoProduct" runat="server" Visible="false"></asp:Label>
            </p>

        <asp:GridView ID="gvProduct" runat="server" CssClass="products" GridLines="None"
            AutoGenerateColumns="False"
            OnRowCommand="ContactsGridView_RowCommand">
            <Columns>
                <asp:BoundField DataField="ProductId" ItemStyle-CssClass="Hide" />
                <asp:BoundField DataField="ProductName" HeaderText="<%$ Resources:Common, productName %>" />
                <asp:BoundField DataField="RegisterDate" HeaderText="<%$ Resources:Common, productDate %>" />
                <asp:BoundField DataField="Price" HeaderText="<%$ Resources:Common, prize %>" />
                <asp:ButtonField CommandName="Show" runat="server"  meta:resourcekey="btnShowProduct" />
                <asp:ButtonField CommandName="Add" runat="server" meta:resourcekey="btnAddToCart" />
            </Columns>
        </asp:GridView>
        <br />
    </form>

     <asp:Label ID="lclNoStock" runat="server" ForeColor="Red" Style="position: relative"
                        Visible="False" meta:resourcekey="lclNoStock"></asp:Label>

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