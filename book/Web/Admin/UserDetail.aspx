<%@ Page Language="C#" MasterPageFile="~/Master/Admin.master" AutoEventWireup="true" CodeFile="UserDetail.aspx.cs" Inherits="Admin_UserDetail" Title="第三波书店 用户详情" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .tdleft
        {
          border:1px solid #BBE188;
          border-collapse:collapse;
          text-align:left;
          height:20px;
        }  
        .tdright
        {
          border:1px solid #BBE188;
          border-collapse:collapse;
          text-align:right;
          height:20px;
        }        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 96%;">
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <table style="width: 90%;text-align:center">
                    <tr>
                        <td>
                            <table style="width:96%;border:1px solid #BBE188;border-collapse:collapse">
                                                <tr>
                                                    <td class="tdright">
                                                        登录名：</td>
                                                    <td style="text-align: left" class="tdleft">
                                                        <asp:TextBox ID="txtLoginId" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="tdright">
                                                        密码：</td>
                                                    <td style="text-align: left" class="tdleft">
                                                        <asp:TextBox ID="txtpwd" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="tdright">
                                                        姓名：</td>
                                                    <td class="tdleft">
                                                        <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="tdright">
                                                        邮箱：</td>
                                                    <td class="tdleft">
                                                        <asp:TextBox ID="txtmail" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="tdright">
                                                        地址：</td>
                                                    <td class="tdleft">
                                                        <asp:TextBox ID="txtaddress" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="tdright">
                                                        电话：</td>
                                                    <td class="tdleft">
                                                        <asp:TextBox ID="txtphone" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="tdright">
                                                        用户状态：</td>
                                                    <td  class="tdleft">
                                                        <asp:RadioButtonList ID="rbtnlistuserstate" runat="server" 
                                                            RepeatDirection="Horizontal">
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr >
                                                    <td class="tdright">
                                                        用户角色：</td>
                                                    <td class="tdleft">
                                                        <asp:RadioButtonList ID="rbtnlistuserrole" runat="server" 
                                                            RepeatDirection="Horizontal">
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr >
                                                    <td class="tdright">
                                                        &nbsp;&nbsp;&nbsp;&nbsp; </td>
                                                    <td class="tdleft">
                                                        <asp:Button ID="btnupdate" runat="server" Text="更新" onclick="btnupdate_Click" />
&nbsp;</td>
                                                </tr>
                                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

