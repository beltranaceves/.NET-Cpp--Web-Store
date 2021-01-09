<%@ Page Title="" Language="C#" MasterPageFile="~/PracticaMad.Master" AutoEventWireup="true" CodeBehind="AddCard.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMad.Web.Pages.Card.AddCard" meta:resourcekey="PageResource1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_MenuExplanation" runat="server">

    <asp:Localize ID="lclMenuExplanation" runat="server" meta:resourcekey="lclMenuExplanation" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <form runat="server">
        <div id="form">

            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclCardType" runat="server" meta:resourcekey="lclCardType" />
                </span>
                <span class="entry">
                    <asp:CheckBox ID="chBCredit" AutoPostBack="true" OnCheckedChanged="chBCredit_CheckedChanged" Text="<%$ Resources: credit %>" runat="server" />
                    <asp:CheckBox ID="chBDebit" AutoPostBack="true" OnCheckedChanged="chBDebit_CheckedChanged" Text="<%$ Resources: debit %>" runat="server" />
                    <asp:Label ID="lblCardTypeError" runat="server" ForeColor="Red" Style="position: relative"
                        Visible="False" meta:resourcekey="lblCardTypeError"></asp:Label>
                </span>
            </div>

            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclCardNumber" runat="server" meta:resourcekey="lclCardNumber" />
                </span>
                <span class="entry">
                    <asp:TextBox ID="txtCreditCardNumber" runat="server" Width="100px" Columns="16" meta:resourcekey="txtCreditCardNumberResource1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvCreditCardNumber" runat="server" ControlToValidate="txtCreditCardNumber"
                        Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>" meta:resourcekey="rfvCreditCardNumberResource1"></asp:RequiredFieldValidator>
                    <asp:Label ID="lblCreditCardNumberError" runat="server" ForeColor="Red" Style="position: relative"
                        Visible="False" meta:resourcekey="lblCreditCardNumberError"></asp:Label>
                    <asp:Label ID="lblCreditCardNumberFormat" runat="server" ForeColor="Red" Style="position: relative"
                        Visible="False" meta:resourcekey="lblCardNumberFormat"></asp:Label>
                    <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtCreditCardNumber" ID="RegularExpressionValidator1" ValidationExpression="^[\s\S]{16,}$" runat="server" ErrorMessage="It must be 16 characters long"></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtCreditCardNumber" ID="RegularExpressionValidator2" ValidationExpression="^[\s\S]{0,16}$" runat="server" ErrorMessage="It must be 16 characters long"></asp:RegularExpressionValidator>
                </span>
            </div>

            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclExpirationDate" runat="server" meta:resourcekey="lclExpirationDate" />
                </span>
                <span class="entry">
                    <asp:DropDownList ID="dropMonth" runat="server">
                    </asp:DropDownList>
                    <asp:DropDownList ID="dropYear" runat="server"></asp:DropDownList>
                </span>
            </div>

            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclCV" runat="server" meta:resourcekey="lclCV" /></span><span
                        class="entry">
                        <asp:TextBox ID="txtCV" runat="server" Width="100px" Columns="16" meta:resourcekey="txtCVResource1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvCV" runat="server" ControlToValidate="txtCV"
                            Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>" meta:resourcekey="rfvCVResource1"></asp:RequiredFieldValidator>
                        <asp:Label ID="lblCVError" runat="server" ForeColor="Red" Style="position: relative"
                            Visible="False" meta:resourcekey="lblCVError"></asp:Label>
                        <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtCV" ID="RegularExpressionValidator3" ValidationExpression="^[\s\S]{3,}$" runat="server" ErrorMessage="It must be 3 characters long"></asp:RegularExpressionValidator>
                        <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtCV" ID="RegularExpressionValidator4" ValidationExpression="^[\s\S]{0,3}$" runat="server" ErrorMessage="It must be 3 characters long"></asp:RegularExpressionValidator>
                    </span>
            </div>

            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclDefaultCard" runat="server" meta:resourcekey="lclDefaultCard" />
                </span>
                <span class="entry">
                    <asp:CheckBox ID="defCard" AutoPostBack="true" OnCheckedChanged="chBdefCard_CheckedChanged" Text="" runat="server" />
                    <asp:Label ID="lblDefaultError" runat="server" ForeColor="Red" Style="position: relative"
                        Visible="False" meta:resourcekey="lblDefaultError"></asp:Label>
                </span>
            </div>


            <div class="button">
                <asp:Button ID="btnAddCard" runat="server" OnClick="btnAddCard_Click" meta:resourcekey="btnAddCard" />
            </div>
        </div>
    </form>
</asp:Content>