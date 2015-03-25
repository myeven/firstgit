<%@ Page Language="C#" MasterPageFile="~/Master/Admin.master" AutoEventWireup="true" CodeFile="ListAllOrders.aspx.cs" Inherits="Admin_ListAllOrders" Title="第三波书店 订单列表" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style12
        {
            width: 85%;
        }
       
        .style13
        {
            width: 182px;
            height: 45px;
        }
       
        .style14
        {
            height: 45px;
        }
       
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script src="../Control/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <table class="style12">
        <tr>
            <td style="text-align:right" class="style13">
                请选择订单的起止日期：</td>
            <td style="text-align: left" class="style14">
                <asp:TextBox ID="txtstardate" runat="server" onclick="WdatePicker()"></asp:TextBox>
                至<asp:TextBox ID="txtenddate" runat="server" onclick="WdatePicker()"></asp:TextBox>&nbsp;&nbsp;&nbsp; <asp:Button 
                    ID="btnsearch" runat="server" Text="查询" onclick="btnsearch_Click" />
                <asp:Label ID="labmessage" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="gvorderlist" runat="server" AutoGenerateColumns="False" 
                    onrowcommand="gvorderlist_RowCommand" DataKeyNames="Id" Width="80%" 
                    AllowPaging="True" onpageindexchanging="gvorderlist_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField HeaderText="编号">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Container.DataItemIndex+1 %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="用户名" DataField="UserName" />
                        <asp:BoundField HeaderText="订单总价" DataField="TotalPrice" />
                        <asp:BoundField HeaderText="订单日期" DataField="OrderDate" />
                        <asp:TemplateField HeaderText="详情">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtndetail" runat="server" CommandName="lbtndetail" CommandArgument='<%#Eval("Id") %>'>订单详情</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
                                <asp:LinkButton ID="lbtndelete" runat="server" OnClientClick="javascript:return confirm('确定删除？')" CommandName="lbtndelete" CommandArgument='<%#Eval("Id") %>'>删除订单</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

