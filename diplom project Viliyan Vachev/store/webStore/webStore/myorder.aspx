<%@ Page Language="C#" MasterPageFile="~/Main2.Master" AutoEventWireup="true" CodeBehind="myorder.aspx.cs" Inherits="webStore.myorder" %>


<asp:Content ID="headCnt" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            font-size: xx-large;
            width: 956px;
            text-align: center;
        }

        .auto-style2 {
            width: 321px;
        }

        .auto-style3 {
            width: 956px;
        }

        .auto-style4 {
            width: 321px;
            height: 124px;
        }

        .auto-style5 {
            width: 956px;
            height: 124px;
        }

        .auto-style6 {
            height: 124px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">
    <form id="form1" runat="server">
        <br />

        <table class="nav-justified">
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style1">My Orders</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4"></td>
                <td class="auto-style5">
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MyOrderConnectionString2 %>" SelectCommand="SELECT * FROM [Orders] WHERE ([id_user] = @id_user)">
                        <SelectParameters>
                            <asp:SessionParameter Name="id_user" SessionField="UserId" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <br />
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="None" DataKeyNames="id_order" DataSourceID="SqlDataSource1" Height="300px" Width="950px">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="id_order" HeaderText="Оrder number" InsertVisible="False" ReadOnly="True" SortExpression="id_order" />
                            <asp:BoundField DataField="id_user" HeaderText="id_user" SortExpression="id_user" Visible="False" />
                            <asp:BoundField DataField="date_time" HeaderText="Date of the order" SortExpression="date_time" />
                            <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status" />
                        </Columns>
                        <EditRowStyle BackColor="#7C6F57" />
                        <FooterStyle BackColor="#464866" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#464866" Font-Bold="True" ForeColor="White" Width="950px" Height="100px" />
                        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#E3EAEB" />
                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    </asp:GridView>
                </td>
                <td class="auto-style6"></td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>

</asp:Content>
