<%@ Page Language="C#" MasterPageFile="~/Master/User.master" AutoEventWireup="true" CodeFile="BookOrder.aspx.cs" Inherits="Book_BookOrder" Title="第三波书店 订单结算" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
        .style15
        {
            width: 100%;
        }
        .style16
        {
            color: #FF3300;
            font-weight: bold;
        }
        .style17
        {
            height: 30px;
        }
        .style18
        {
            height: 24px;
        }
        .style19
        {
            height: 41px;
        }
        .style20
        {
            height: 21px;
        font-weight: bold;
        font-family: 楷体;
        font-size: xx-large;
        color: #3333FF;
    }
        .style21
        {
            height: 24px;
            width: 401px;
        }
    .style22
    {
        height: 24px;
        width: 155px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" Runat="Server">
<table class="style15">
        <tr>
            <td colspan="4" class="style20">
                我的订单</td>
        </tr>
        <tr>
            <td colspan="4" class="style17">
                <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/购物流程.bmp" />
            </td>
        </tr>
        <tr>
            <td style="text-align:center" colspan="4">
                <asp:GridView ID="gvlist" runat="server" AutoGenerateColumns="False" 
                    Width="85%" DataKeyNames="BookId">
                    <Columns>
                        <asp:TemplateField HeaderText="图书封面">
                            <ItemTemplate>
                                <asp:Image ID="Image2" runat="server" Height="58px" Width="53px" ImageUrl='<%#"~/Images/BookCovers/"+Eval("ImgUrl")+".jpg" %>' />
                            </ItemTemplate>
                            <ItemStyle Width="80px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="BookName" HeaderText="书名" ReadOnly="True" />
                        <asp:BoundField DataField="UnitPrice" HeaderText="单价" ReadOnly="True">
                            <ItemStyle Width="90px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="数量">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("BookNumber") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtnumber" runat="server" Text='<%# Bind("BookNumber") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemStyle Width="80px" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="text-align:center" colspan="4" class="style19">
            </td>
        </tr>
        <tr>
            <td class="style18">
                <asp:LinkButton ID="lbtnreturn" runat="server" onclick="lbtnreturn_Click"  ForeColor="Red">继续挑选商品&gt;&gt;</asp:LinkButton>
            </td>
            <td style="text-align: right" class="style21">
                商品总价：<span class="style16">￥</span><asp:Label ID="lbtotalprice" runat="server" 
                    Font-Bold="True" ForeColor="#FF3300"></asp:Label></td>
            <td style="text-align: center" class="style22">
                
                <asp:LinkButton ID="lbtncancle" runat="server" ForeColor="#FF3300" 
                    onclick="lbtncancle_Click" >取消订单&lt;&lt;</asp:LinkButton>
                
            </td>
            <td style="text-align: right" class="style18">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:ImageButton ID="imgbtnjudge" runat="server" 
                    ImageUrl="~/Images/balance.gif" onclick="imgbtnjudge_Click" />
            </td>
        </tr>
    </table>
</asp:Content>

