<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="webStore.login" %>

<asp:Content ID="headCnt" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 650px;
            height: 50px;
        }
        .auto-style4 {
            width: 231px;
            text-align: left;
            height: 50px;
        }
        .auto-style5 {
            text-align: right;
            width: 650px;
            height: 49px;
            font-size: larger;
        }
        .auto-style6 {
            width: 231px;
            height: 49px;
        }
        .auto-style7 {
            height: 49px;
        }
        .auto-style9 {
        width: 231px;
        height: 50px;
    }
        .auto-style10 {
            height: 50px;
        }
        .auto-style11 {
            font-size: larger;
        }
        .auto-style12 {
            text-align: right;
            width: 650px;
            height: 50px;
            font-size: larger;
        }
    .auto-style13 {
        width: 650px;
        height: 50px;
        text-align: left;
    }
    </style>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">

    <form id="form1" runat="server">

    <br />
       <h1 class="text-center">Login</h1>
        <p class="text-center">&nbsp;</p>
        <table class="nav-justified">
            <tr>
                <td class="auto-style5">User Name:&nbsp; </td>
                <td class="auto-style6">
                    <asp:TextBox ID="TextBoxUserName" runat="server" CssClass="auto-style11" Width="220px"></asp:TextBox>
                </td>
                <td class="auto-style7">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxUserName" ErrorMessage="Please enter User Name" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    <asp:Label ID="LabelUser" runat="server" ForeColor="Red" Text="Invalid User Name" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style12">Password:&nbsp; </td>
                <td class="auto-style9">
                    <asp:TextBox ID="TextBoxPassword" runat="server" CssClass="auto-style11" TextMode="Password" Width="220px"></asp:TextBox>
                </td>
                <td class="auto-style10">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxPassword" ErrorMessage="Please enter Password" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    <asp:Label ID="LabelPass" runat="server" ForeColor="Red" Text="Incorrect password" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2"></td>
                <td class="auto-style9">
                    <asp:Button ID="ButtonLogin" runat="server" Text="Login" class="btn btn-default" OnClick="ButtonLogin_Click" Width="120px"/>
                   
                </td>
                <td class="auto-style10"></td>
            </tr>
            <tr>
                <td class="auto-style13"></td>
                <td class="auto-style4">
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/register.aspx">Create new acount here</asp:HyperLink>
                </td>
                <td class="auto-style10"></td>
            </tr>
        </table>
    </form>
    

</asp:Content>
