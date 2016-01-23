<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RandomNumberInRangeWithWebControl.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TextBox ID="firstRange" runat="server" />
        <asp:TextBox ID="secondRange" runat="server" />

        <asp:Button ID="GenerateRandomNumber" runat="server" OnClick="GenerateRandomNumber_Click" Text="Submit" />
        <br />
        <asp:Label ID="randomNumberContainer" runat="server" />
    </form>
</body>
</html>
