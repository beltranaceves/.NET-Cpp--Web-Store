﻿<%@ Page Title="" Language="C#" MasterPageFile="~/PracticaMad.Master" AutoEventWireup="true" CodeBehind="UpdateClientDetails.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMad.Web.Pages.User.UpdateClientDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_MenuExplanation"
    runat="server">
    -
    <asp:Localize ID="lclMenuExplanation" runat="server" meta:resourcekey="lclMenuExplanation" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <div id="form">
        <form id="UpdateUserProfileForm" method="POST" runat="server">
            <asp:HyperLink ID="lnkChangePassword" runat="server"
                NavigateUrl="~/Pages/User/ChangePassword.aspx"
                meta:resourcekey="lnkChangePassword" />
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclFirstName" runat="server" meta:resourcekey="lclFirstName" /></span><span class="entry">
                        <asp:TextBox ID="txtFirstName" runat="server" Width="100" Columns="16"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvFirstName" runat="server"
                            ControlToValidate="txtFirstName" Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>" /></span>
            </div>

            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclFirstSurname" runat="server" meta:resourcekey="lclFirstSurname" /></span><span class="entry">
                        <asp:TextBox ID="txtFirstSurname" runat="server" Width="100" Columns="16"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvFirstSurname" runat="server"
                            ControlToValidate="txtFirstSurname" Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>" /></span>
            </div>

            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclSecondSurname" runat="server" meta:resourcekey="lclSecondSurname" /></span><span class="entry">
                        <asp:TextBox ID="txtSecondSurname" runat="server" Width="100" Columns="16"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvSecondSurname" runat="server"
                            ControlToValidate="txtSecondSurname" Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>" /></span>
            </div>

            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclEmail" runat="server" meta:resourcekey="lclEmail" /></span><span class="entry">
                        <asp:TextBox ID="txtEmail" runat="server" Width="100" Columns="130"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server"
                            ControlToValidate="txtEmail" Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>" />
                        <asp:RegularExpressionValidator ID="revEmail" runat="server"
                            ControlToValidate="txtEmail" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" meta:resourcekey="revEmail"></asp:RegularExpressionValidator></span>
            </div>

            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclAddress" runat="server" meta:resourcekey="lclAddress" /></span><span class="entry">
                        <asp:TextBox ID="txtAddress" runat="server" Width="100" Columns="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvAddress" runat="server"
                            ControlToValidate="txtAddress" Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>" /></span>
            </div>

            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclLanguage" runat="server" meta:resourcekey="lclLanguage" /></span><span class="entry">
                        <asp:DropDownList ID="comboLanguage" runat="server" AutoPostBack="True"
                            Width="100px" OnSelectedIndexChanged="ComboLanguageSelectedIndexChanged">
                        </asp:DropDownList></span>
            </div>
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclCountry" runat="server" meta:resourcekey="lclCountry" /></span><span class="entry">
                        <asp:DropDownList ID="comboCountry" runat="server" Width="100px">
                        </asp:DropDownList></span>
            </div>
            <div class="button">
                <asp:Button ID="btnUpdate" runat="server" OnClick="BtnUpdateClick" meta:resourcekey="btnUpdate" />
            </div>
        </form>
    </div>
</asp:Content>