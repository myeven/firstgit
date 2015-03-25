<%@ Page Language="C#" MasterPageFile="~/Master/Admin.master" AutoEventWireup="true" CodeFile="ListAllBooks.aspx.cs" Inherits="Admin_ListAllBooks" Title="第三波书店 图书列表" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

        .style12
        {
            width: 100%;
        }
        .style13
        {
            height: 45px;
        }
        .style14
        {
            height: 45px;
            width: 277px;
        }
        .style15
        {
            height: 45px;
            width: 170px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style12">
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <table style="width:95%">
                    <tr>
                        <td style="text-align: left" class="style15">
                            <asp:Button ID="btnall" runat="server" Text="全选" onclick="btnall_Click" 
                    style="height: 21px" />
                            <asp:Button ID="btnresever" runat="server" Text="反选" 
                    onclick="btnresever_Click" />
                            <asp:Button ID="btndelete" runat="server" Text="删除所选" 
                    onclick="btndelete_Click" OnClientClick="javascript:return confirm('确定删除？')" />
                        </td>
                        <td style="text-align: right" class="style14">
                            请选择图书类别：<asp:DropDownList ID="ddlbooksort" runat="server" 
                                onselectedindexchanged="ddlbooksort_SelectedIndexChanged" 
                                AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: right" class="style13">
                请输入关键字：<asp:TextBox ID="txtsearch" runat="server" Height="18px"></asp:TextBox>&nbsp; <asp:ImageButton ID="imgbtnsearch" runat="server" Height="22px" 
                    ImageUrl="~/Images/Search.jpg" Width="48px" onclick="imgbtnsearch_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:GridView ID="grvbooklist" runat="server"  
                    AutoGenerateColumns="False" 
                    onpageindexchanging="grvbooklist_PageIndexChanging" DataKeyNames="bookId" 
                    onrowcommand="grvbooklist_RowCommand" AllowPaging="True" >
                                <RowStyle ForeColor="#000066" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="cbok" runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle Width="30px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="图书封面">
                                        <ItemTemplate>
                                            <asp:Image ID="Image1" runat="server" Height="43px" Width="39px" ImageUrl='<%#BindImg(Eval("ISBN")) %>' />
                                        </ItemTemplate>
                                        <ItemStyle Width="60px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Title" HeaderText="书名" />
                                    <asp:BoundField DataField="Author" HeaderText="作者" />
                                    <asp:BoundField DataField="categoryname" HeaderText="类别" >
                                        <ItemStyle Width="110px" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="详细">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lkbtndetail" runat="server" CommandName="BookDetail" CommandArgument='<%#Eval("bookId") %>'>详细信息</asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle Width="60px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="操作">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbtndelete" runat="server" OnClientClick="javascript:return confirm('确定删除？')" CommandName="BookDelete" CommandArgument='<%#Eval("bookId") %>'>删除</asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle Width="40px" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="text-align: left">
                            将图书归入：<asp:DropDownList ID="ddlnewcategory" runat="server">
                            </asp:DropDownList>
&nbsp;
                            <asp:Button ID="btnremove" runat="server" Text="移动" onclick="btnremove_Click" 
                                ValidationGroup="a" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="ddlnewcategory" ErrorMessage="请选择要归入的分类" 
                                InitialValue="0" ValidationGroup="a"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

