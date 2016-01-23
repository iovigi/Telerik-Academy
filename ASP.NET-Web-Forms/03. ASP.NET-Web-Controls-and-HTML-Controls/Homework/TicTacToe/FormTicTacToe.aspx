<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormTicTacToe.aspx.cs" Inherits="TicTacToe.FormTicTacToe" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form" runat="server">
        <asp:Button Text=" " width="50px" height="50px" OnClick="topLeft_Click" runat="server" ID="topLeft" />
        <asp:Button Text=" " width="50px" height="50px" OnClick="topMiddle_Click" runat="server" ID="topMiddle" />
        <asp:Button Text=" " width="50px" height="50px" OnClick="topRight_Click" runat="server" ID="topRight" />
        <br />                                    
        <asp:Button Text=" " width="50px" height="50px" OnClick="middleLeft_Click" runat="server" ID="middleLeft" />
        <asp:Button Text=" " width="50px" height="50px" OnClick="middleMiddle_Click" runat="server" ID="middleMiddle" />
        <asp:Button Text=" " width="50px" height="50px" OnClick="middleRight_Click" runat="server" ID="middleRight" />
        <br />                                    
        <asp:Button Text=" " width="50px" height="50px" OnClick="bottomLeft_Click" runat="server" ID="bottomLeft" />
        <asp:Button Text=" " width="50px" height="50px" OnClick="bottomMiddle_Click" runat="server" ID="bottomMiddle" />
        <asp:Button Text=" " width="50px" height="50px" OnClick="bottomRight_Click" runat="server" ID="bottomRight" />

        <br />
        <asp:Label ID="result" runat="server" Text=""/>
    </form>
</body>
</html>
