<%@ Page Title="" Language="C#" MasterPageFile="~/PracticaMad.Master" AutoEventWireup="true" CodeBehind="SeeClientCards.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMad.Web.Pages.Card.SeeClientCards" meta:resourcekey="PageResource1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_MenuExplanation" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <br />
    <form runat="server">

         <p>
            <asp:Label ID="lblNoCards" meta:resourcekey="lblNoCards" runat="server"></asp:Label>
        </p>

        <asp:GridView ID="gvCardList" runat="server" GridLines="None"
            AutoGenerateColumns="False"
            OnSelectedIndexChanging="gvAllCards_SelectedIndexChanging"
            ShowHeaderWhenEmpty="True">
            <Columns>
                <asp:BoundField DataField="cardnumber" HeaderText="<%$ Resources:, cardnumber %>" />
                 <asp:BoundField DataField="cardType" HeaderText="<%$ Resources:, cardType %>" />
                <asp:BoundField DataField="verificationCode" HeaderText="<%$ Resources:, verificationCode %>" />
                <asp:BoundField DataField="expeditionDate" HeaderText="<%$ Resources:, expeditionDate %>" />
               <asp:BoundField DataField="DefaultCard" Visible="true"/>
                <asp:TemplateField HeaderText="<%$ Resources:, DefaultCard %>" >
                    <ItemTemplate>
                        <asp:checkbox ID="changeDefaultCard" AutoPostBack="true" OnDataBinding="changeDefaultCard_DataBinding" runat="server" OnCheckedChanged="changeDefaultCard_CheckedChanged" />
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:CommandField ShowSelectButton="true" SelectText="deleteCard" />
            </Columns>
        </asp:GridView>
    </form>
</asp:Content>



