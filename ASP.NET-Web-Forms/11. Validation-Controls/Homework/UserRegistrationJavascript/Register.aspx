<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="UserRegister.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="PanelLogon" runat="server"
                GroupingText="Logon Info">
                <asp:Label Text="user name:" runat="server" ID="LabelUserName"
                    AssociatedControlID="TextBoxUserName" />
                <asp:TextBox ID="TextBoxUserName" runat="server"
                    ValidationGroup="ValidationLogon"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserName" runat="server"
                    ControlToValidate="TextBoxUserName"
                    ValidationGroup="ValidationLogon" EnableClientScript="False"
                    ErrorMessage="Please enter username">Required field!</asp:RequiredFieldValidator>
                <br />
                <asp:Label ID="LabelPassword" runat="server"
                    AssociatedControlID="TextBoxPassword" Text="Password:" />
                <asp:TextBox ID="TextBoxPassword" runat="server"
                    ValidationGroup="ValidationLogon"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server"
                    ControlToValidate="TextBoxPassword"
                    ValidationGroup="ValidationLogon" EnableClientScript="False"
                    ErrorMessage="Please enter Password">Required field!</asp:RequiredFieldValidator>
                <br />
                <asp:Label ID="LabelConfirmPassword" runat="server"
                    AssociatedControlID="TextBoxConfirmPassword" Text="Confirm Password:" />
                <asp:TextBox ID="TextBoxConfirmPassword" runat="server"
                    ValidationGroup="ValidationLogon"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorConfirmPassword" runat="server"
                    ControlToValidate="TextBoxConfirmPassword"
                    ValidationGroup="ValidationLogon" EnableClientScript="False"
                    ErrorMessage="Please enter Confirm Password">Required field!</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidatorPassword" runat="server"
                    ControlToCompare="TextBoxPassword"
                    ControlToValidate="TextBoxConfirmPassword" Display="Dynamic"
                    ErrorMessage="Password doesn't match!" ForeColor="Red" EnableClientScript="False"></asp:CompareValidator>
                <br />
            </asp:Panel>

            <asp:Panel ID="PanelPersonal" runat="server"
                GroupingText="Personal Info">
                <asp:Label Text="first name:" runat="server" ID="LabelFirstName"
                    AssociatedControlID="TextBoxFirstName" />
                <asp:TextBox ID="TextBoxFirstName" runat="server"
                    ValidationGroup="ValidationPersonalInfo"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorFirstName" runat="server"
                    ControlToValidate="TextBoxFirstName"
                    ValidationGroup="ValidationPersonalInfo" EnableClientScript="False"
                    ErrorMessage="Please enter firstname">Required field!</asp:RequiredFieldValidator>
                <br />
                <asp:Label ID="LabelLastName" runat="server"
                    AssociatedControlID="TextBoxLastName" Text="Last Name:" />
                <asp:TextBox ID="TextBoxLastName" runat="server"
                    ValidationGroup="ValidationPersonalInfo"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorLastName" runat="server"
                    ControlToValidate="TextBoxLastName"
                    ValidationGroup="ValidationPersonalInfo" EnableClientScript="False"
                    ErrorMessage="Please enter lastname">Required field!</asp:RequiredFieldValidator>
                <br />
                <asp:Label ID="LabelAge" runat="server"
                    AssociatedControlID="TextBoxAge" Text="Age:" />
                <asp:TextBox ID="TextBoxAge" runat="server"
                    ValidationGroup="ValidationPersonalInfo"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorAge" runat="server"
                    ControlToValidate="TextBoxConfirmPassword"
                    ValidationGroup="ValidationPersonalInfo" EnableClientScript="False"
                    ErrorMessage="Please enter age">Required field!</asp:RequiredFieldValidator>
                <asp:RangeValidator ID="Range1"
                    ControlToValidate="TextBoxAge"
                    MinimumValue="18"
                    MaximumValue="81"
                    Type="Integer"
                    EnableClientScript="false"
                    ValidationGroup="ValidationPersonalInfo"
                    Text="The value must be from 18 to 81!"
                    runat="server" />
                <br />
                <asp:Label ID="LabelSex" runat="server"
                    AssociatedControlID="RadioButtonSex" Text="Sex:" />
                <br />
                <asp:RadioButtonList ID="RadioButtonSex" OnSelectedIndexChanged="Index_Changed" AutoPostBack="true" runat="server">
                    <asp:ListItem Value="Male">Male</asp:ListItem>
                    <asp:ListItem Value="Female">Female</asp:ListItem>
                </asp:RadioButtonList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorSex" runat="server"
                    ControlToValidate="RadioButtonSex"
                    ValidationGroup="ValidationPersonalInfo" EnableClientScript="False"
                    ErrorMessage="Please enter sex">Required field!</asp:RequiredFieldValidator>
                <br />
                <asp:CheckBoxList ID="CheckBoxListMaleCars" Visible="false" runat="server">
                    <asp:ListItem>BMW</asp:ListItem>
                    <asp:ListItem>Audi</asp:ListItem>
                    <asp:ListItem>VW</asp:ListItem>
                </asp:CheckBoxList>
                <asp:DropDownList ID="CheckBoxListFemaleCoffee" Visible="false" runat="server">
                    <asp:ListItem>Lavazza</asp:ListItem>
                     <asp:ListItem>New Brazil</asp:ListItem>
                    <asp:ListItem>3v1</asp:ListItem>
                </asp:DropDownList>
            </asp:Panel>

            <asp:Panel ID="PanelAddress" runat="server"
                GroupingText="Address  Info">
                <asp:Label Text="Email:" runat="server" ID="Label1"
                    AssociatedControlID="TextBoxEmail" />
                <asp:TextBox ID="TextBoxEmail" runat="server"
                    ValidationGroup="ValidationAddress"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorMail" runat="server"
                    ControlToValidate="TextBoxEmail"
                    ValidationGroup="ValidationAddress" EnableClientScript="False"
                    ErrorMessage="Please enter email">Required field!</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail"
                    ControlToValidate="TextBoxEmail"
                    ValidationGroup="ValidationAddress"
                    ValidationExpression="[a-zA-Z][a-zA-Z0-9\-\.]*[a-zA-Z]@[a-zA-Z][a-zA-Z0-9\-\.]+[a-zA-Z]+\.[a-zA-Z]{2,4}"
                    Display="Static"
                    ErrorMessage="Email isn't valid"
                    EnableClientScript="False"
                    runat="server" />
                <br />
                <asp:Label ID="LabelLocalAddress" runat="server"
                    AssociatedControlID="TextLocalAddress" Text="Local Address:" />
                <asp:TextBox ID="TextLocalAddress" runat="server"
                    ValidationGroup="ValidationAddress"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorLocalAddress" runat="server"
                    ControlToValidate="TextLocalAddress"
                    EnableClientScript="False"
                    ValidationGroup="ValidationAddress"
                    ErrorMessage="Please enter address">Required field!</asp:RequiredFieldValidator>
                <br />
                <asp:Label ID="LabelPhone" runat="server"
                    AssociatedControlID="TextBoxPhone" Text="Phone:" />
                <asp:TextBox ID="TextBoxPhone" runat="server"
                    ValidationGroup="ValidationAddress"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorPhone" runat="server"
                    ControlToValidate="TextBoxPhone"
                    EnableClientScript="False"
                    ValidationGroup="TextBoxPhone"
                    ErrorMessage="Please enter phone">Required field!</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorPhone"
                    ControlToValidate="TextBoxPhone"
                    ValidationGroup="ValidationAddress"
                    ValidationExpression="^([0-9\(\)\/\+ \-]*)$"
                    Display="Static"
                    ErrorMessage="Phone isn't valid"
                    EnableClientScript="False"
                    runat="server" />
                <br />
            </asp:Panel>

            <br />
            <asp:Label ID="LabelAccept" runat="server"
                AssociatedControlID="CheckBoxAccept" Text="I accept:" />
            <asp:CheckBox ID="CheckBoxAccept" runat="server" />
           <asp:CustomValidator ID="CustomValidatorAccept" runat="server" 
            ErrorMessage="Please accept the terms..." 
               EnableClientScript="False"
            onservervalidate="CustomValidatorAccept_ServerValidate">Please accept the terms...</asp:CustomValidator>

            <asp:Button ID="ButtonSubmit" runat="server" Text="Submit"
                OnClick="ButtonSubmit_Click" />

            <asp:ValidationSummary
                ID="valSum"
                DisplayMode="BulletList"
                runat="server"
                HeaderText="You must enter a value in the following fields:"
                Font-Names="verdana"
                Font-Size="12" />
        </div>
    </form>
</body>
</html>
