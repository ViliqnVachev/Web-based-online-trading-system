<%@ Page Language="C#" MasterPageFile="~/Main2.Master" AutoEventWireup="true" CodeBehind="myproducts.aspx.cs" Inherits="webStore.myproducts" %>

<asp:Content ID="headCnt" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style1 {
        height: 110px;
    }
        .auto-style2 {
            height: 110px;
            width: 956px;
            text-align: center;
        }
        .auto-style3 {
            width: 956px;
            text-align: center;
        }
        .auto-style4 {
            height: 110px;
            text-align: center;
            width: 321px;
        }
        .auto-style5 {
            width: 321px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">
    <form id="form1" runat="server">
    <br />  

    <table class="nav-justified">
        <tr>
            <td class="auto-style4"></td>
            <td class="auto-style2">
                <asp:SqlDataSource ID="SqlDataSourceMyProducts" runat="server" ConnectionString="<%$ ConnectionStrings:ProductsConnectionString %>" SelectCommand="SELECT [product_name], [price], [quantity], [image], [id_product], [visible] FROM [Products] WHERE (([id_user] = @id_user) AND ([visible] = @visible))">
                    <SelectParameters>
                        <asp:SessionParameter DefaultValue="" Name="id_user" SessionField="UserId" Type="Int32" />
                        <asp:Parameter DefaultValue="0" Name="visible" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <div class="text-left">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceMyProducts" AllowPaging="True" Height="650px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="950px" DataKeyNames="id_product">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="product_name" HeaderText="product_name" SortExpression="product_name" />
                        <asp:BoundField DataField="price" HeaderText="price" SortExpression="price" />
                        <asp:BoundField DataField="quantity" HeaderText="quantity" SortExpression="quantity" />
                        <asp:TemplateField HeaderText="image" SortExpression="image">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("image") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Image ID="Image1" runat="server" Height="100px" ImageUrl='<%# Eval("image") %>' Width="150px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="id_product" HeaderText="id_product" SortExpression="id_product" InsertVisible="False" ReadOnly="True" />
                        <asp:BoundField DataField="visible" HeaderText="visible" SortExpression="visible" Visible="False" />
                    </Columns>
                </asp:GridView>
                </div>
                <br />
            </td>
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</form>

</asp:Content>
