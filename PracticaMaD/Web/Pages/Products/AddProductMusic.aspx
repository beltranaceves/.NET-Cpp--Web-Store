<%@ Page Title="" Language="C#" MasterPageFile="~/PracticaMad.Master" AutoEventWireup="true" CodeBehind="AddProductMusic.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMad.Web.Pages.Products.AddProductMusic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_MenuExplanation" runat="server">
    -
    <asp:Localize ID="lclMenuExplanation" runat="server" meta:resourcekey="lclMenuExplanation" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">

    <div id="form">
        <form id="AddCommentForm" method="POST" runat="server">
            <asp:HyperLink ID="lnkChangePassword" runat="server"
                NavigateUrl="~/Pages/Products/ShowOneProduct.aspx"
                meta:resourcekey="lnkChangePassword" />
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclProductName" runat="server" meta:resourcekey="lclProductName" /></span><span class="entry">
                        <asp:TextBox ID="TextProductName" runat="server" Width="100" Columns="16"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvComment" runat="server" ValidationGroup="ValidateAddComment"
                            ControlToValidate="TextProductName" Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>" /></span>
            </div>
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclPrice" runat="server" meta:resourcekey="lclPrice" /></span><span class="entry">
                        <asp:TextBox TextMode="number" ID="TextPrice" runat="server" Width="100" Columns="16"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="ValidateAddComment"
                            ControlToValidate="TextPrice" Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>" /></span>
            </div>
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclArtist" runat="server" meta:resourcekey="lclArtist" /></span><span class="entry">
                        <asp:TextBox ID="TextArtist" runat="server" Width="100" Columns="16"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="ValidateAddComment"
                            ControlToValidate="TextArtist" Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>" /></span
            </div>
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclGenre" runat="server" meta:resourcekey="lclGenre" /></span><span class="entry">
                        <asp:TextBox ID="TextGenre" runat="server" Width="100" Columns="16"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="ValidateAddComment"
                            ControlToValidate="TextGenre" Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>" /></span
            </div>
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclType" runat="server" meta:resourcekey="lclType" /></span><span class="entry">
                        <asp:TextBox ID="TextType" runat="server" Width="100" Columns="16"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="ValidateAddComment"
                            ControlToValidate="TextType" Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>" /></span>
            </div>
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclUnits" runat="server" meta:resourcekey="lclUnits" /></span><span class="entry">
                        <asp:TextBox TextMode="number" ID="TextUnits" runat="server" Width="100" Columns="16"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="ValidateAddComment"
                            ControlToValidate="TextUnits" Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>" /></span>
            </div>
            <br />
            <br />
            <br />
            <div class="button">
                <asp:Button ID="btnAddProduct" runat="server" OnClick="BtnAddProductClick" ValidationGroup="ValidateAddComment" meta:resourcekey="BtnAddProduct" />
            </div>
        </form>
    </div>
</asp:Content>