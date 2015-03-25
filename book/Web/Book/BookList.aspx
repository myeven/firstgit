<%@ Page Language="C#" MasterPageFile="~/Master/User.master" AutoEventWireup="true" CodeFile="BookList.aspx.cs" Inherits="MemberShip_BookList" Title="第三波书店|图书列表" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style15
        {
            width: 100%;
           
        }
        .style21
        {
            height: 26px;
            text-align: right;
        }
        .style22
        {
            height: 26px;
            text-align: right;
            width: 313px;
        }
    .style23
    {
        width: 110px;
            height: 28px;
        }
    .style24
    {
        width: 75px;
            height: 28px;
        }
    .style26
    {
        width: 104px;
            height: 28px;
        }
     a:link,a:visited
     {
     text-decoration:none;  /*超链接无下划线*/
      }
     a:hover
     {
    text-decoration:underline;  /*鼠标放上去有下划线*/
     }
        .style16
        {
            width: 148px;
            text-align: center;
        }
        .style28
        {
            height: 27px;
        }
        .style29
        {
            height: 24px;
        }
        .style19
        {
            color: #FF3300;
        }       
        .style31
        {
            height: 28px;
        }
        .style32
        {
            height: 12px;
        }
        .style33
        {
            width: 98px;
            height: 28px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" Runat="Server">
    <table class="style15">
        <tr>
            <td class="style33">
                排序方式：&nbsp;
                </td>
            <td class="style24">
                <asp:Button ID="btnsortdate" runat="server" Text="按日期" 
                    onclick="btnsortdate_Click" BackColor="#BBE188" BorderColor="White" 
                    Font-Bold="False" Enabled="false" Height="22px" ForeColor="White"/>
            </td>
            <td class="style23">
                <asp:Button ID="btnsortprice" runat="server" Text="按价格" 
                    onclick="btnsortprice_Click" BackColor="#BBE188" BorderColor="White" 
                    Font-Bold="False" Height="22px" ForeColor="White" />
            </td>
            <td class="style26">
                <asp:DropDownList ID="ddlsort" runat="server" AutoPostBack="True" Height="22px" 
                    onselectedindexchanged="ddlsort_SelectedIndexChanged" Width="75px" >
                    <asp:ListItem Selected="True" Value="升序">--升序--</asp:ListItem>
                    <asp:ListItem Value="降序-">--降序--</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="style31" >
                <table class="style15">
                    <tr>
                        <td class="style22">
                            请输入关键字：</td>
                        <td class="style21">
                <asp:TextBox ID="txtsearch" runat="server" Height="16px"></asp:TextBox>
                        </td>
                        <td style="text-align:left">
                <asp:ImageButton ID="imgbtnsearch" runat="server" Height="22px" 
                    ImageUrl="~/Images/Search.jpg" onclick="imgbtnsearch_Click" Width="61px" />
                        </td>
                    </tr>
                </table>
                </td>
        </tr>
        <tr>
            <td colspan="5" style="text-align:center">
                <table style="width:100%">
                <tr>
                <td>
                    <asp:GridView ID="grvbooklist" runat="server" AllowPaging="True" 
                        AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" 
                        BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                        onpageindexchanging="grvbooklist_PageIndexChanging" ShowHeader="False" 
                        Width="100%" onrowcommand="grvbooklist_RowCommand">
                        <PagerSettings FirstPageText="第一页" LastPageText="最后一页" 
                            Mode="NextPreviousFirstLast" NextPageText="下一页" PreviousPageText="上一页" />
                        <RowStyle BackColor="White" ForeColor="#330099" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <table class="style15">
                                        <tr>
                                            <td class="style16" rowspan="5">
                                             <a href='<%# "../Book/BookDetail.aspx?BookId="+ Eval("Id") %>'>
                                                <asp:Image ID="Image1" runat="server" Height="118px" 
                                                    ImageUrl='<%# BindImg(Eval("ISBN"))%>' ToolTip='<%#Eval("Title") %>' 
                                                    Width="104px" />
                                            </a>
                                            </td>
                                            <td style="text-align: left">
                                                <a href='<%# "../Book/BookDetail.aspx?BookId="+ Eval("Id") %>'>
                                                <asp:Label ID="labbookname" runat="server" ForeColor="Red" 
                                                    Text='<%# Eval("Title") %>'>                                            </asp:Label>
                                                </a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style28" style="text-align: left">
                                                <asp:Label ID="labpublishdate" runat="server" 
                                                    Text='<%#FormatDate(Eval("PublishDate").ToString()) %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style29" style="text-align: left">
                                                <asp:Label ID="labauthor" runat="server" Text='<%#Eval("Author") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style29" style="text-align: left">
                                                <asp:Label ID="labdescription" runat="server" ForeColor="Black" 
                                                    Text='<%# Formatstring(Eval("ContentDescription").ToString(),150) %>' 
                                                    ToolTip='<%# Eval("ContentDescription") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style32" style="text-align: left">
                                                <span class="style19">￥</span><asp:Label ID="labprice" runat="server" 
                                                    ForeColor="Red" Text='<%# FormatPrice(Eval("UnitPrice").ToString()) %>'></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="style16">
                                                &nbsp;</td>
                                            <td style="text-align: right">
                                                <asp:ImageButton ID="ImageButton1" runat="server" 
                                                    ImageUrl="~/Images/sale.gif" CommandName="Buy" CommandArgument='<%#Eval("Id") %>' />
                                                &nbsp;&nbsp;&nbsp;
                                                </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                    </asp:GridView>
                    </td>
                </tr>
                <tr>
             <td >
                 &nbsp;</td>
          </tr>
                </table>
            </td>
        </tr>
        
    </table>
</asp:Content>

