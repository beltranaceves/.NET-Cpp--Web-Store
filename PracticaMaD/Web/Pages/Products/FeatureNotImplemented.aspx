<%@ Page Title="" Language="C#" MasterPageFile="~/PracticaMad.Master" AutoEventWireup="true" CodeBehind="FeatureNotImplemented.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMad.Web.Pages.Products.FeatureNotImplemented" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_MenuExplanation" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <div id="label">
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lblFNI" runat="server" Text="<%$ Resources:Common, featureNI%>" />
                </span>
            </div>
    </div>
    <br />
    <br />
</asp:Content>