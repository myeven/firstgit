<%@ Page Language="C#" MasterPageFile="~/Master/User.master" AutoEventWireup="true" CodeFile="BookDetail.aspx.cs" Inherits="Book_BookDetail" Title="图书详细信息" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

        *{Padding:0;margin:0}
        .style16
        {
            width: 220px;
        }
        .style17
        {
            width: 231px;
            height: 52px;
        }
        .style18
        {
            height: 52px;
        }
        .style19
        {
            height: 41px;
        }
        .style20
        {
            width: 231px;
            height: 36px;
        }
        .style21
        {
            height: 36px;
        }
        .style22
        {
            width: 231px;
            height: 48px;
        }
        .style23
        {
            height: 48px;
        }
        .style25
        {
            color: #FF3300;
        }
        .style26
        {
            color: #FF0000;
        }
        .style27
        {
            width: 231px;
            height: 46px;
        }
        .style28
        {
            width: 699px;
            height: 21px;
        }
        .style29
        {
            height: 21px;
        }
        .style30
        {
            height: 46px;
        }
        .style32
        {
            width: 231px;
            height: 21px;
        }
        .auto-style1 {
            height: 36px;
            width: 268435456px;
        }
        .auto-style2 {
            height: 48px;
            width: 268435456px;
        }
        .auto-style3 {
            height: 46px;
            width: 268435456px;
        }
        .auto-style4 {
            height: 21px;
            width: 268435456px;
        }
        .auto-style5 {
            height: 52px;
            width: 268435456px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" Runat="Server">
    
    <table>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="left">
                <div>
                <table width="98%">
                    <tr>
                        <td class="style16" rowspan="7">
                        <a name="top"></a> 
                            <asp:Image ID="imgBook" runat="server" Height="212px" Width="176px" />
                        </td>
                        <td colspan="2" class="style19">
                            <font color="navy"><strong>
                            <asp:Label ID="lblBookName" runat="server"></asp:Label>
                            </strong></font>
                        </td>
                    </tr>
                    <tr>
                       <td align="left" class="style20" >
                       
                            作者：<asp:Label ID="lblAuthor" runat="server"></asp:Label>
                        </td>
                        <td align="left" class="auto-style1">
                            丛书名：<asp:Label ID="lbltypeName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="style22">
                            出版社：<asp:Label ID="lblPublisher" runat="server"></asp:Label>
                        </td>
                        <td align="left" class="auto-style2">
                            ISBN：<asp:Label ID="lblISBN" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="style27">
                            出版时间：<asp:Label ID="lblPublishDate" runat="server"></asp:Label>
                        </td>
                        <td align="left" class="auto-style3">
                            字数：<asp:Label ID="lblFonts" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="style32" >
                            点击量：<asp:Label ID="lbclicks" runat="server"></asp:Label>
                         </td>
                         <td class="auto-style4">价格：<b><span class="style25">￥</span></span></b><asp:Label ID="lblPrice" runat="server" 
                                Font-Bold="True" ForeColor="#FF3300"></asp:Label>                               
                         </td>
                    </tr>
                    <tr>
                        <td class="style17">
                            </td>
                        <td align="right" class="auto-style5">
                            <asp:ImageButton ID="imgbtn_Buy" runat="server" CausesValidation="False" 
                                ImageUrl="~/Images/sale.gif" OnClick="imgbtn_Buy_Click" />
                        </td>
                    </tr>
                </table>
                </div>
                <span class="style25">
                    <strong>内容提要:</strong></span><br />
                <asp:Label ID="lblContent" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left">
                <div class="style25">
                    <strong>作者简介:</strong></div>
                <asp:Label ID="lblAuthorIntroduce" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left">
                <div class="style25">
                    <strong>编辑推荐:</strong></div>
                <asp:Label ID="lblRecomment" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left">
                <div class="style26">
                    <strong>目录:</strong></div>
                <asp:Label ID="lblCatagory" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <div>
                     <table>
                         <tr>
                             <td class="style29">
                                 </td>
                             <td align="right" class="style28">
                               <a href="#top"> 
                               <asp:Image ID="imgToTop" runat="server" Height="27px" ImageUrl="~/Images/top.bmp" Width="77px" />                               </a> 
                             &nbsp;&nbsp;&nbsp;&nbsp; 
                             </td>
                         </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>    
</asp:Content>

