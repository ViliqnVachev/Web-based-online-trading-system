<%@ Page Language="C#" MasterPageFile="~/AdminMain.Master" AutoEventWireup="true" CodeBehind="users.aspx.cs" Inherits="webStore.users" %>

<asp:Content ID="headCnt" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 956px;
        }

        .auto-style2 {
            height: 562px;
        }

        .auto-style3 {
            width: 956px;
            height: 562px;
            text-align: left;
        }

        .auto-style4 {
            margin-bottom: 143px;
            margin-right: 0px;
        }

        .auto-style6 {
            height: 562px;
            width: 321px;
        }

        .auto-style7 {
            width: 321px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">
    <form id="form1" runat="server">
        <div class="text-center">
            <br />
            <asp:SqlDataSource ID="SqlDataSourceRegistration" runat="server" ConnectionString="<%$ ConnectionStrings:RegistrationStoreConnectionString %>" SelectCommand="SELECT * FROM [Users] WHERE userName != 'admin'"></asp:SqlDataSource>
            <br />

            <table class="nav-justified">
                <tr>
                    <td class="auto-style6"></td>
                    <td class="auto-style3">
                        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" Height="750px" Width="950px" CssClass="auto-style4" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="id_user" DataSourceID="SqlDataSourceRegistration" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" />
                                <asp:BoundField DataField="userName" HeaderText="UserName" SortExpression="userName" />                                
                                <asp:BoundField DataField="first_name" HeaderText="First Name" SortExpression="first_name" />
                                <asp:BoundField DataField="lastst_name" HeaderText="Last Name" SortExpression="lastst_name" />
                                <asp:BoundField DataField="address" HeaderText="Address" SortExpression="address" />
                                <asp:BoundField DataField="telephone" HeaderText="Telephone" SortExpression="telephone" />
                                <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />
                                
                            </Columns>
                            <EditRowStyle BackColor="#7C6F57" />
                            <FooterStyle BackColor="#76323F" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#76323F" Font-Bold="True" ForeColor="White" Width="950px" Height="100px" />
                            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#E3EAEB" />
                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                        </asp:GridView>
                    </td>
                    <td class="auto-style2"></td>
                </tr>
                <tr>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>

        </div>
    </form>
</asp:Content>
