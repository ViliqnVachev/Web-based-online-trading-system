<%@ Page Language="C#" MasterPageFile="~/AdminMain.Master" AutoEventWireup="true" CodeBehind="products.aspx.cs" Inherits="webStore.products" %>

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

        .auto-style5 {
            font-size: xx-large;
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

            <asp:Label ID="LabelWelcome" runat="server" Text="Welcome" CssClass="auto-style5"></asp:Label>
            <br />
            <br />
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StoreConnectionString %>" SelectCommand="SELECT [product_name], [price], [image], [id_product], [visible], [quantity] FROM [Products] WHERE (([visible] = @visible) AND ([quantity] &gt; @quantity))">
                <SelectParameters>
                    <asp:Parameter DefaultValue="0" Name="visible" Type="Int32" />
                    <asp:Parameter DefaultValue="0" Name="quantity" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
            <table class="nav-justified">
                <tr>
                    <td class="auto-style6"></td>
                    <td class="auto-style3">
                        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="auto-style4" GridLines="None" DataSourceID="SqlDataSource1" Height="750px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="950px" DataKeyNames="id_product">
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
                                <asp:BoundField DataField="visible" HeaderText="visible" SortExpression="visible" Visible="False" />
                                <asp:BoundField DataField="quantity" HeaderText="quantity" SortExpression="quantity" Visible="False" />
                            </Columns>
                            <EditRowStyle BackColor="#7C6F57" />
                            <FooterStyle BackColor="#76323F" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#76323F" Font-Bold="True" ForeColor="White" Width="950px" Height="100px" />
                            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#E3EAEB" />
                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                            <EmptyDataTemplate>
                                &nbsp;
                            </EmptyDataTemplate>
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