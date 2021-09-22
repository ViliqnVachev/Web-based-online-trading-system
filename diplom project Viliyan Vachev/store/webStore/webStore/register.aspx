<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="webStore.register" %>

<asp:Content ID="headCnt" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 650px;
            text-align: right;
        }
        .auto-style6 {
            width: 650px;
            text-align: right;
            height: 50px;
            font-size: larger;
        }
        .auto-style7 {
            height: 50px;
        }
        .auto-style8 {
            font-size: larger;
        }
        .auto-style9 {
        height: 50px;
        width: 283px;
        text-align: center;
    }
        .auto-style10 {
            width: 283px;
        text-align: center;
    }
        </style>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">
   
    <form id="form1" runat="server">
        <fieldset><legend class="center-block">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span class="auto-style8">&nbsp;&nbsp; Registration</span><br />
            </legend>
   
    <table class="nav-justified">
        <tr>
            <td class="auto-style6">User Name:</td>
            <td class="auto-style9">
                <asp:TextBox ID="TextBoxUserName" runat="server" CssClass="auto-style8" Width="220px" EnableTheming="True"></asp:TextBox>
            </td>
            <td class="auto-style7">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxUserName" ErrorMessage="User Name is Required" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style6">Password:</td>
            <td class="auto-style9">
                <asp:TextBox ID="TextBoxPassword" runat="server" CssClass="auto-style8" TextMode="Password" Width="220px">******</asp:TextBox>
            </td>
            <td class="auto-style7">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxPassword" ErrorMessage="Password is Required" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style6">Confirm Password:</td>
            <td class="auto-style9">
                <asp:TextBox ID="TextBoxConfirmPassword" runat="server" CssClass="auto-style8" TextMode="Password" Width="220px">******</asp:TextBox>
            </td>
            <td class="auto-style7">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxConfirmPassword" ErrorMessage="Confirm Password is Required" ForeColor="Red"></asp:RequiredFieldValidator>
                <br />
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBoxPassword" ControlToValidate="TextBoxConfirmPassword" ErrorMessage="Both Password must be same" ForeColor="Red"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style6">First Name:</td>
            <td class="auto-style9">
                <asp:TextBox ID="TextBoxFirstN" runat="server" CssClass="auto-style8" Width="220px"></asp:TextBox>
            </td>
            <td class="auto-style7">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBoxFirstN" ErrorMessage="First Name is Required" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style6">Last Name:</td>
            <td class="auto-style9">
                <asp:TextBox ID="TextBoxLastN" runat="server" CssClass="auto-style8" Width="220px"></asp:TextBox>
            </td>
            <td class="auto-style7">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBoxLastN" ErrorMessage="Last Name is Required" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
      
        <tr>
            <td class="auto-style6">Address:</td>
            <td class="auto-style9">
                <asp:TextBox ID="TextBoxAddress" runat="server" CssClass="auto-style8" Width="220px"></asp:TextBox>
            </td>
            <td class="auto-style7">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBoxAddress" ErrorMessage="Addres is Required" ForeColor="Red"></asp:RequiredFieldValidator>
                <br />
            </td>
        </tr>
       
        <tr>
            <td class="auto-style6">E-mail:</td>
            <td class="auto-style9">
                <asp:TextBox ID="TextBoxMail" runat="server" CssClass="auto-style8" Width="220px" TextMode="Email"></asp:TextBox>
            </td>
            <td class="auto-style7">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBoxMail" ErrorMessage="E-mail is Required" ForeColor="Red"></asp:RequiredFieldValidator>
                <br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxMail" ErrorMessage="You must enter the valid E-mail Addres" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>
        </tr>
      
        <tr>
            <td class="auto-style6">Telephone:</td>
            <td class="auto-style9">
                <asp:TextBox ID="TextBoxTelephone" runat="server" CssClass="auto-style8" Width="220px" MaxLength="10" TextMode="Number"></asp:TextBox>
            </td>
            <td class="auto-style7">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TextBoxTelephone" ErrorMessage="Telephone is Required and must be numbers" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
       
        <tr class="auto-style8">
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style10">
                <asp:Button ID="Register1" runat="server" OnClick="Register_Click" Text="Register" Width="97px" class="btn btn-default"/>
                <input id="Reset1"  type="reset" value="Reset" class="btn btn-primary"/></td>
            <td>
                <asp:Label ID="userExistsError" runat="server" ForeColor="Red" Text="User already exists" Visible="False"></asp:Label>
            </td>
        </tr>
    </table>
            </fieldset>
    </form>
</asp:Content>
