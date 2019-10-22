<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="Mortgage_Calculator.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin:20px 0px 0px 30px">
            <asp:Button ID="btn_clear" runat="server" Text="Clear Mortgage Data" OnClick="btn_clear_Click" />
    </div>
</asp:Content>
