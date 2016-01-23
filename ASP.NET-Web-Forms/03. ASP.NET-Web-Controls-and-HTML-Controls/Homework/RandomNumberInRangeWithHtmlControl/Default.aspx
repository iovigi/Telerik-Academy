<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs"
    Inherits="RandomNumberInRangeWithHtmlControl._Default" %>

<!DOCTYPE html>
<html>
    <head>
        <title>
            Default random number
        </title>
    </head>
    <body>
        <form id="formMain" runat="server">
            <input name="firstRange" id="firstRange"  runat="server" placeholder="first boundary"/>
            <input name="secondRange" id="secondRange"  runat="server" placeholder="second boundary"/>
            <input type="button" runat="server" id="getRandomNumber" value="Generate Number" onserverclick="button_Click"/>
            <br />
            <div runat="server" id="randomNumberContainer"></div>
        </form>
    </body>
</html>
