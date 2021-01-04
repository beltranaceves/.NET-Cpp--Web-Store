﻿<%@ Page Title="" Language="C#" MasterPageFile="~/PracticaMad.Master" AutoEventWireup="true" CodeBehind="ManageOrder.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMad.Web.Pages.Orders.ManageOrder" meta:resourcekey="PageResource1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_MenuExplanation" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_MenuLinks" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <br />
    <form runat="server">
        <br />
        <div>
     
        <span>
            <asp:Label ID="lblThisIsYourAddres" Font-Bold="true" Font-Size="Medium" runat="server" meta:resourcekey="lblThisIsYourAddres"/>
        </span>
             <span>
            <asp:Label ID="lblClientAddres" Font-Bold="true" Font-Size="Medium" runat="server" meta:resourcekey="lblClientAddres"/>
        </span>

           
         <div class="button">
                <asp:Button ID="ButtonAddres" runat="server" OnClick="btnAddres_Click" meta:resourcekey="ButtonAddres" />
            </div>

             <div class="button">
                <asp:Button ID="CloseAddres" runat="server" OnClick="btnCloseAddres_Click" meta:resourcekey="CloseAddres" />
            </div>


        </div>
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclAddress" runat="server" meta:resourcekey="lclAddress"  /></span><span
                        class="entry">
                        <asp:TextBox ID="txtAddress" runat="server" Width="100px" Columns="16" meta:resourcekey="txtAddress" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtAddress"
                            Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>" meta:resourcekey="rfvAddress" ></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cvAddress" runat="server" ControlToValidate="txtAddress" Type="String"
                         Operator="DataTypeCheck" meta:resourcekey="cvAddress"  /></span>
        </div>

        <br />
        <div class="button">
        <span>
            <asp:Label ID="lclPayMethod" Font-Bold="true" Font-Size="Medium" runat="server" meta:resourcekey="lclPayMethod"  />
        </span>
        </div>
        <br />
        <asp:GridView ID="gvCards"  runat="server"
            AutoGenerateColumns="False"
            OnSelectedIndexChanging="gvCards_SelectedIndexChanging"
            ShowHeaderWhenEmpty="True"  >
            <Columns>
               <asp:BoundField DataField="cardnumber" HeaderText="cardnumber" />
                <asp:BoundField DataField="cardType" HeaderText="cardType" />
                <asp:BoundField DataField="verificationCode" HeaderText="verificationCode" />
                <asp:BoundField DataField="expeditionDate" HeaderText="expeditionDate" />
                <asp:BoundField DataField="DefaultCard"  Visible="true" />
                <asp:TemplateField HeaderText="DefaultCard">
                    <ItemTemplate>
                        <asp:CheckBox ID="changeDefaultCard" AutoPostBack="true" OnDataBinding="changeDefaultCard_DataBinding" runat="server" OnCheckedChanged="changeDefaultCard_CheckedChanged" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
          

        
        <span>
            <asp:Label ID="lblSlectPayMethod" Font-Bold="true" Font-Size="Medium" runat="server" meta:resourcekey="lblSlectPayMethod"/>
        </span>

         <div class="button">
                <asp:Button ID="ButtonCreditCard" runat="server" OnClick="btnCreditCard_Click" meta:resourcekey="ButtonCreditCard" />
            
            </div>

        
             <div class="button">
                <asp:Button ID="ButtonCreditCardClose" runat="server" OnClick="btnCreditCardClose_Click" meta:resourcekey="ButtonCreditCardClose" />
            </div>



            <div id="form">
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclCardType" runat="server" meta:resourcekey="lclCardType" />
                </span>
                <span class="entry">
                    <asp:CheckBox ID="chBVisa" AutoPostBack="true" OnCheckedChanged="chBVisa_CheckedChanged" Text="Visa" runat="server" />
                    <asp:CheckBox ID="chBMasterCard" AutoPostBack="true" OnCheckedChanged="chBMasterCard_CheckedChanged" Text="MasterCard" runat="server" />
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
                        Visible="False" meta:resourcekey="lblCreditCardNumberErrorResource1"></asp:Label>
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
    </div>
        <br />
        
        <div class="button">
        <span>
            <asp:Label ID="lclProductList" Font-Bold="true" Font-Size="Medium" runat="server" meta:resourcekey="lclProductListResource1" />
        </span>
        </div>
        <br />
        <asp:GridView ID="gvShoppingCart"  runat="server" 
            AutoGenerateColumns="False"
             OnRowCreated="gvShoppingCart_RowCreated"
             OnSelectedIndexChanging="gvShoppingCart_SelectedIndexChanging"
            OnRowDataBound="gvShoppingCart_RowDataBound"
            ShowHeaderWhenEmpty="True" meta:resourcekey="gvShoppingCartResource2">
            <Columns>
            <asp:BoundField DataField="productId" HeaderText="productId" Visible="true" meta:resourcekey="BoundFieldResource17" />
            <asp:BoundField DataField="price" HeaderText="productPrice" meta:resourcekey="BoundFieldResource15" />
            <asp:BoundField DataField="quantity" HeaderText="quantity" Visible="true" meta:resourcekey="BoundFieldResource17" />

             <asp:TemplateField HeaderText="forGift">
                <ItemTemplate>
                    <asp:CheckBox ID="cbForGift" AutoPostBack="true" runat="server" OnCheckedChanged="cbForGift_CheckedChanged" />
                </ItemTemplate>
             </asp:TemplateField>     
            <asp:TemplateField HeaderText="quantity" meta:resourcekey="TemplateFieldResource2">
                <ItemTemplate>
                    <asp:DropDownList ID="quantityList"  AutoPostBack="True" runat="server"  OnSelectedIndexChanged="quantityList_SelectedIndexChanged" meta:resourcekey="quantityListResource2">
                        <asp:ListItem Value="1" meta:resourcekey="ListItemResource8">1</asp:ListItem>
                        <asp:ListItem Value="2" meta:resourcekey="ListItemResource9">2</asp:ListItem>
                        <asp:ListItem  Value="3" meta:resourcekey="ListItemResource10">3</asp:ListItem>
                        <asp:ListItem  Value="4" meta:resourcekey="ListItemResource11">4</asp:ListItem>
                        <asp:ListItem value="5" meta:resourcekey="ListItemResource12">5</asp:ListItem>
                        <asp:ListItem Value="6" meta:resourcekey="ListItemResource13">6</asp:ListItem>
                        <asp:ListItem Value="7" meta:resourcekey="ListItemResource14">7</asp:ListItem>
                        <asp:ListItem Value="8" meta:resourcekey="ListItemResource15">8</asp:ListItem>
                        <asp:ListItem Value="9" meta:resourcekey="ListItemResource16">9</asp:ListItem>
                        <asp:ListItem Value="10" meta:resourcekey="ListItemResource17">10</asp:ListItem>
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
        <asp:CommandField ShowSelectButton="True" SelectText="deleteProduct" meta:resourcekey="CommandFieldResource3"/>           
        </Columns>
        </asp:GridView>
        </div>
        <br />
       
        
          </div>
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclDescrtiption" runat="server" meta:resourcekey="lclDescrtiption"  /></span><span
                        class="entry">
                        <asp:TextBox ID="txtDescription" runat="server" Width="100px" Columns="16" meta:resourcekey="txtDescription" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDescription"
                            Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>" meta:resourcekey="rfvDescription" ></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtDescription" Type="String"
                         Operator="DataTypeCheck" meta:resourcekey="cvDescription"  /></span>
        </div>
        
        
        
        
        <div class="button">
                <span>
                    <asp:Label ID="lblError" Font-Bold="true" ForeColor="Red" runat="server" meta:resourcekey="lblError" /></span>
            </div>
        <br />
            <div class="button">
                <span>
                    <asp:Label ID="lclPrize" Font-Bold="true" runat="server" meta:resourcekey="lclPrizeResource1" /></span>
                <asp:TextBox ID="txtPrizeTotal" ReadOnly="True" runat="server" meta:resourcekey="txtPrizeTotalResource2"></asp:TextBox>
            </div>
        <br />
            <div class="button">
                <asp:Button ID="btnPay" runat="server" OnClick="btnToPay_Click" meta:resourcekey="btnPay" />
            </div>
    </form>
    <br />
</asp:Content>
