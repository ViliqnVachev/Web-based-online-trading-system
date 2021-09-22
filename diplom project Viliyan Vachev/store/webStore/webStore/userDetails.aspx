<%@ Page Language="C#" MasterPageFile="~/AdminMain.Master" AutoEventWireup="true" CodeBehind="userDetails.aspx.cs" Inherits="webStore.userDetails" %>

<asp:Content ID="headCnt" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            font-size: xx-large;
            width: 430px;
            height: 79px;
        }

        .auto-style2 {
            width: 651px;
        }

        .auto-style3 {
            width: 430px;
        }

        .auto-style10 {
            width: 651px;
            height: 50px;
            text-align: right;
            font-size: larger;
        }

        .auto-style12 {
            height: 50px;
        }

        .auto-style14 {
            font-size: larger;
        }

        .auto-style16 {
            height: 50px;
            text-align: left;
        }

        .auto-style18 {
            width: 430px;
            height: 50px;
        }

        .auto-style19 {
            width: 430px;
            height: 50px;
            text-align: left;
        }

        .auto-style21 {
            width: 651px;
            height: 79px;
        }

        .auto-style22 {
            height: 79px;
        }

        .auto-style24 {
            width: 430px;
            height: 78px;
            text-align: left;
        }

        .auto-style29 {
            width: 651px;
            height: 78px;
            text-align: left;
        }

        .auto-style30 {
            height: 78px;
            text-align: left;
        }
    </style>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">
    <form id="form1" runat="server">
        <br />
        <table class="nav-justified">
            <tr>
                <td class="auto-style21">&nbsp;</td>
                <td class="auto-style1">&nbsp;User Details</td>
                <td class="auto-style22"></td>
            </tr>
            <tr>
                <td class="auto-style10">User Name:</td>
                <td class="auto-style18">&nbsp;
                    <asp:TextBox ID="UserNameTextBox" runat="server" CssClass="auto-style14" Enabled="False" Height="30px" Width="333px"></asp:TextBox>
                </td>
                <td class="auto-style12"></td>
            </tr>
            <tr>
                <td class="auto-style10">Password:</td>
                <td class="auto-style19">&nbsp;
                    <asp:TextBox ID="PasswordTextBox" runat="server" CssClass="auto-style14" Enabled="False" Height="30px" Width="333px" TextMode="Password"></asp:TextBox>
                </td>
                <td class="auto-style16"></td>
            </tr>
            <tr>
                <td class="auto-style10">First Name:</td>
                <td class="auto-style19">&nbsp;
                    <asp:TextBox ID="FirstNameTextBox" runat="server" CssClass="auto-style14" Enabled="False" Height="30px" Width="333px"></asp:TextBox>
                    &nbsp;
                </td>
                <td class="auto-style12"></td>
            </tr>
            <tr>
                <td class="auto-style10">Last Name:</td>
                <td class="auto-style19">&nbsp;
                     <asp:TextBox ID="LastNameTextBox" runat="server" CssClass="auto-style14" Enabled="False" Height="30px" Width="333px"></asp:TextBox>
                </td>
                <td class="auto-style16">

                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style10">Address:</td>
                <td class="auto-style19">&nbsp;
                    <asp:TextBox ID="AddressTextBox" runat="server" CssClass="auto-style14" Enabled="False" Height="30px" Width="333px"></asp:TextBox>
                </td>
                <td class="auto-style12"></td>
            </tr>
            <tr>
                <td class="auto-style10">
                Telephone number:
            <td class="auto-style19">&nbsp;
                <asp:TextBox ID="TelephoneTextBox" runat="server" CssClass="auto-style14" Enabled="False" Height="30px" Width="333px"></asp:TextBox>
            </td>
                <td class="auto-style12"></td>
            </tr>
            <tr>
                <td class="auto-style10">
                Email:
            <td class="auto-style19">&nbsp;
                <asp:TextBox ID="EmailTextBox" runat="server" CssClass="auto-style14" Enabled="False" Height="30px" Width="333px"></asp:TextBox></td>
                <td class="auto-style12"></td>
            </tr>
            <tr>
                <td class="auto-style29"></td>
                <td class="auto-style24">&nbsp;&nbsp;&nbsp;
                <asp:Button ID="ButtonEdit" runat="server" Text="Edit user" class="btn btn-primary" OnClick="ButtonEdit_Click" />&nbsp;
                <asp:Button ID="ButtonCencel" runat="server" Text="Cencel" class="btn btn-danger" OnClick="ButtonCencel_Click" />
                </td>
                <td class="auto-style30"></td>
            </tr>
            <tr>
                <td class="auto-style10">&nbsp;</td>
                <td class="auto-style19">&nbsp;
                </td>
                <td class="auto-style12"></td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>

    </form>

</asp:Content>
