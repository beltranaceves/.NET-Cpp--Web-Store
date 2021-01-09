<%@ Page Title="" Language="C#" MasterPageFile="~/PracticaMad.Master" AutoEventWireup="true" CodeBehind="UpdateBooks.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMad.Web.Pages.Products.UpdateBooks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_MenuWelcome" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_MenuExplanation" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
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
                    <asp:Localize ID="lclAuthor" runat="server" meta:resourcekey="lclAuthor" /></span><span class="entry">
                        <asp:TextBox ID="txtAuthor" runat="server" Width="100" Columns="16"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ControlToValidate="txtAuthor" Display="Dynamic" ValidationExpression="\d+" Text="<%$ Resources:Common, mandatoryField %>" /></span>
            </div>

             <div class="field">
                <span class="label">
                    <asp:Localize ID="lclPages" runat="server" meta:resourcekey="lclPages" /></span><span class="entry">
                        <asp:TextBox ID="txtPages" runat="server" Width="100" Columns="16"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            ControlToValidate="txtPages" Display="Dynamic" ValidationExpression="\d+" Text="<%$ Resources:Common, mandatoryField %>" /></span>
            </div>

               <div class="field">
                <span class="label">
                    <asp:Localize ID="lclISBN" runat="server" meta:resourcekey="lclISBN" /></span><span class="entry">
                        <asp:TextBox ID="txtISBN" runat="server" Width="100" Columns="16"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                            ControlToValidate="txtISBN" Display="Dynamic" ValidationExpression="\d+" Text="<%$ Resources:Common, mandatoryField %>" /></span>
            </div>

              </div>

               <div class="field">
                <span class="label">
                    <asp:Localize ID="lclEditorial" runat="server" meta:resourcekey="lclEditorial" /></span><span class="entry">
                        <asp:TextBox ID="txtEditorial" runat="server" Width="100" Columns="16"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                            ControlToValidate="txtEditorial" Display="Dynamic" ValidationExpression="\d+" Text="<%$ Resources:Common, mandatoryField %>" /></span>
            </div>



            <div class="button">
                <asp:Button ID="btnUpdate" runat="server" OnClick="BtnUpdateClick" meta:resourcekey="btnUpdate" />
            </div>
        </form>
    </div>
</asp:Content>