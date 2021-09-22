<%@ Page Language="C#" MasterPageFile="~/Main2.Master" AutoEventWireup="true" CodeBehind="mobileAccessories.aspx.cs" Inherits="webStore.mobileAccessories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 321px;
            height: 21px;
        }

        .auto-style3 {
            height: 21px;
        }

        .auto-style4 {
            height: 21px;
            font-size: xx-large;
            text-align: center;
            width: 956px;
        }

        .auto-style5 {
            width: 321px;
            height: 153px;
        }

        .auto-style6 {
            height: 153px;
        }

        .auto-style7 {
            height: 153px;
            width: 956px;
        }

        .auto-style8 {
            width: 956px;
        }

        .auto-style9 {
            width: 321px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <br />
    <form id="form1" runat="server">
        <br />

        <table class="nav-justified">
            <tr>
                <td class="auto-style2"></td>
                <td class="auto-style4">Mobile Accessories</td>
                <td class="auto-style3"></td>
            </tr>
            <tr>
                <td class="auto-style5"></td>
                <td class="auto-style7">
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:OtherConnectionString2 %>" SelectCommand="SELECT [product_name], [price], [image], [id_product], [id_category], [visible] FROM [Products] WHERE (([visible] = @visible) AND ([id_user] != @id_user) AND ([id_category] = @id_category))">
                        <SelectParameters>
                            <asp:SessionParameter DefaultValue="" Name="id_user" SessionField="UserId" Type="Int32" />
                            <asp:Parameter DefaultValue="0" Name="visible" Type="Int32" />
                            <asp:Parameter DefaultValue="12" Name="id_category" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" GridLines="None" AutoGenerateColumns="False" DataKeyNames="id_product" DataSourceID="SqlDataSource1" Width="950px" Height="350px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:BoundField DataField="product_name" HeaderText="Product Name" SortExpression="product_name" />
                            <asp:BoundField DataField="price" HeaderText="Price" SortExpression="price" />
                            <asp:TemplateField HeaderText="Image" SortExpression="image">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("image") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Image ID="Image1" runat="server" Height="100px" ImageUrl='<%# Eval("image") %>' Width="150px" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="id_product" HeaderText="Product Number" InsertVisible="False" ReadOnly="True" SortExpression="id_product" />
                            <asp:BoundField DataField="id_category" HeaderText="id_category" SortExpression="id_category" Visible="False" />
                            <asp:BoundField DataField="visible" HeaderText="visible" SortExpression="visible" Visible="False" />
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
                <td class="auto-style9">&nbsp;</td>
                <td class="auto-style8">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>

</asp:Content>
