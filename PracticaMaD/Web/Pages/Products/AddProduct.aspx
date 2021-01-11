<%@ Page Title="" Language="C#" MasterPageFile="~/PracticaMad.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMad.Web.Pages.Products.AddProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_MenuExplanation" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <div id="form">
        <form id="AddProductForm" method="post" runat="server">
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclCategoryCombo" runat="server" Text="<%$ Resources:Common, category %>" />
                </span>
                    <asp:Localize ID="lclCombo" runat="server" /><span class="entry">
                        <asp:DropDownList ID="comboCategory1" runat="server" AutoPostBack="True"
                            Width="100px">
                        </asp:DropDownList></span>
            </div>

            <div class="button">
                <asp:Button ID="btnAdd" runat="server" meta:resourcekey="btnNext" OnClick="BtnFindClick" />
            </div>
        </form>
    </div>
    <br />
    <br />
</asp:Content>