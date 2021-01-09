<%@ Page Title="" Language="C#" MasterPageFile="~/PracticaMad.Master" AutoEventWireup="true" CodeBehind="CommentAdded.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMad.Web.Pages.Products.CommentAdded" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_MenuWelcome" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_MenuExplanation" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">

    <p>
        <asp:Label ID="lblAccCreatedTitle" runat="server" meta:resourcekey="lblAccountCreated" />
    </p>
    <p>
        <asp:Label ID="lblCommentCreated" runat="server" meta:resourcekey="lblCommentCreated" />:
        <strong>
            <asp:Label ID="lblCommentCreatedId" runat="server" />
        </strong>
    </p>
</asp:Content>