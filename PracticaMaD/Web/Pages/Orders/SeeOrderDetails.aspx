<%@ Page Title="" Language="C#" MasterPageFile="~/PracticaMad.Master" AutoEventWireup="true" CodeBehind="SeeOrderDetails.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMad.Web.Pages.Orders.SeeOrderDetails" meta:resourcekey="PageResource1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_MenuExplanation" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_MenuLinks" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <form runat="server">
        <span>
            <asp:Label ID="lclOrderLines" Font-Bold="true" Font-Size="Medium" runat="server" meta:resourcekey="lclOrderLines" />
        </span>
        </div>
        <br />

        <asp:GridView ID="gvOrderDetails" runat="server" CssClass="order"
            AutoGenerateColumns="False"
            ShowHeaderWhenEmpty="True">
            <Columns>
                <asp:BoundField DataField="productId" HeaderText="<%$ Resources:, productId %>" />
                <asp:BoundField DataField="pName" HeaderText="<%$ Resources:, pName %>" />
                <asp:BoundField DataField="quantity" HeaderText="<%$ Resources:, quantity %>" />
                <asp:BoundField DataField="price" HeaderText="<%$ Resources:, price %>" />
                <asp:BoundField DataField="totalPrice" HeaderText="<%$ Resources:, totalPrice %>" />
                <asp:BoundField DataField="forGift" HeaderText="<%$ Resources:, forGift %>" />
            </Columns>
        </asp:GridView>


        <br />
        <br />

         <div class="button">
                <span>
                    <asp:Label ID="lclPrize" Font-Bold="true" runat="server" meta:resourcekey="lclPrize" /></span>
                <asp:TextBox ID="txtPrizeTotal" ReadOnly="True" runat="server" meta:resourcekey="txtPrizeTotalResource2"></asp:TextBox>
            </div>
    </form>
</asp:Content>