<%@ Page Language="C#" MasterPageFile="~/Master/Admin.master" AutoEventWireup="true" CodeFile="UserAdd.aspx.cs" Inherits="Admin_UserAdd" Title="第三波书店 添加用户" %>

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
          width:100px;
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
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                                            ControlToValidate="txtLoginId" Display="Dynamic" ErrorMessage="*不为空"></asp:RequiredFieldValidator>
                                                        <asp:Label ID="labmessage" runat="server" style="color: #FF3300"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="tdright">
                                                        密码：</td>
                                                    <td style="text-align: left" class="tdleft">
                                                        <asp:TextBox ID="txtpwd" runat="server" TextMode="Password"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                                                            ControlToValidate="txtpwd" Display="Dynamic" ErrorMessage="*不为空"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="tdright">
                                                        确认密码：</td>
                                                    <td style="text-align: left" class="tdleft">
                                                        <asp:TextBox ID="txtpwdagin" runat="server" TextMode="Password"></asp:TextBox>
                                                        <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                                            ControlToCompare="txtpwd" ControlToValidate="txtpwdagin" ErrorMessage="*密码不一致"></asp:CompareValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="tdright">
                                                        用户状态：</td>
                                                    <td class="tdleft">
                                                        <asp:DropDownList ID="ddluserstate" runat="server" Width="70px">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" 
                                                            ControlToValidate="ddluserstate" Display="Dynamic" ErrorMessage="*不为空" 
                                                            InitialValue="0"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="tdright">
                                                        用户角色：</td>
                                                    <td class="tdleft">
                                                        <asp:DropDownList ID="ddluserrole" runat="server">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" 
                                                            ControlToValidate="ddluserrole" Display="Dynamic" ErrorMessage="*不为空" 
                                                            InitialValue="0"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="tdright">
                                                        姓名：</td>
                                                    <td class="tdleft">
                                                        <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
                                                            ControlToValidate="txtname" Display="Dynamic" ErrorMessage="*不为空"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="tdright">
                                                        电话：</td>
                                                    <td class="tdleft">
                                                        <asp:TextBox ID="txtphone" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" 
                                                            ControlToValidate="txtphone" Display="Dynamic" ErrorMessage="*不为空"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="tdright">
                                                        地址：</td>
                                                    <td  class="tdleft">
                                                        <asp:TextBox ID="txtaddress" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" 
                                                            ControlToValidate="txtaddress" Display="Dynamic" ErrorMessage="*不为空"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr >
                                                    <td class="tdright">
                                                        邮箱：</td>
                                                    <td class="tdleft">
                                                        <asp:TextBox ID="txtmail" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                                            ControlToValidate="txtmail" Display="Dynamic" ErrorMessage="*不为空"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                                            ControlToValidate="txtmail" ErrorMessage="*格式错误" 
                                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr >
                                                    <td class="tdright">
                                                        &nbsp;</td>
                                                    <td class="tdleft">
                                                        <asp:Button ID="btnadd" runat="server" Text="添加" onclick="btnadd_Click"  />
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

