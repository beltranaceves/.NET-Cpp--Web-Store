<%@ Page Title="" Language="C#" MasterPageFile="~/PracticaMad.Master" AutoEventWireup="true" CodeBehind="OwnOrders.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMad.Web.Pages.Orders.OwnOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_MenuExplanation" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_MenuLinks" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <div>
        <p>
            <asp:Label ID="lblInvalidClient" meta:resourcekey="lblInvalidClient" runat="server" Visible="false"></asp:Label>
        </p>
        <form runat="server">
            <asp:GridView ID="gvOwnOrders" runat="server" CssClass="ownOrders"
                AutoGenerateColumns="False"
                OnPageIndexChanging="GvOwnOrdersPageIndexChanging"
                ShowHeaderWhenEmpty="True">
                <Columns>
                    <asp:BoundField DataField="OrderName" HeaderText="<%$ Resources:, orderName %>" />
                </Columns>
            </asp:GridView>
        </form>
    </div>
</asp:Content>