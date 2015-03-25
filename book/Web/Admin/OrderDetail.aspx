<%@ Page Language="C#" MasterPageFile="~/Master/Admin.master" AutoEventWireup="true" CodeFile="OrderDetail.aspx.cs" Inherits="Admin_OrderDetail" Title="第三波书店 订单详情" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style12
        {
            width: 100%;
        }
        .style13
        {
            width: 773px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style12">
        <tr>
            <td style="text-align: left">
                &nbsp;</td>
            <td style="text-align: left" class="style13">
                <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="lbntreturn" runat="server" onclick="lbntreturn_Click">返回查看其它订单</asp:LinkButton>
                <br />
                <br />
            </td>
            <td style="text-align: left">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="style13">
                <asp:GridView ID="gvorderdetail" runat="server" AutoGenerateColumns="False" 
                    onpageindexchanging="gvorderdetail_PageIndexChanging" Width="90%">
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="订单人" />
                        <asp:TemplateField HeaderText="图书封面">
                            <ItemTemplate>
                                <asp:Image ID="Image1" runat="server" Height="50px" Width="46px" ImageUrl='<%#"~/Images/BookCovers/"+Eval("ISBN")+".jpg" %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Title" HeaderText="书名" />
                        <asp:BoundField DataField="Quantity" HeaderText="数量" />
                        <asp:BoundField DataField="UnitPrice" HeaderText="单价" >
                            <ControlStyle BorderColor="#FF3300" ForeColor="Red" />
                        </asp:BoundField>
                        <asp:BoundField DataField="OrderDate" HeaderText="订单日期" />
                    </Columns>
                </asp:GridView>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="style13">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

