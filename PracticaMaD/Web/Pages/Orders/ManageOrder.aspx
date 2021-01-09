<%@ Page Title="" Language="C#" MasterPageFile="~/PracticaMad.Master" AutoEventWireup="true" CodeBehind="ManageOrder.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMad.Web.Pages.Orders.ManageOrder" meta:resourcekey="PageResource1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_MenuExplanation" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <br />
    <form runat="server">
        <br />
        <div>

            <span>
                <asp:Label ID="lblThisIsYourAddres" Font-Bold="true" Font-Size="Medium" runat="server" meta:resourcekey="lblThisIsYourAddres" />
            </span>

            <span>
                <asp:Label ID="lblClientAddres" Font-Bold="true" Font-Size="Medium" runat="server" meta:resourcekey="lblClientAddres" />
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
                <asp:Localize ID="lclAddress" runat="server" meta:resourcekey="lclAddress" /></span><span
                    class="entry">
                    <asp:TextBox ID="txtAddress" runat="server" Width="100px" Columns="16" meta:resourcekey="txtAddress"></asp:TextBox>
                    <asp:CompareValidator ID="cvAddress" runat="server" ControlToValidate="txtAddress" Type="String"
                        Operator="DataTypeCheck" meta:resourcekey="cvAddress" /></span>
        </div>

        <br />

        <br />
        <br />
        <br />

        <span>
            <asp:Label ID="lblSlectPayMethod" Font-Bold="true" Font-Size="Medium" runat="server" meta:resourcekey="lblSlectPayMethod" />
        </span>

        <div class="button">
            <asp:Button ID="ButtonCreditCard" runat="server" OnClick="btnCreditCard_Click" meta:resourcekey="ButtonCreditCard" />
        </div>

        <div class="button">
            <asp:Button ID="ButtonCreditCardClose" runat="server" OnClick="btnCreditCardClose_Click" meta:resourcekey="ButtonCreditCardClose" />
        </div>

        <p>
            <asp:Label ID="lblNoCards" meta:resourcekey="lblNoCards" runat="server"></asp:Label>
        </p>

        <asp:GridView ID="gvCards" runat="server" CssClass="creditCards"
            AutoGenerateColumns="False"
            OnSelectedIndexChanging="gvCards_SelectedIndexChanging"
            ShowHeaderWhenEmpty="True">
            <Columns>
                <asp:BoundField DataField="cardnumber" HeaderText="<%$ Resources:, cardNumber %>" />
                <asp:BoundField DataField="cardType" HeaderText="<%$ Resources:, cardType %>" />
                <asp:BoundField DataField="verificationCode" HeaderText="<%$ Resources:, verificationCode %>" />
                <asp:BoundField DataField="expeditionDate" HeaderText="<%$ Resources:, expeditionDate %>" />
                <asp:BoundField DataField="DefaultCard" Visible="true" />
                <asp:TemplateField HeaderText="<%$ Resources:, DefaultCard %>">
                    <ItemTemplate>
                        <asp:CheckBox ID="changeDefaultCard" AutoPostBack="true" OnDataBinding="changeDefaultCard_DataBinding" runat="server" OnCheckedChanged="changeDefaultCard_CheckedChanged" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />

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
                    <asp:Label ID="lblCreditCardNumberError" runat="server" ForeColor="Red" Style="position: relative"
                        Visible="False" meta:resourcekey="lblCreditCardNumberErrorResource1"></asp:Label>
                    <asp:Label ID="lblCreditCardNumberFormat" runat="server" ForeColor="Red" Style="position: relative"
                        Visible="False" meta:resourcekey="lblCardNumberFormat"></asp:Label>
                     <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtCreditCardNumber" ID="RegularExpressionValidator1" ValidationExpression="^[\s\S]{16,}$" runat="server" ErrorMessage="<%$ resources:invallidNumber %>"></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtCreditCardNumber" ID="RegularExpressionValidator2" ValidationExpression="^[\s\S]{0,16}$" runat="server" ErrorMessage="<%$ resources:invallidNumber %>"></asp:RegularExpressionValidator>
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
                        <asp:Label ID="lblCVError" runat="server" ForeColor="Red" Style="position: relative"
                            Visible="False" meta:resourcekey="lblCVError"></asp:Label>
                        <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtCV" ID="RegularExpressionValidator3" ValidationExpression="^[\s\S]{3,}$" runat="server" ErrorMessage="<%$ resources:invalidCV %>"></asp:RegularExpressionValidator>
                        <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtCV" ID="RegularExpressionValidator4" ValidationExpression="^[\s\S]{0,3}$" runat="server" ErrorMessage="<%$ resources:invalidCV %>"></asp:RegularExpressionValidator>
                    </span>
            </div>
        </div>
        <br />

        <div class="button">
            <span>
                <asp:Label ID="lclProductList" Font-Bold="true" Font-Size="Medium" runat="server" meta:resourcekey="lclProductList" />
            </span>
        </div>

        <br />

        <p>
            <asp:Label ID="lblShoppingCartEmpty" meta:resourcekey="lblShoppingCartEmpty" runat="server"></asp:Label>
        </p>

        <asp:GridView ID="gvShoppingCart" runat="server" CssClass="shoppingCart"
            AutoGenerateColumns="False"
            OnSelectedIndexChanging="gvShoppingCart_SelectedIndexChanging"
            OnRowDataBound="gvShoppingCart_RowDataBound"
            ShowHeaderWhenEmpty="True" meta:resourcekey="gvShoppingCartResource2">
            <Columns>
                <asp:BoundField DataField="productId" HeaderText="<%$ Resources:, productId %>" Visible="true" meta:resourcekey="BoundFieldResource17" />
                <asp:BoundField DataField="productName" HeaderText="<%$ Resources:, productName %>" Visible="true" meta:resourcekey="BoundFieldResource17" />
                <asp:BoundField DataField="price" HeaderText="<%$ Resources:, price %>" meta:resourcekey="BoundFieldResource15" />
                <asp:BoundField DataField="quantity" HeaderText="<%$ Resources:, quantity %>" Visible="true" meta:resourcekey="BoundFieldResource17" />
                <asp:BoundField DataField="totalPrice" HeaderText="<%$ Resources:, totalPrice %>" Visible="true" meta:resourcekey="BoundFieldResource17" />

                <asp:TemplateField HeaderText="<%$ Resources:, forGift %>">
                    <ItemTemplate>
                        <asp:CheckBox ID="cbForGift" AutoPostBack="true" runat="server" OnDataBinding="cbForGift_DataBinding" OnCheckedChanged="cbForGift_CheckedChanged" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:, quantity %>" meta:resourcekey="TemplateFieldResource2">
                    <ItemTemplate>
                        <asp:DropDownList ID="quantityList" AutoPostBack="True" runat="server" OnSelectedIndexChanged="quantityList_SelectedIndexChanged" meta:resourcekey="quantityListResource2">
                            <asp:ListItem Value="1" meta:resourcekey="ListItemResource8">1</asp:ListItem>
                            <asp:ListItem Value="2" meta:resourcekey="ListItemResource9">2</asp:ListItem>
                            <asp:ListItem Value="3" meta:resourcekey="ListItemResource10">3</asp:ListItem>
                            <asp:ListItem Value="4" meta:resourcekey="ListItemResource11">4</asp:ListItem>
                            <asp:ListItem Value="5" meta:resourcekey="ListItemResource12">5</asp:ListItem>
                            <asp:ListItem Value="6" meta:resourcekey="ListItemResource13">6</asp:ListItem>
                            <asp:ListItem Value="7" meta:resourcekey="ListItemResource14">7</asp:ListItem>
                            <asp:ListItem Value="8" meta:resourcekey="ListItemResource15">8</asp:ListItem>
                            <asp:ListItem Value="9" meta:resourcekey="ListItemResource16">9</asp:ListItem>
                            <asp:ListItem Value="10" meta:resourcekey="ListItemResource17">10</asp:ListItem>
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowSelectButton="True" SelectText="deleteProduct" meta:resourcekey="CommandFieldResource3" />
            </Columns>
        </asp:GridView>

        <br />
        <br />
        <br />
        <br />
        <asp:Label ID="lblNoStock" runat="server" ForeColor="Red" Style="position: relative"
            Visible="False" meta:resourcekey="lblNoStock"></asp:Label>

        <asp:Label ID="lblRepeted" runat="server" ForeColor="Red" Style="position: relative"
            Visible="False" meta:resourcekey="lblRepeted"></asp:Label>

        <asp:Label ID="lblNoCard" runat="server" ForeColor="Red" Style="position: relative"
            Visible="False" meta:resourcekey="lblNoCard"></asp:Label>

        <div class="field">
            <span class="label">
                <asp:Localize ID="lclDescrtiption" runat="server" meta:resourcekey="lclDescrtiption" /></span><span
                    class="entry">
                    <asp:TextBox ID="txtDescription" runat="server" Width="100px" Columns="16" meta:resourcekey="txtDescription"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtDescription" Type="String"
                        Operator="DataTypeCheck" meta:resourcekey="cvDescription" />
                    <asp:Label ID="lblErrorDescrtiption" runat="server" ForeColor="Red" Style="position: relative"
                        Visible="False" meta:resourcekey="lblErrorDescrtiption"></asp:Label>
                </span>
        </div>

        <br />

        <div class="button">
            <span>
                <asp:Label ID="lclPrize" Font-Bold="true" runat="server" meta:resourcekey="lclPrize" /></span>
            <asp:TextBox ID="txtPrizeTotal" ReadOnly="True" runat="server" meta:resourcekey="txtPrizeTotalResource2"></asp:TextBox>
        </div>

        <br />
        <div class="button">
            <asp:Button ID="btnPay" runat="server" OnClick="btnToPay_Click" meta:resourcekey="btnPay" />
        </div>
    </form>
    <br />
</asp:Content>