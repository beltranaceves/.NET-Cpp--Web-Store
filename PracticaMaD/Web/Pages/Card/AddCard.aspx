<%@ Page Title="" Language="C#" MasterPageFile="~/PracticaMaD.Master" AutoEventWireup="true" CodeBehind="AddCard.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMaD.WebApplication.Pages.Card.AddCard" meta:resourcekey="PageResource1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_MenuExplanation" runat="server">
     
    <asp:Localize ID="lclMenuExplanation" runat="server" meta:resourcekey="lclMenuExplanation" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <form runat="server">
    <div id="form">
      
        
        <div class="field">
                <span class="label">
                    <asp:Localize ID="lclCardNumber" runat="server" meta:resourcekey="lclCardNumberResource1"/>
                </span>
                <span class="entry">
                <asp:TextBox ID="txtCreditCardNumber" runat="server" Width="100px" Columns="16" meta:resourcekey="txtCreditCardNumberResource1" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvCreditCardNumber" runat="server" ControlToValidate="txtCreditCardNumber"
                    Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>" meta:resourcekey="rfvCreditCardNumberResource1"></asp:RequiredFieldValidator>
                <asp:Label ID="lblCreditCardNumberError" runat="server" ForeColor="Red" Style="position: relative"
                    Visible="False" meta:resourcekey="lblCreditCardNumberErrorResource1"></asp:Label>
                    <asp:Label ID="lblCreditCardNumberFormat" runat="server" ForeColor="Red" Style="position: relative"
                    Visible="False" meta:resourcekey="lblCardNumberFormat"></asp:Label>
                </span>
            </div>

            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclCardType" runat="server" meta:resourcekey="lclCardTypeResource1"  />
                </span>
                <span class="entry">
                    <asp:CheckBox ID="chBVisa" AutoPostBack="true" OnCheckedChanged="chBVisa_CheckedChanged" Text="<%$ Resources:, Visa %>"  runat="server" />
                    <asp:CheckBox ID="chBMasterCard" AutoPostBack="true" OnCheckedChanged="chBMasterCard_CheckedChanged" Text="<%$ Resources:, MasterCard %>" runat="server" />
                     <asp:Label ID="lblCardTypeError" runat="server" ForeColor="Red" Style="position: relative"
                    Visible="False" meta:resourcekey="lblCardTypeError"></asp:Label>
               </span>
            </div>


            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclExpirationDate" runat="server" meta:resourcekey="lclExpirationDateResource1" />
                </span>
                <span class="entry">
                    <asp:DropDownList ID="dropMonth" runat="server">
                    </asp:DropDownList> 
                    <asp:DropDownList ID="dropYear" runat="server"></asp:DropDownList>  
                </span>
            </div>

            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclCV" runat="server" meta:resourcekey="lclCVResource1"/></span><span
                        class="entry">
                        <asp:TextBox ID="txtCV" runat="server" Width="100px" Columns="16" meta:resourcekey="txtCVResource1" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvCV" runat="server" ControlToValidate="txtCV"
                            Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>" meta:resourcekey="rfvCVResource1" ></asp:RequiredFieldValidator>
                         <asp:Label ID="lblCVError" runat="server" ForeColor="Red" Style="position: relative"
                    Visible="False" meta:resourcekey="lblCVError"></asp:Label>
                                                                                                      </span>
            </div>

        <div class="field">
                <span class="label">
                    <asp:Localize ID="lclDefaultCard" runat="server" meta:resourcekey="lclDefaultCardResource1"  />
                </span>
                <span class="entry">
                    <asp:CheckBox ID="defCard" AutoPostBack="true" OnCheckedChanged="chBTrue_CheckedChanged" Text="<%$ Resources:, True %>"  runat="server" />
                     <asp:Label ID="lblDefaultError" runat="server" ForeColor="Red" Style="position: relative"
                    Visible="False" meta:resourcekey="lblDefaultError"></asp:Label>
               </span>
            </div>




            <div class="button">
                <asp:Button ID="btnAddCard" runat="server" OnClick="btnAddCard_Click" meta:resourcekey="btnAddCardResource1"/>
            </div>
    </div>
    </form>
</asp:Content>
