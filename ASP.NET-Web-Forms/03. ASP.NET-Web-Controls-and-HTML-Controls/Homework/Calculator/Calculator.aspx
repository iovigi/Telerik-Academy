<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calculator.aspx.cs" Inherits="Calculator.Calculator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        #form1 {
            border: 1px solid #000000;
            width: 304px;
            height: 314px;
        }

        .calculatorItemWrapper {
            border: 1px solid #000000;
            width: 300px;
            height: 50px;
            padding: 2px;
        }

        .calulatorItem {
            border: 1px solid #000000;
            width: 100px;
            height: 44px;
            margin: 2px 100px;
        }

        #buttonsWrapper {
            width: 300px;
            height: 200px;
            padding: 1px;
            margin: 0px;
        }

        .buttons {
            width: 68px;
            height: 46px;
            padding: 0;
            margin: 2px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="inputWrapper" class="calculatorItemWrapper">
            <asp:TextBox runat="server" CssClass="calulatorItem" ID="input" />
        </div>
        <div id="buttonsWrapper">
            <asp:Button runat="server" OnClick="DigitPress" ID="buttonOne" Text="1" CssClass="buttons" />
            <asp:Button runat="server" OnClick="DigitPress" ID="buttonTwo" Text="2" CssClass="buttons" />
            <asp:Button runat="server" OnClick="DigitPress" ID="buttonThree" Text="3" CssClass="buttons" />
            <asp:Button runat="server" OnClick="OperationPress" ID="buttonPlus" Text="+" CssClass="buttons" />
            </br>      
            <asp:Button runat="server" OnClick="DigitPress" ID="buttonFour" Text="4" CssClass="buttons" />
            <asp:Button runat="server" OnClick="DigitPress" ID="buttonFive" Text="5" CssClass="buttons" />
            <asp:Button runat="server" OnClick="DigitPress" ID="buttonSix" Text="6" CssClass="buttons" />
            <asp:Button runat="server" OnClick="OperationPress" ID="buttonMinus" Text="-" CssClass="buttons" />
            </br>      
            <asp:Button runat="server" OnClick="DigitPress" ID="buttonSeven" Text="7" CssClass="buttons" />
            <asp:Button runat="server" OnClick="DigitPress" ID="buttonEight" Text="8" CssClass="buttons" />
            <asp:Button runat="server" OnClick="DigitPress" ID="buttonNine" Text="9" CssClass="buttons" />
            <asp:Button runat="server" OnClick="OperationPress" ID="buttonMultiplier" Text="X" CssClass="buttons" />
            </br>       
            <asp:Button runat="server" OnClick="ClearClick" ID="buttonClear" Text="Clear" CssClass="buttons" />
            <asp:Button runat="server" OnClick="DigitPress" ID="buttonZero" Text="0" CssClass="buttons" />
            <asp:Button runat="server" OnClick="OperationPress" ID="buttonDivider" Text="/" CssClass="buttons" />
            <asp:Button runat="server" OnClick="OperationPress" ID="buttonSqrt" Text="sqrt" CssClass="buttons" />
        </div>
        <div id="inputResult" class="calculatorItemWrapper">
            <asp:Button runat="server" OnClick="result_Click" CssClass="calulatorItem" Text="=" ID="result" />
        </div>
    </form>
</body>
</html>
