﻿<%@ Page Language="C#" MasterPageFile="~/AdminMain.Master" AutoEventWireup="true" CodeBehind="detailsProduct.aspx.cs" Inherits="webStore.detailsProduct" %>

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
        .auto-style24 {
            width: 356px;
            height: 78px;
            text-align: left;
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
            <td class="auto-style21"></td>
            <td class="auto-style1">Edit Product</td>
            <td class="auto-style22"></td>
        </tr>
        <tr>
            <td class="auto-style10">Product Name:</td>
            <td class="auto-style18">
                <asp:TextBox ID="ProdName" runat="server" CssClass="auto-style14" Enabled="False" Height="30px" Width="333px"></asp:TextBox>
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
                <asp:TextBox ID="Price" runat="server" style="text-align: right" CssClass="auto-style14" Enabled="False" Height="30px" Width="68px"></asp:TextBox>
&nbsp;
                <asp:Label ID="Label6" runat="server" CssClass="auto-style14" Height="36px" Text=" lv."></asp:Label>
            </td>
            <td class="auto-style12"></td>
        </tr>
        <tr>
            <td class="auto-style10">Quantity:</td>
            <td class="auto-style19">
                <asp:TextBox ID="Quantity" runat="server" style="text-align: right" CssClass="auto-style14" Height="30px" Width="68px" TextMode="Number" Enabled="False"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            <td class="auto-style16">
                &nbsp;</td>
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
                <asp:TextBox ID="Description" runat="server" Enabled="False" Height="250px" Width="330px" TextMode="MultiLine"></asp:TextBox>
            </td>
            <td class="auto-style28"></td>
        </tr>
        <tr>
            <td class="auto-style29"></td>
            <td class="auto-style24">
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="DeleteButton" runat="server" Text="Disable" class="btn btn-primary" OnClick="DeleteButton_Click" />
            &nbsp;
                &nbsp; <asp:Button ID="ButtonCencel" runat="server" class="btn btn-primary" Text="Cencel" OnClick="ButtonCencel_Click" />
            </td>
            <td class="auto-style30"></td>
        </tr>
        <tr>
            <td class="auto-style10">&nbsp;</td>
            <td class="auto-style19">
&nbsp;&nbsp;
&nbsp;</td>
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