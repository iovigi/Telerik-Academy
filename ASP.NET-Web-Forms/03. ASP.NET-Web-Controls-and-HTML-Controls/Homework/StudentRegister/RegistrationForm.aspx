<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationForm.aspx.cs" Inherits="StudentRegister.RegistrationForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label Text="First Name" />
        <asp:TextBox ID="firstName" runat="server" />
        <br />
        <asp:Label Text="Last Name" />
        <asp:TextBox ID="lastName" runat="server" />
        <br />
        <asp:Label Text="Faculty number" />
        <asp:TextBox ID="facultyNumber" runat="server" />
        <br />
        <asp:DropDownList ID="listUniversities" runat="server">
            <asp:ListItem Value="TU-Sofia">TU-Sofia</asp:ListItem>
            <asp:ListItem Value="TU-Gabrovo">TU-Gabrovo</asp:ListItem>
            <asp:ListItem Value="FMI">FMI</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:DropDownList ID="listOfSpeciality" runat="server">
            <asp:ListItem Value="Computer Engineering">Computer Engineering</asp:ListItem>
            <asp:ListItem Value="Satellite Communication">Satellite Communication</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:ListBox SelectionMode="Multiple" ID="courses" runat="server">
            <asp:ListItem Value="Programming">Programming</asp:ListItem>
            <asp:ListItem Value="Mathematic">Mathematic</asp:ListItem>
            <asp:ListItem Value="Informatic">Informatic</asp:ListItem>
        </asp:ListBox>
        <br />
        <asp:Button ID="ButtonSubmit" runat="server" Text="Register" OnClick="ButtonSubmit_Click" />
    </form>

    <asp:Panel runat="server" ID="registerContainer" />
</body>
</html>
