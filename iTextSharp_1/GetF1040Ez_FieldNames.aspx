<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetF1040Ez_FieldNames.aspx.cs" Inherits="iTextSharp_1.GetF1040Ez_FieldNames" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
      <h1>Reading F1040ez Field Names</h1>
      <asp:ListBox ID="taxYearsListBox" runat="server" AutoPostBack="True" OnSelectedIndexChanged="taxYearsListBox_SelectedIndexChanged">
        <asp:ListItem>2000</asp:ListItem>
        <asp:ListItem>2001</asp:ListItem>
        <asp:ListItem>2002</asp:ListItem>
        <asp:ListItem>2003</asp:ListItem>
        <asp:ListItem>2004</asp:ListItem>
        <asp:ListItem>2005</asp:ListItem>
        <asp:ListItem>2006</asp:ListItem>
        <asp:ListItem>2007</asp:ListItem>
        <asp:ListItem>2008</asp:ListItem>
        <asp:ListItem>2009</asp:ListItem>
        <asp:ListItem>2010</asp:ListItem>
        <asp:ListItem>2011</asp:ListItem>
        <asp:ListItem>2012</asp:ListItem>
        <asp:ListItem>2013</asp:ListItem>
        <asp:ListItem>2014</asp:ListItem>
        <asp:ListItem>2015</asp:ListItem>
        <asp:ListItem>2016</asp:ListItem>
      </asp:ListBox>
      <br />
      <br />
      <asp:Label ID="lblPdfName" runat="server"></asp:Label>
      <br />
      <br />
      <asp:Label ID="lblPdfFields" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
