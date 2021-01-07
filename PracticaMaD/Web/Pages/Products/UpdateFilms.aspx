<%@ Page Title="" Language="C#" MasterPageFile="~/PracticaMad.Master" AutoEventWireup="true" CodeBehind="UpdateFilms.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMad.Web.Pages.Products.UpdateFilms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_MenuWelcome" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_MenuExplanation" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_MenuLinks" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <div id="form">
        <form id="UpdateProductForm" method="POST" runat="server">
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclProductName" runat="server" meta:resourcekey="lclProductName" /></span><span class="entry">
                        <asp:TextBox ID="txtProductName" runat="server" Width="100" Columns="16"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvProductName" runat="server"
                            ControlToValidate="txtProductName" Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>" /></span>
            </div>

            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclStock" runat="server" meta:resourcekey="lclStock" /></span><span class="entry">
                        <asp:TextBox ID="txtStock" runat="server" Width="100" Columns="16"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvStock" runat="server"
                            ControlToValidate="txtStock" Display="Dynamic" ValidationExpression="\d+" Text="<%$ Resources:Common, mandatoryField %>" /></span>
            </div>

            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclPrice" runat="server" meta:resourcekey="lclPrice" /></span><span class="entry">
                        <asp:TextBox ID="txtPrice" runat="server" Width="100" Columns="16"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPrice" runat="server"
                            ControlToValidate="txtPrice" Display="Dynamic" ValidationExpression="\d+" Text="<%$ Resources:Common, mandatoryField %>" /></span>
            </div>


            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclDirector" runat="server" meta:resourcekey="lclDirector" /></span><span class="entry">
                        <asp:TextBox ID="txtDirector" runat="server" Width="100" Columns="16"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ControlToValidate="txtDirector" Display="Dynamic" ValidationExpression="\d+" Text="<%$ Resources:Common, mandatoryField %>" /></span>
            </div>

             <div class="field">
                <span class="label">
                    <asp:Localize ID="lclFilmYear" runat="server" meta:resourcekey="lclFilmYear" /></span><span class="entry">
                        <asp:TextBox ID="txtFilmYear" runat="server" Width="100" Columns="16"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            ControlToValidate="txtFilmYear" Display="Dynamic" ValidationExpression="\d+" Text="<%$ Resources:Common, mandatoryField %>" /></span>
            </div>

               <div class="field">
                <span class="label">
                    <asp:Localize ID="lclDuration" runat="server" meta:resourcekey="lclDuration" /></span><span class="entry">
                        <asp:TextBox ID="txtDuration" runat="server" Width="100" Columns="16"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                            ControlToValidate="txtDuration" Display="Dynamic" ValidationExpression="\d+" Text="<%$ Resources:Common, mandatoryField %>" /></span>
            </div>

              </div>

               <div class="field">
                <span class="label">
                    <asp:Localize ID="lclGenere" runat="server" meta:resourcekey="lclGenere" /></span><span class="entry">
                        <asp:TextBox ID="txtGenere" runat="server" Width="100" Columns="16"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                            ControlToValidate="txtGenere" Display="Dynamic" ValidationExpression="\d+" Text="<%$ Resources:Common, mandatoryField %>" /></span>
            </div>



            <div class="button">
                <asp:Button ID="btnUpdate" runat="server" OnClick="BtnUpdateClick" meta:resourcekey="btnUpdate" />
            </div>
        </form>
    </div>
</asp:Content>