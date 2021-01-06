<%@ Page Title="" Language="C#" MasterPageFile="~/PracticaMad.Master" AutoEventWireup="true" CodeBehind="OwnOrders.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMad.Web.Pages.Orders.OwnOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_MenuExplanation" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_MenuLinks" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <div>
        <p>
            <asp:Label ID="lblNoOrders" meta:resourcekey="lblNoOrders" runat="server" Visible="false"></asp:Label>
        </p>
        <form runat="server">
            <asp:GridView ID="gvOwnOrders" runat="server" CssClass="order"
                AutoGenerateColumns="False"
                ShowHeaderWhenEmpty="True">
                <Columns>
                    <asp:HyperLinkField 
                    DataNavigateUrlFields="OrderId"
                    DataTextField="OrderId"
                    DataNavigateUrlFormatString="./SeeOrderDetails.aspx?orderId={0}"
                    HeaderText="<%$ Resources:, orderId %>"
                    />
                    <asp:BoundField DataField="OrderName" HeaderText="<%$ Resources:, orderName %>" />
                    <asp:BoundField DataField="OrderDate" HeaderText="<%$ Resources:, orderdate %>" />
                    <asp:BoundField DataField="TotalPrize" HeaderText="<%$ Resources:, totalPrice %>" />
                </Columns>
            </asp:GridView>
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
    </div>
</asp:Content>