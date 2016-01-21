<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebSayHello._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <asp:Button ID="ButtonSay" runat="server" Height="34px" OnClick="ButtonSay_Click" Text="Send" />
        <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
        <asp:Label ID="LabelSay" runat="server" Text="Hello "></asp:Label>
    </div>

    <div class="row">
    </div>

</asp:Content>
