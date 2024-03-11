<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web_Form._Default" %>

<asp:Content ID="DefaultCss" ContentPlaceHolderID="Stylesheets" runat="server">
    <link rel="stylesheet" type="text/css" href="Content/styles.css" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <table>
            <tr>
                <td>User Name</td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged" Width="100%"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter User Name" ForeColor="#CC0000" SetFocusOnError="True" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Password</td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" OnTextChanged="TextBox2_TextChanged" Width="100%" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter Password" ForeColor="#CC0000" SetFocusOnError="True" ControlToValidate="TextBox2"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Login" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
