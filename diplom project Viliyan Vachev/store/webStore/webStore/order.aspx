<%@ Page Language="C#" MasterPageFile="~/Main2.Master" AutoEventWireup="true" CodeBehind="order.aspx.cs" Inherits="webStore.order" %>

<asp:Content ID="headCnt" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            font-size: xx-large;
            width: 356px;
            height: 79px;
        }
        .auto-style2 {
            width: 650px;
        }
        .auto-style3 {
            width: 356px;
        }
        .auto-style10 {
            width: 650px;
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
        .auto-style15 {
            font-size: x-large;
        }
        .auto-style16 {
            height: 50px;
            text-align: left;
        }
        .auto-style18 {
            width: 356px;
            height: 50px;
        }
        .auto-style19 {
            width: 356px;
            height: 50px;
            text-align: left;
        }
        .auto-style21 {
            width: 650px;
            height: 79px;
        }
        .auto-style22 {
            height: 79px;
        }
        .auto-style26 {
            width: 650px;
            height: 146px;
            text-align: right;
            font-size: larger;
        }
        .auto-style27 {
            width: 356px;
            height: 146px;
            text-align: left;
        }
        .auto-style28 {
            height: 146px;
        }
        .auto-style29 {
            width: 650px;
            height: 50px;
            text-align: right;
        }
        </style>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">
    <form id="form1" runat="server">
    <br />  
    <table class="nav-justified">
        <tr>
            <td class="auto-style21"></td>
            <td class="auto-style1">Make an Order</td>
            <td class="auto-style22"></td>
        </tr>
        <tr>
            <td class="auto-style10">Product Name:</td>
            <td class="auto-style18">
                <asp:TextBox ID="TextBoxProdName" runat="server" CssClass="auto-style14" Enabled="False" Height="30px" Width="333px"></asp:TextBox>
            </td>
            <td class="auto-style12"></td>
        </tr>
        <tr>
            <td class="auto-style10">Category:</td>
            <td class="auto-style19">
                <asp:TextBox ID="TextBoxCategoryName" runat="server" CssClass="auto-style14" Enabled="False" Height="30px" Width="333px"></asp:TextBox>
            </td>
            <td class="auto-style16"></td>
        </tr>
        <tr>
            <td class="auto-style10">Price:</td>
            <td class="auto-style19">
                <asp:TextBox ID="TextBoxPrice" runat="server" style="text-align: right" CssClass="auto-style14" Enabled="False" Height="30px" Width="68px"></asp:TextBox>
&nbsp;
                <asp:Label ID="Label6" runat="server" CssClass="auto-style14" Height="36px" Text=" lv."></asp:Label>
            </td>
            <td class="auto-style12"></td>
        </tr>
        <tr>
            <td class="auto-style10">Quantity:</td>
            <td class="auto-style19">
                <asp:TextBox ID="TextBoxQuantity" runat="server" style="text-align: right" CssClass="auto-style14" Height="30px" Width="68px" TextMode="Number"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="LabelQuantity" runat="server" CssClass="auto-style14" Height="36px" Text="Remaining: " Width="94px"></asp:Label>
                <asp:Label ID="Label8" runat="server" CssClass="auto-style14" Height="36px"></asp:Label>
            </td>
            <td class="auto-style16">
                <asp:Label ID="Label7" runat="server" CssClass="auto-style14" ForeColor="Red" Height="36px" Text="Insufficient quantity" Visible="False"></asp:Label>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxQuantity" CssClass="auto-style14" ErrorMessage="Quantity is Required" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style10">Image:</td>
            <td class="auto-style19">
                <asp:Image ID="Image1" runat="server" Height="150px" Width="200px" />
            </td>
            <td class="auto-style12"></td>
        </tr>
        <tr>
            <td class="auto-style26">Description:</td>
            <td class="auto-style27">
                <asp:TextBox ID="TextBoxDescription" runat="server" Enabled="False" Height="250px" Width="330px" CssClass="auto-style14" TextMode="MultiLine"></asp:TextBox>
            </td>
            <td class="auto-style28">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style29">Total Amount:</td>
            <td class="auto-style19">
                &nbsp;<asp:TextBox ID="TextBoxTotal" runat="server" style="text-align: right" CssClass="auto-style14" Enabled="False" Height="30px" Visible="False" Width="68px"></asp:TextBox>
&nbsp;<asp:Label ID="Label5" runat="server" CssClass="auto-style15" Text=" lv." Visible="False"></asp:Label>
            </td>
            <td class="auto-style16"></td>
        </tr>
        <tr>
            <td class="auto-style10">&nbsp;</td>
            <td class="auto-style19">
&nbsp;
                <asp:Button ID="CalculateButton" runat="server" class="btn btn-default" Text="Calculate" OnClick="CalculateButton_Click" />
                &nbsp;
                <asp:Button ID="Button2" runat="server" class="btn btn-primary" Text="Add to Cart" OnClick="Button2_Click" />
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
