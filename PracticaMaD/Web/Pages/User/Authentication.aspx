<%@ Page Language="C#" MasterPageFile="~/PracticaMad.Master"
    AutoEventWireup="true" CodeBehind="Authentication.aspx.cs"
    Inherits="Es.Udc.DotNet.PracticaMad.Web.Pages.User.Authentication"
    meta:resourcekey="Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_MenuExplanation"
    runat="server">
    -
    <asp:Localize ID="lclMenuExplanation" runat="server" meta:resourcekey="lclMenuExplanation" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <asp:HyperLink ID="lnkRegister" runat="server" NavigateUrl="~/Pages/User/Register.aspx" meta:resourcekey="lnkRegister" />
    <div id="form">
        <form id="AuthenticationForm" method="POST" runat="server">
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclClientLogin" runat="server" meta:resourcekey="lclClientLogin" /></span><span
                        class="entry">
                        <asp:TextBox ID="txtClientLogin" runat="server" Width="100" Columns="16"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvLogin" runat="server"
                            ControlToValidate="txtClientLogin" Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>" />
                        <asp:Label ID="lblClientLoginError" runat="server" ForeColor="Red" Style="position: relative"
                            Visible="False" meta:resourcekey="lblClientLoginError">
                        </asp:Label>
                    </span>
            </div>
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclPassword" runat="server" meta:resourcekey="lclPassword" /></span><span
                        class="entry">
                        <asp:TextBox TextMode="Password" ID="txtPassword" runat="server" Width="100" Columns="16"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server"
                            ControlToValidate="txtPassword" Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>" />
                        <asp:Label ID="lblPasswordError" runat="server" ForeColor="Red" Style="position: relative"
                            Visible="False" meta:resourcekey="lblPasswordError">
                        </asp:Label>
                    </span>
            </div>
            <div class="checkbox">
                <asp:CheckBox ID="checkRememberPassword" runat="server" TextAlign="Left" meta:resourcekey="checkRememberPassword" />
            </div>
            <div class="button">
                <asp:Button ID="btnLogin" runat="server" OnClick="BtnLoginClick" meta:resourcekey="btnLogin" />
            </div>
        </form>
    </div>
</asp:Content>