<%@ Page Title="" Language="C#" MasterPageFile="~/PracticaMad.Master" AutoEventWireup="true" CodeBehind="EditComment.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMad.Web.Pages.Products.EditComment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_MenuWelcome" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_MenuExplanation" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">

    <div id="form">
        <form id="UpdateUserProfileForm" method="POST" runat="server">

            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclComment" runat="server" meta:resourcekey="lclComment" /></span><span class="entry">
                        <asp:TextBox ID="txtComment" runat="server" Width="100" Columns="16"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvComment" runat="server" ValidationGroup="ValidateUpdate"
                            ControlToValidate="txtComment" Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>" /></span>
            </div>

            <br />
            <br />
            <div>
                <asp:GridView ID="gvTagList" runat="server" GridLines="None" CssClass="tagsComment"
                    AutoGenerateColumns="False"
                    ShowHeaderWhenEmpty="False">
                    <Columns>
                        <asp:BoundField DataField="TagName" HeaderText="<%$ Resources:, TagName %>" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="addTag" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

                <div class="field">
                    <span class="label">
                        <asp:Localize ID="lclTag" runat="server" meta:resourcekey="lclTag" />
                    </span><span class="entry">

                        <asp:TextBox ID="txtTag" runat="server" Width="200px" Columns="16" />
                        <asp:RequiredFieldValidator ID="rfvTag" runat="server" ControlToValidate="txtTag" ValidationGroup="ValidateAddTag"
                            Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>" meta:resourcekey="rfvTag"></asp:RequiredFieldValidator>
                        <asp:Label ID="lblTagError" runat="server" ForeColor="Red" Style="position: relative"
                            Visible="False" meta:resourcekey="lblTagError">
                        </asp:Label>
                        <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtTag" ID="RegularExpressionValidator3" ValidationExpression="^[\s\S]{3,}$" runat="server" ErrorMessage="<%$ resources:invalidCV %>"></asp:RegularExpressionValidator>
                    </span>
                </div>
                <div class="button">
                    <asp:Button ID="btnAddTag" runat="server" OnClick="BtnAddTag" ValidationGroup="ValidateAddTag" meta:resourcekey="btnAddTag" />
                </div>
            </div>

            <div class="button">
                <asp:Button ID="btnUpdate" runat="server" OnClick="BtnUpdateClick" ValidationGroup="ValidateUpdate" meta:resourcekey="btnUpdate" />
            </div>

            <div class="button">
                <asp:Button ID="btnDelete" runat="server" OnClick="BtnDeleteClick" ValidationGroup="ValidatDelte" meta:resourcekey="btnDelete" />
            </div>
        </form>
    </div>
</asp:Content>