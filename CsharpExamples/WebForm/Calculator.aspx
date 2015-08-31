<%@ Page Language="C#"  MasterPageFile="~/app.Master" AutoEventWireup="true" CodeBehind="Calculator.aspx.cs" Inherits="WebForm.Calculator" %>

<%--<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>--%>
   
        <asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      
                <div>
                    <div>
                        <asp:Label ID="fiNumberLabel" runat="server">First Number</asp:Label>
                        <asp:TextBox ID="firstNumber" runat="server" ></asp:TextBox>
                      </div>
                     <div>
                        <asp:Label ID="seNumberLabel" runat="server">Second Number</asp:Label>
                        <asp:TextBox ID="lastNumber" runat="server"></asp:TextBox>
                    </div>
                    <br />
                    <div>
                        <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                        <asp:Button ID="btnSub" runat="server" Text="Substract" OnClick="btnSub_Click" />
                        <asp:Button ID="btnMul" runat="server" Text="Multiple" OnClick="btnMul_Click" />
                        <asp:Button ID="btnDev" runat="server" Text="Divide" OnClick="btnDev_Click" />
                    </div>
                    <br />
                    <div>
                        <asp:Label ID="result" runat="server"></asp:Label>
                    </div>
       
                </div>
        </asp:Content>
  
<%--</body>
</html>--%>
