<%@ Page Title="" Language="C#" MasterPageFile="~/PracticaMad.Master" AutoEventWireup="true" CodeBehind="EditedComment.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMad.Web.Pages.Products.EditedComment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_MenuWelcome" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_MenuExplanation" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <p>
        <asp:Label ID="lblCommentEditedTitle" runat="server" meta:resourcekey="lblAccountCreated" />
    </p>
    <p>
        <asp:Label ID="lblCommentEdited" runat="server" meta:resourcekey="lblCommentEdited" />:
        <strong>
            <asp:Label ID="lblCommentEditedId" runat="server" />
        </strong>
    </p>
</asp:Content>