<%@ Page Language="C#" MasterPageFile="~/Master/Admin.master" AutoEventWireup="true" CodeFile="ListAllUsers.aspx.cs" Inherits="Admin_UserList" Title="第三波书店 用户列表" %>

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
        width: 264px;
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
    <table style="width:90%">
        <tr>
            <td style="text-align: left" class="style14">
                <asp:Button ID="btnall" runat="server" Text="全选" onclick="btnall_Click" 
                    style="height: 21px" />
                <asp:Button ID="btnresever" runat="server" Text="反选" 
                    onclick="btnresever_Click" />
                <asp:Button ID="btnno" runat="server" Text="禁用用户" 
                    onclick="btnno_Click" OnClientClick="javascript:return confirm('确定禁用？')" />
                <asp:Button ID="btnallow" runat="server" Text="启用用户" 
                    onclick="btnallow_Click" 
                    OnClientClick="javascript:return confirm('确定启用？')" />
            </td>
            <td style="text-align: right" class="style13">
                请选择用户角色：<asp:DropDownList ID="dluserrole" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="dluserrole_SelectedIndexChanged">
                </asp:DropDownList>
                请输入关键字：<asp:TextBox ID="txtsearch" runat="server" Height="16px"></asp:TextBox> <asp:ImageButton ID="imgbtnsearch" runat="server" Height="22px" 
                    ImageUrl="~/Images/Search.jpg" Width="48px" onclick="imgbtnsearch_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="grvuserlist" runat="server"  
                    AutoGenerateColumns="False" 
                    onpageindexchanging="grvuserlist_PageIndexChanging" DataKeyNames="UserId" 
                    onrowcommand="grvuserlist_RowCommand" >
                    <RowStyle ForeColor="#000066" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="cbok" runat="server" />
                            </ItemTemplate>
                            <ItemStyle Width="30px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="LoginId" HeaderText="用户名" />
                        <asp:BoundField DataField="UserName" HeaderText="姓名" />
                        <asp:BoundField DataField="Address" HeaderText="地址" />
                        <asp:BoundField DataField="Mail" HeaderText="邮箱" />
                        <asp:BoundField DataField="Phone" HeaderText="电话" />
                        <asp:BoundField DataField="UserRole" HeaderText="用户角色" />
                        <asp:TemplateField HeaderText="用户状态">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtnuserstate" runat="server"  CommandName="UserState" 
                                    CommandArgument='<%#Eval("UserId") %>' Text='<%#Eval("UserState") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="详细">
                            <ItemTemplate>
                                <asp:LinkButton ID="lkbtndetail" runat="server" CommandName="UserDetail" CommandArgument='<%#Eval("UserId") %>'>详细信息</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: left">
               
                <br />
            &nbsp;
                <asp:Button ID="btndelete" runat="server" Text="删除所选" 
                    onclick="btndelete_Click" OnClientClick="javascript:return confirm('确定删除？')" />
               
            </td>
        </tr>
    </table>
            </td>
        </tr>
    </table>
</asp:Content>

