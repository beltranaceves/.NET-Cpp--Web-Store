<%@ Page Title="" Language="C#" MasterPageFile="~/PracticaMad.Master" AutoEventWireup="true" CodeBehind="ProductFilmsDetails.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMad.Web.Pages.Products.ProductFilmsDetails" meta:resourcekey="PageResource1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_MenuExplanation" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_MenuLinks" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
   

 
        <br />
        <p>
        <asp:Label ID="lblInvalidProduct" meta:resourcekey="lblInvalidProduct" runat="server" Visible="false"></asp:Label>
    </p>
        <p>
        <asp:Label ID="lblEditedProduct" meta:resourcekey="lblEditedProduct" runat="server" Visible="false"></asp:Label>
    </p>



        <span>
            <asp:Label ID="lclDetails" Font-Bold="true" Font-Size="Medium" runat="server" meta:resourcekey="lclDetails" />
        </span>
        <br />

     <asp:Table CssClass="productDetails" CssClas="oneProduct" runat="server">
     
        <asp:TableRow runat="server">
            <asp:TableHeaderCell ID="cellCaptionDirector" runat="server" Text="<%$ Resources: director %>"></asp:TableHeaderCell>
            <asp:TableCell ID="cellDirector" runat="server"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableHeaderCell ID="cellCaptionFilmYear" runat="server" Text="<%$ Resources: filmYear %>"></asp:TableHeaderCell>
            <asp:TableCell ID="cellFilmYear" runat="server"></asp:TableCell>
        </asp:TableRow>
          <asp:TableRow runat="server">
            <asp:TableHeaderCell ID="cellCaptionDuration" runat="server" Text="<%$ Resources: duration %>"></asp:TableHeaderCell>
            <asp:TableCell ID="cellDuration" runat="server"></asp:TableCell>
        </asp:TableRow>
            <asp:TableRow runat="server">
            <asp:TableHeaderCell ID="cellCaptionGenere" runat="server" Text="<%$ Resources: genere %>"></asp:TableHeaderCell>
            <asp:TableCell ID="cellGenere" runat="server"></asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <form id="AddCommentForm" method="post" runat="server">
        <div class="button">
            <asp:Button ID="btnAddComment" runat="server" Visible="false" meta:resourcekey="btnAddComment" OnClick="BtnAddCommentClick" />
        </div>
        <div class="button">
            <asp:Button ID="btnEditComment" runat="server" Visible="false" meta:resourcekey="btnEditComment" OnClick="BtnEditCommentClick" />
        </div>
        <div class="button">
            <asp:Button ID="btnEditProduct" runat="server" Visible="false" meta:resourcekey="btnEditProduct" OnClick="BtnEditProductClick" />
        </div>
        <asp:GridView ID="gvComment" runat="server" CssClass="comments" GridLines="None"
            AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="ProductId" ItemStyle-CssClass="Hide" />
                <asp:BoundField DataField="CommentText" HeaderText="<%$ Resources:Common, CommentText %>" />
                <asp:BoundField DataField="CommentDate" HeaderText="<%$ Resources:Common, CommentDate %>" />
            </Columns>
        </asp:GridView>


        <br />
        <br />
    </form>
</asp:Content>