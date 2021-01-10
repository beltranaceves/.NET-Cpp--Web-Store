<%@ Page Title="" Language="C#" MasterPageFile="~/PracticaMad.Master" AutoEventWireup="true" CodeBehind="AddComment.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMad.Web.Pages.Products.AddComment" %>

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
                    <asp:Localize ID="lclComment" runat="server" meta:resourcekey="lclComment" /></span><span class="entry">
                        <asp:TextBox ID="txtComment" runat="server" Width="100" Columns="16"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvComment" runat="server" ValidationGroup="ValidateAddComment"
                            ControlToValidate="txtComment" Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>" /></span>
            </div>
            <br />
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
                                <asp:CheckBox ID="addTag" ValidationGroup="ValidateAddTag" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

                <div class="field">
                    <span class="label">
                        <asp:Localize ID="lclTag" runat="server" meta:resourcekey="lclTag" />
                    </span><span class="entry">

                        <asp:TextBox ID="txtTag" runat="server" ValidationGroup="ValidateAddTag" Width="200px" Columns="16" />
                        <asp:RequiredFieldValidator ID="rfvTag" runat="server" ControlToValidate="txtTag" ValidationGroup="ValidateAddTag"
                            Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>" meta:resourcekey="rfvTag"></asp:RequiredFieldValidator>
                        <asp:Label ID="lblTagError" runat="server" ForeColor="Red" Style="position: relative"
                            Visible="False" meta:resourcekey="lblTagError">
                        </asp:Label>
                    </span>
                </div>
                <div class="button">
                    <asp:Button ID="btnAddTag" runat="server" OnClick="BtnAddTag" ValidationGroup="ValidateAddTag" meta:resourcekey="btnAddTag" />
                </div>
            </div>

            <div class="button">
                <asp:Button ID="btnAddComment" runat="server" OnClick="BtnAddCommentClick" ValidationGroup="ValidateAddComment" meta:resourcekey="BtnAddComment" />
            </div>
        </form>
    </div>
</asp:Content>