<%@ Page Language="C#" MasterPageFile="~/Main2.Master" AutoEventWireup="true" CodeBehind="create.aspx.cs" Inherits="webStore.create" %>

<asp:Content ID="headCnt" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            text-align: center;
            font-size: xx-large;
            height: 79px;
            width: 650px;
        }
        .auto-style2 {
            height: 79px;
        }
        .auto-style3 {
            width: 650px;
        }
        .auto-style4 {
            height: 79px;
            font-size: xx-large;
            width: 327px;
        }
        .auto-style5 {
            width: 327px;
        }
        .auto-style6 {
            width: 650px;
            text-align: center;
            font-size: larger;
            height: 74px;
        }
        .auto-style7 {
            width: 650px;
            text-align: right;
            font-size: larger;
            height: 50px;
        }
        .auto-style8 {
            width: 327px;
            height: 50px;
        }
        .auto-style9 {
            height: 50px;
        }
        .auto-style10 {
            width: 650px;
            text-align: right;
            font-size: larger;
            height: 56px;
        }
        .auto-style11 {
            width: 327px;
            height: 56px;
        }
        .auto-style12 {
            height: 56px;
        }
        .auto-style14 {
            font-size: larger;
        }
        .auto-style15 {
            height: 50px;
            text-align: left;
        }
        .auto-style16 {
            width: 327px;
            height: 74px;
            text-align: center;
        }
        .auto-style17 {
            height: 74px;
        }
    .auto-style18 {
        width: 650px;
        height: 77px;
    }
    .auto-style19 {
        width: 327px;
        height: 77px;
    }
    .auto-style20 {
        height: 77px;
    }
        .auto-style21 {
            font-size: x-large;
        }
        .auto-style22 {
            font-size: large;
        }
    </style>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">
    <form id="form1" runat="server">
    <br />  
    
        <table class="nav-justified">
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style4">Create a new Product</td>
                <td class="auto-style2"></td>
            </tr>
            <tr>
                <td class="auto-style7">Product Name:</td>
                <td class="auto-style8">
                    <asp:TextBox ID="TextBoxProdName" runat="server" CssClass="auto-style22" Height="30px" Width="330px"></asp:TextBox>
                </td>
                <td class="auto-style15">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxProdName" ErrorMessage="Product Name is Required" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">Price:</td>
                <td class="auto-style8">
                    <asp:TextBox ID="TextBoxPrice" runat="server" style="text-align: right" Height="30px" Width="68px"></asp:TextBox>
                </td>
                <td class="auto-style15">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxPrice" ErrorMessage="Price is Requierd" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:Label ID="LabelValid" runat="server" ForeColor="Red" Text="Incorect format" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">Quantity:</td>
                <td class="auto-style8">
                    <asp:TextBox ID="TextBoxQuantity" runat="server" style="text-align: right" CssClass="auto-style14" TextMode="Number" Width="68px" Height="30px"></asp:TextBox>
                </td>
                <td class="auto-style15">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxQuantity" ErrorMessage="Quantity is Required" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">Category:</td>
                <td class="auto-style8">
                    <asp:DropDownList ID="DropDownListCategory" runat="server" CssClass="auto-style14" DataSourceID="SqlDataSource1" DataTextField="gategory_name" DataValueField="gategory_name" Height="30px" Width="333px">
                        <asp:ListItem>Select Category</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CategoryConnectionString %>" SelectCommand="SELECT [gategory_name] FROM [Categories]"></asp:SqlDataSource>
                </td>
                <td class="auto-style15">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="DropDownListCategory" ErrorMessage="Gategory is Required" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">Add Image:</td>
                <td class="auto-style8">
                    
                    <asp:FileUpload ID="FileUploadImages" runat="server" CssClass="auto-style14" Width="333px" />
                </td>
                <td class="auto-style9">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="FileUploadImages" ErrorMessage="Image is Required" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    <asp:Label ID="Label1" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style10">Description:</td>
                <td class="auto-style11">
                    <asp:TextBox ID="TextBoxDescription" runat="server" Height="250px" Width="330px" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td class="auto-style12"></td>
            </tr>
            <tr>
                <td class="auto-style6"></td>
                <td class="auto-style16">
                    <em>
                    <br />
                    <br />
                    <asp:Button ID="Button1" runat="server" class="btn btn-default" Text="Add product" OnClick="Button1_Click" />
                    </em>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <input id="Button2" type="button"  class="btn btn-primary" value="Cencel" onclick="window.location.href='home.aspx'" /></td>
                <td class="auto-style17"></td>
            </tr>
            <tr>
                <td class="auto-style18"></td>
                <td class="auto-style19"><strong><em>
                    <asp:Label ID="LabelSuccess" runat="server" CssClass="auto-style21" ForeColor="#CC3300" Text="You have successfully added a product" Visible="False"></asp:Label>
                    </em></strong></td>
                <td class="auto-style20"></td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
    
</asp:Content>
