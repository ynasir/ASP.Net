<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Mortgage_Calculator.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Calculate Mortgage Monthly Payment</h2>
    <div>
        <asp:Label ID="Label1" runat="server" Text="Please enter the principal amount"></asp:Label>
        <asp:TextBox ID="txt_Principal" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txt_Principal" runat="server" ErrorMessage="Please enter a value for pricnipal"></asp:RequiredFieldValidator>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <nav style="margin-top: 20px" >
                <asp:Label runat="server" Text="Please enter the loan duration in years"></asp:Label>
                <div style="margin-top: 10px">
                    <asp:RadioButton ID="rbtn15yrs" runat="server" GroupName="Years" AutoPostBack="true" OnCheckedChanged="OtherNotChecked"/>
                    <asp:Label ID="Label2" runat="server" Text="15 years"></asp:Label>
                </div>
                <div style="margin-top: 10px">
                    <asp:RadioButton ID="rbtn30yrs" runat="server" GroupName="Years" AutoPostBack="true" OnCheckedChanged="OtherNotChecked"/>
                    <asp:Label ID="Label3" runat="server" Text="30 years"></asp:Label>
                </div>
                <div style="margin-top: 10px">
                    <asp:RadioButton ID="rbtnother" runat="server" GroupName="Years" AutoPostBack="true" OnCheckedChanged="OtherRadioChecked"/>
                    <asp:Label ID="Label5" runat="server" Text="Other"></asp:Label>
                    <asp:TextBox ID="txt_other" runat="server"></asp:TextBox>
                </div>
            </nav>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div style="margin: 20px 0px 20px 0px">
        <asp:Label ID="Label4" runat="server" Text="Please select the interest rate"></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
    </div>
    <asp:Button ID="btn_calculate" runat="server" Text="Calculate Monthly Payment" OnClick="btn_calculate_Click" />
    <div style="margin-top: 20px">
    <asp:Label ID="Result" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
