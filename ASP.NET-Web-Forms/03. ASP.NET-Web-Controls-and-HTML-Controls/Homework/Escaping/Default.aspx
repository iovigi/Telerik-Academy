<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Escaping.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TextBox ID="text" runat="server" />
        <asp:Button ID="GetText" runat="server" OnClick="GetText_Click" Text="Submit" />
        <br />
        <asp:Label ID="escapedText" runat="server" Mode="Encode" />
    </form>
</body>
</html>
