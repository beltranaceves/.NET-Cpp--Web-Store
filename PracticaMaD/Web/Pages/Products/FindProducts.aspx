<%@ Page Title="" Language="C#" MasterPageFile="~/PracticaMad.Master" AutoEventWireup="true" CodeBehind="FindProducts.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMad.Web.Pages.Products.FindProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_MenuExplanation" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_MenuLinks" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <div id="form">
        <form id="FindProductForm" method="post" runat="server">
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclKeyword" runat="server" Text="<%$ Resources:Common, keyword %>" />
                </span><span class="entry">
                    <asp:TextBox ID="txtKeyword" runat="server" Width="200px" Columns="16" />
                    <asp:RequiredFieldValidator ID="rfvKeyword" runat="server" ControlToValidate="txtKeyword"
                        Display="Dynamic" Text="<%$ Resources: Common, mandatoryField %>" CssClass="errorMessage" />
                </span>
            </div>

            <div class="button">
                <asp:Button ID="btnFind" runat="server" meta:resourcekey="btnFind" OnClick="BtnFindClick" />
            </div>
        </form>
    </div>
    <br />
    <br />
</asp:Content>