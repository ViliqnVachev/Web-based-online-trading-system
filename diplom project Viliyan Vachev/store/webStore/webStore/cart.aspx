<%@ Page Language="C#" MasterPageFile="~/Main2.Master" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="webStore.cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 550px;
        }
        .auto-style2 {
            font-size: xx-large;
            width: 521px;
            text-align: center;
        }
        .auto-style4 {
            width: 550px;
            height: 96px;
            text-align: right;
        }
        .auto-style5 {
            width: 521px;
            height: 96px;
        }
        .auto-style6 {
            height: 96px;
        }
        .auto-style7 {
            font-size: x-large;
        }
        .auto-style8 {
            font-size: 24px;
        }
        .auto-style11 {
            height: 104px;
        }
        .auto-style12 {
            width: 521px;
            height: 104px;
        }
        .auto-style13 {
            width: 550px;
            height: 104px;
        }
    </style>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <form id="form1" runat="server">
        <br />
    <table class="nav-justified">
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style2">Finish Your Order</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4"><span style="display: inline !important; float: none; background-color: transparent; color: rgb(34, 34, 34); font-family: arial,sans-serif; font-size: 24px; font-style: normal; font-variant: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-decoration: none; text-indent: 0px; text-transform: none; -webkit-text-stroke-width: 0px; white-space: normal; word-spacing: 0px; word-wrap: break-word;">Your order is worth it:</span></td>
            <td class="auto-style5">&nbsp;
                <asp:Label ID="LabelFinalPrice" runat="server" CssClass="auto-style7"></asp:Label>
&nbsp;<asp:Label ID="Label1" runat="server" CssClass="auto-style8" Text="lv."></asp:Label>
            </td>
            <td class="auto-style6"></td>
        </tr>
        <tr>
            <td class="auto-style13"></td>
            <td class="auto-style12">
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CartConnectionString2 %>" SelectCommand="SELECT [quantity], [productName] FROM [Carts] WHERE ([id_order] = @id_order)">
                    <SelectParameters>
                        <asp:SessionParameter Name="id_order" SessionField="Order" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" Width="500px">
                    <Columns>
                        <asp:BoundField DataField="quantity" HeaderText="Quantity" SortExpression="quantity" />
                        <asp:BoundField DataField="productName" HeaderText="Product " SortExpression="productName" />
                    </Columns>
                </asp:GridView>
                <div class="text-right">
                <br />
                <br />
                <asp:Label ID="Label2" runat="server" CssClass="auto-style7" ForeColor="Red" Text="You don't have items in your cart" Visible="False"></asp:Label>
                <br />
                <br />
                <asp:Button ID="ButtonConfirm" runat="server" Text="Confirm" class="btn btn-danger" OnClick="ButtonConfirm_Click" Visible="False"/>
&nbsp;
                <asp:Button ID="ButtonCencel" runat="server" Text="Cencel" class="btn btn-primary" Visible="False" OnClick="ButtonCencel_Click"/>
                </div>
            </td>
            <td class="auto-style11"></td>
        </tr>
    </table>

    </form>

</asp:Content>
