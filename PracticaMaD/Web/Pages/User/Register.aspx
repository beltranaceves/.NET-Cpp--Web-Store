<%@ Page Title="" Language="C#" MasterPageFile="~/PracticaMad.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs"
    Inherits="Es.Udc.DotNet.PracticaMad.Web.Pages.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_MenuExplanation"
    runat="server">
    -
    <asp:Localize ID="lclMenuExplanation" runat="server" meta:resourcekey="lclMenuExplanation" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_MenuLinks" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <form id="RegisterForm" method="post" runat="server">

        <div class="field">
            <asp:HyperLink ID="lnkClientExists" runat="server" meta:resourcekey="lnkClientExists" NavigateUrl="~/Pages/ClientExists.aspx"></asp:HyperLink>
        </div>

        <div class="field">
            <span class="label">
                <asp:Localize ID="lclClientLogin" runat="server" meta:resourcekey="lclClientLogin" />
            </span><span
                class="entry">
                <asp:TextBox ID="txtClientLogin" runat="server" Width="100px" Columns="16"
                    meta:resourcekey="txtClientLoginResource1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvClientLogin" runat="server" ControlToValidate="txtClientLogin"
                    Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>"
                    meta:resourcekey="rfvClientLoginResource1"></asp:RequiredFieldValidator>
                <asp:Label ID="lblClientLoginError" runat="server" ForeColor="Red" Style="position: relative"
                    Visible="False" meta:resourcekey="lblClientLoginError"></asp:Label></span>
        </div>

        <div class="field">
            <span class="label">
                <asp:Localize ID="lclPassword" runat="server" meta:resourcekey="lclPassword" /></span><span
                    class="entry">
                    <asp:TextBox TextMode="Password" ID="txtPassword" runat="server"
                        Width="100px" Columns="16" meta:resourcekey="txtPasswordResource1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                        Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>"
                        meta:resourcekey="rfvPasswordResource1"></asp:RequiredFieldValidator></span>
        </div>

        <div class="field">
            <span class="label">
                <asp:Localize ID="lclRetypePassword" runat="server" meta:resourcekey="lclRetypePassword" /></span><span
                    class="entry">
                    <asp:TextBox TextMode="Password" ID="txtRetypePassword" runat="server" Width="100px"
                        Columns="16" meta:resourcekey="txtRetypePasswordResource1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvRetypePassword" runat="server" ControlToValidate="txtRetypePassword"
                        Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>"
                        meta:resourcekey="rfvRetypePasswordResource1"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cvPasswordCheck" runat="server" ControlToCompare="txtPassword"
                        ControlToValidate="txtRetypePassword" meta:resourcekey="cvPasswordCheck"></asp:CompareValidator></span>
        </div>
        <div class="field">
            <span class="label">
                <asp:Localize ID="lclFirstName" runat="server" meta:resourcekey="lclFirstName" /></span><span
                    class="entry">
                    <asp:TextBox ID="txtFirstName" runat="server" Width="100px"
                        Columns="16" meta:resourcekey="txtFirstNameResource1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFirstName"
                        Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>"
                        meta:resourcekey="rfvFirstNameResource1"></asp:RequiredFieldValidator></span>
        </div>
        <div class="field">
            <span class="label">
                <asp:Localize ID="lclFirstSurname" runat="server" meta:resourcekey="lclFirstSurname" /></span><span
                    class="entry">
                    <asp:TextBox ID="txtFirstSurname" runat="server" Width="100px" Columns="16"
                        meta:resourcekey="txtFirstSurnameResource1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvFirstSurname" runat="server" ControlToValidate="txtFirstSurname"
                        Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>"
                        meta:resourcekey="rfvFirstSurnameResource1"></asp:RequiredFieldValidator></span>
        </div>
        <div class="field">
            <span class="label">
                <asp:Localize ID="lclSecondSurname" runat="server" meta:resourcekey="lclSecondSurname" /></span><span
                    class="entry">
                    <asp:TextBox ID="txtSecondSurname" runat="server" Width="100px" Columns="16"
                        meta:resourcekey="txtSecondSurnameResource1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSecondSurname"
                        Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>"
                        meta:resourcekey="rfvSecondSurnameResource1"></asp:RequiredFieldValidator></span>
        </div>

        <div class="field">
            <span class="label">
                <asp:Localize ID="lclAddress" runat="server" meta:resourcekey="lclAddress" /></span><span
                    class="entry">
                    <asp:TextBox ID="txtAddress" runat="server" Width="100px" Columns="16"
                        meta:resourcekey="txtAddress"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAddress"
                        Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>"
                        meta:resourcekey="rfvAddress"></asp:RequiredFieldValidator></span>
        </div>
        <div class="field">
            <span class="label">
                <asp:Localize ID="lclEmail" runat="server" meta:resourcekey="lclEmail" /></span><span
                    class="entry">
                    <asp:TextBox ID="txtEmail" runat="server" Width="100px" Columns="16"
                        meta:resourcekey="txtEmailResource1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                        Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>"
                        meta:resourcekey="rfvEmailResource1"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
                        Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        meta:resourcekey="revEmail"></asp:RegularExpressionValidator></span>
        </div>
        <div class="field">
            <span class="label">
                <asp:Localize ID="lclLanguage" runat="server" meta:resourcekey="lclLanguage" /></span><span
                    class="entry">
                    <asp:DropDownList ID="comboLanguage" runat="server" AutoPostBack="True"
                        Width="100px" meta:resourcekey="comboLanguageResource1"
                        OnSelectedIndexChanged="ComboLanguageSelectedIndexChanged">
                    </asp:DropDownList></span>
        </div>

        <div class="field">
            <span class="label">
                <asp:Localize ID="lclCountry" runat="server" meta:resourcekey="lclCountry" /></span><span
                    class="entry">
                    <asp:DropDownList ID="comboCountry" runat="server" Width="100px"
                        meta:resourcekey="comboCountryResource1">
                    </asp:DropDownList></span>
        </div>

        <div class="button">
            <asp:Button ID="btnRegister" runat="server" OnClick="BtnRegisterClick" meta:resourcekey="btnRegister" />
        </div>
    </form>
</asp:Content>