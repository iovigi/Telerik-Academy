<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormDemoAplication._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>
                <asp:TextBox ID="TextBoxNumberX" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxNumberY" runat="server"></asp:TextBox>
                <asp:Button ID="ButtonSum" runat="server" OnClick="ButtonSum_Click" Text="Sum" />
                <asp:TextBox ID="TextBoxResult" runat="server"></asp:TextBox>
            </h2>
            <p>
                &nbsp;</p>
        </div>
        <div class="col-md-4">
        </div>
        <div class="col-md-4">
        </div>
    </div>

</asp:Content>
