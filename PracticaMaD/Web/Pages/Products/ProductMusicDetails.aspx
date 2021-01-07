<%@ Page Title="" Language="C#" MasterPageFile="~/PracticaMad.Master" AutoEventWireup="true" CodeBehind="ProductMusicDetails.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMad.Web.Pages.Products.ProductMusicDetails" meta:resourcekey="PageResource1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_MenuExplanation" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_MenuLinks" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    

   <span>
            <asp:Label ID="lclDetails" Font-Bold="true" Font-Size="Medium" runat="server" meta:resourcekey="lclDetails" />
        </span>
       
        <br />
        <p>
        <asp:Label ID="lblInvalidProduct" meta:resourcekey="lblInvalidProduct" runat="server" Visible="false"></asp:Label>
    </p>
        <p>
        <asp:Label ID="lblEditedProduct" meta:resourcekey="lblEditedProduct" runat="server" Visible="false"></asp:Label>
    </p>
       
        <br />

     <asp:Table CssClass="productDetails" CssClas="oneProduct" runat="server">
        <asp:TableRow runat="server">
            <asp:TableHeaderCell ID="cellCaptionProductName" runat="server" Text="<%$ Resources:Common, productName %>"></asp:TableHeaderCell>
            <asp:TableCell ID="cellProductName" runat="server"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableHeaderCell ID="cellCaptionProductPrize" runat="server" Text="<%$ Resources:Common, prize %>"></asp:TableHeaderCell>
            <asp:TableCell ID="cellProductPrize" runat="server"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableHeaderCell ID="cellCaptionProductCategory" runat="server" Text="<%$ Resources:Common, category %>"></asp:TableHeaderCell>
            <asp:TableCell ID="cellProductCategory" runat="server"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableHeaderCell ID="cellCaptionArtis" runat="server" Text="<%$ Resources: artist %>"></asp:TableHeaderCell>
            <asp:TableCell ID="cellArtist" runat="server"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableHeaderCell ID="cellCaptionGenere" runat="server" Text="<%$ Resources: genere %>"></asp:TableHeaderCell>
            <asp:TableCell ID="cellGenere" runat="server"></asp:TableCell>
        </asp:TableRow>
          <asp:TableRow runat="server">
            <asp:TableHeaderCell ID="cellCaptionType" runat="server" Text="<%$ Resources: type %>"></asp:TableHeaderCell>
            <asp:TableCell ID="cellType" runat="server"></asp:TableCell>
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