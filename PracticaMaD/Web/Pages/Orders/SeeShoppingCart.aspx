<%@ Page Title="" Language="C#" MasterPageFile="~/PracticaMad.Master" AutoEventWireup="true" CodeBehind="SeeShoppingCart.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMad.Web.Pages.Orders.SeeShoppingCart" meta:resourcekey="PageResource1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_MenuExplanation" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_MenuLinks" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <form runat="server">
        <span>
            <asp:Label ID="lclProductList" Font-Bold="true" Font-Size="Medium" runat="server" meta:resourcekey="lclProductListResource1" />
        </span>
        </div>
        <br />

         <p>
            <asp:Label ID="lblShoppingCartEmpty" meta:resourcekey="lblShoppingCartEmpty" runat="server"></asp:Label>
        </p>

        <asp:GridView ID="gvShoppingCart" runat="server" CssClass="shoppingCart"
            AutoGenerateColumns="False"
            OnRowCreated="gvShoppingCart_RowCreated"
            OnSelectedIndexChanging="gvShoppingCart_SelectedIndexChanging"
            OnRowDataBound="gvShoppingCart_RowDataBound"
            ShowHeaderWhenEmpty="True" meta:resourcekey="gvShoppingCartResource2">
            <Columns>
                <asp:BoundField DataField="productId" HeaderText="<%$ Resources:, productId %>"/>
                <asp:BoundField DataField="productName" HeaderText="<%$ Resources:, productName %>" />
                <asp:BoundField DataField="price" HeaderText="<%$ Resources:, price %>" />
                <asp:BoundField DataField="quantity" HeaderText="<%$ Resources:, quantity %>" />
                <asp:BoundField DataField="totalPrice" HeaderText="<%$ Resources:, totalPrice %>" />

                <asp:TemplateField HeaderText="<%$ Resources:, forGift %>">
                    <ItemTemplate>
                        <asp:CheckBox ID="cbForGift" AutoPostBack="true" runat="server" OnDataBinding="cbForGift_DataBinding" OnCheckedChanged="cbForGift_CheckedChanged" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:, quantity %>" meta:resourcekey="TemplateFieldResource2">
                    <ItemTemplate>
                        <asp:DropDownList ID="quantityList" AutoPostBack="True" runat="server" OnSelectedIndexChanged="quantityList_SelectedIndexChanged" meta:resourcekey="quantityListResource2">
                            <asp:ListItem Value="1" meta:resourcekey="ListItemResource8">1</asp:ListItem>
                            <asp:ListItem Value="2" meta:resourcekey="ListItemResource9">2</asp:ListItem>
                            <asp:ListItem Value="3" meta:resourcekey="ListItemResource10">3</asp:ListItem>
                            <asp:ListItem Value="4" meta:resourcekey="ListItemResource11">4</asp:ListItem>
                            <asp:ListItem Value="5" meta:resourcekey="ListItemResource12">5</asp:ListItem>
                            <asp:ListItem Value="6" meta:resourcekey="ListItemResource13">6</asp:ListItem>
                            <asp:ListItem Value="7" meta:resourcekey="ListItemResource14">7</asp:ListItem>
                            <asp:ListItem Value="8" meta:resourcekey="ListItemResource15">8</asp:ListItem>
                            <asp:ListItem Value="9" meta:resourcekey="ListItemResource16">9</asp:ListItem>
                            <asp:ListItem Value="10" meta:resourcekey="ListItemResource17">10</asp:ListItem>
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowSelectButton="True" SelectText="deleteProduct"/>
            </Columns>
        </asp:GridView>
        <br />
        <br />

       <div class="button">
                <span>
                    <asp:Label ID="lclPrize" Font-Bold="true" runat="server" meta:resourcekey="lclPrize" /></span>
                <asp:TextBox ID="txtPrizeTotal" ReadOnly="True" runat="server" meta:resourcekey="txtPrizeTotalResource2"></asp:TextBox>
            </div>
        <br />
        <br />

        <div class="button">
            <asp:Button ID="btnPay" runat="server" OnClick="btnToPay_Click" meta:resourcekey="btnPay" />
        </div>
    </form>
</asp:Content>