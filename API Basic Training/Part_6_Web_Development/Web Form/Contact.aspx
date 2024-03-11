<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Web_Form.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
  <h1>Hello - <%= (Session["UserName"] != null) ? Session["UserName"].ToString() : "User" %></h1>

</asp:Content>
