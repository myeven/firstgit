<%@ Page Language="C#" MasterPageFile="~/Master/Admin.master" AutoEventWireup="true" CodeFile="AdminMain.aspx.cs" Inherits="Admin_AdminMain" Title="第三波书店|后台管理首页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style12
        {
            width: 100%;
            height: 490px;
        }
        .style14
        {
            width: 50%;
            height: 225px;
        }
        .style16
        {
            height: 28px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style12">
        <tr>
            <td>
                <table align="center" class="style14" style="border-style: dotted;">
                    <tr>
                        <td bgcolor="#99FF99" class="style16">
                            管理员<asp:Label ID="labname" runat="server" 
                                style="font-weight: 700; color: #669900"></asp:Label>
                            登陆成功</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Welcome.gif" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

