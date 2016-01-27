<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MobileCatalog.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mobile Catalog</title>
</head>
<body>
     <form id="formMain" runat="server">
        Producer:
        <asp:DropDownList ID="DropDownListProducers" runat="server"
            AutoPostBack="true"
            DataTextField="Name"
            OnSelectedIndexChanged="DropDownListProducers_SelectedIndexChanged">
        </asp:DropDownList>
         <br />
        Model:
        <asp:DropDownList ID="DropDownListModels" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        Extras:
        <asp:CheckBoxList ID="CheckBoxListExtras" runat="server" DataTextField="Name">
        </asp:CheckBoxList>
        <br />
        Engine:
        <asp:RadioButtonList ID="RadioButtonListEngine" runat="server">
        </asp:RadioButtonList>
        <br />
        <asp:Button ID="Search" runat="server" Text="Search" OnClick="Search_Click" />
         <br />
        <asp:Literal ID="Result" runat="server"></asp:Literal>
    </form>
    <br />
    <br />
</body>
</html>
