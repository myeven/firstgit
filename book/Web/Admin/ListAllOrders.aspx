<%@ Page Language="C#" MasterPageFile="~/Master/Admin.master" AutoEventWireup="true" CodeFile="ListAllOrders.aspx.cs" Inherits="Admin_ListAllOrders" Title="��������� �����б�" %>

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
                ��ѡ�񶩵�����ֹ���ڣ�</td>
            <td style="text-align: left" class="style14">
                <asp:TextBox ID="txtstardate" runat="server" onclick="WdatePicker()"></asp:TextBox>
                ��<asp:TextBox ID="txtenddate" runat="server" onclick="WdatePicker()"></asp:TextBox>&nbsp;&nbsp;&nbsp; <asp:Button 
                    ID="btnsearch" runat="server" Text="��ѯ" onclick="btnsearch_Click" />
                <asp:Label ID="labmessage" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="gvorderlist" runat="server" AutoGenerateColumns="False" 
                    onrowcommand="gvorderlist_RowCommand" DataKeyNames="Id" Width="80%" 
                    AllowPaging="True" onpageindexchanging="gvorderlist_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField HeaderText="���">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Container.DataItemIndex+1 %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="�û���" DataField="UserName" />
                        <asp:BoundField HeaderText="�����ܼ�" DataField="TotalPrice" />
                        <asp:BoundField HeaderText="��������" DataField="OrderDate" />
                        <asp:TemplateField HeaderText="����">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtndetail" runat="server" CommandName="lbtndetail" CommandArgument='<%#Eval("Id") %>'>��������</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="����">
                        <ItemTemplate>
                                <asp:LinkButton ID="lbtndelete" runat="server" OnClientClick="javascript:return confirm('ȷ��ɾ����')" CommandName="lbtndelete" CommandArgument='<%#Eval("Id") %>'>ɾ������</asp:LinkButton>
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

