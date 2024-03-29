﻿<%@ Page Title="" Language="C#" MasterPageFile="~/PracticaMad.Master" AutoEventWireup="true" CodeBehind="SeeClientCards.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMad.Web.Pages.Card.SeeClientCards" meta:resourcekey="PageResource1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_MenuExplanation" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <br />
    <form runat="server">

        <p>
            <asp:Label ID="lblNoCards" meta:resourcekey="lblNoCards" runat="server"></asp:Label>
        </p>

        <asp:GridView ID="gvCardList" runat="server" GridLines="None"
            AutoGenerateColumns="False"
            ShowHeaderWhenEmpty="True">
            <Columns>
                <asp:BoundField DataField="cardnumber" HeaderText="<%$ Resources:, cardnumber %>" />
                <asp:BoundField DataField="cardType" HeaderText="<%$ Resources:, cardType %>" />
                <asp:BoundField DataField="verificationCode" HeaderText="<%$ Resources:, verificationCode %>" />
                <asp:BoundField DataField="expeditionDate" HeaderText="<%$ Resources:, expeditionDate %>" />
                <asp:BoundField DataField="DefaultCard" Visible="true" />
                <asp:TemplateField HeaderText="<%$ Resources:, DefaultCard %>">
                    <ItemTemplate>
                        <asp:CheckBox ID="changeDefaultCard" AutoPostBack="true" OnDataBinding="ChangeDefaultCard_DataBinding" runat="server" OnCheckedChanged="ChangeDefaultCard_CheckedChanged" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </form>
</asp:Content>