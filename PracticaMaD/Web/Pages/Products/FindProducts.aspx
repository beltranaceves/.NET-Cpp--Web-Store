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
                </span>
            </div>

            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclCategory" runat="server" meta:resourcekey="lclCategory" /></span><span class="entry">
                        <asp:DropDownList ID="comboCategory" runat="server" AutoPostBack="True"
                            Width="100px">
                        </asp:DropDownList></span>
            </div>

            <div class="button">
                <asp:Button ID="btnFind" runat="server" meta:resourcekey="btnFind" OnClick="BtnFindClick" />
            </div>
        </form>
    </div>
    <br />
    <br />
</asp:Content>