<%@ Page Language="C#" MasterPageFile="~/Master/User.master" AutoEventWireup="true" CodeFile="RedactMyOrder.aspx.cs" Inherits="Book_RedactMyOrder" Title="第三波书店 订单结算" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style15
        {
            width: 100%;
        }
        .style16
        {
            width: 74%;
        }
        .style18
        {
            text-align: right;
            color: #FF3300;
        }
        .style19
        {
            width: 321px;
        }
        .style20
        {
            width: 75px;
        }
        .style21
        {
            width: 102px;
        }
        .style23
        {
            color: #FF9966;
            font-weight: bold;
            font-size: large;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" Runat="Server">
    <table class="style15">
        <tr>
            <td class="style19">
                <table align="left" class="style16">
                    <tr>
                        <td colspan="2" class="style23">
                            收货人信息</td>
                    </tr>
                    <tr>
                        <td class="style21" style="text-align: right">
                            收货人：</td>
                        <td class="style20">
                            <asp:Label ID="labname" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style21" style="text-align: right">
                            地址：</td>
                        <td class="style20">
                            <asp:Label ID="labaddress" runat="server" ></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style21" style="text-align: right">
                            邮箱：</td>
                        <td class="style20">
                            <asp:Label ID="labmail" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style21" style="text-align: right">
                            联系电话：</td>
                        <td class="style20">
                            <asp:Label ID="labphone" runat="server" ></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                <asp:Label ID="labmessage" runat="server" BackColor="#FFFF66" 
                    Font-Size="X-Large" ForeColor="Red"></asp:Label>
                                                    </td>
        </tr>
        <tr>
            <td colspan="2">
                <table class="style15">
                    <tr>
                        <td colspan="2" class="style23">
                            商品清单</td>
                    </tr>
                    <tr>
                        <td>
                            商家：第三波书店</td>
                        <td style="text-align: right">
                            <asp:LinkButton ID="lbtnreturn" runat="server" onclick="lbtnreturn_Click">返回购物车添加或删除商品</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align:center" colspan="2">
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
                </table>
            </td>
        </tr>
        <tr>
            <td class="style18" colspan="2">
                商品金额总计：￥<asp:Label ID="labtotalprice" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style18" colspan="2">
                <asp:Panel ID="Panel1" runat="server" Visible="false">
                    您是VIP会员可享受九折优惠:￥<asp:Label ID="labsaleprice" runat="server" ></asp:Label>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="text-align: right" colspan="2">
                <asp:ImageButton ID="imgbtnok" runat="server" ImageUrl="~/Images/Ok_2.jpg" 
                    onclick="imgbtnokClick" />
            </td>
        </tr>
    </table>
</asp:Content>

