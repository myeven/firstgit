<%@ Page Language="C#" MasterPageFile="~/Master/Admin.master" AutoEventWireup="true" CodeFile="BookCategoryAdd.aspx.cs" Inherits="Admin_BookCategoryAdd" Title="��������� ͼ������б�" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style12
        {
            width: 100%;
        }
        .style13
        {
            width: 591px;
            text-align: left;
        }
        .style14
        {
            width: 86px;
            text-align: left;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style12">
        <tr>
            <td class="style14">
                &nbsp;</td>
            <td class="style13">
               
                    <asp:Button ID="btnadd" runat="server" Text="���ͼ�����" onclick="btnadd_Click" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                </td>
            <td>
               
                    &nbsp;<asp:Panel ID="Panel1" runat="server" style="text-align: left" 
                        Visible="False">
                        <br />
                        <asp:TextBox ID="txtbookcategory" runat="server"></asp:TextBox>
                        <asp:Button ID="btnok" runat="server" onclick="btnok_Click" Text="ȷ��" 
                            ValidationGroup="a" />
                        &nbsp;&nbsp;
                        <asp:Button ID="btncancle" runat="server" CausesValidation="False" 
                            onclick="btncancle_Click" style="width: 40px" Text="ȡ��" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="txtbookcategory" ErrorMessage="�������Ʋ���Ϊ��" 
                            ValidationGroup="a"></asp:RequiredFieldValidator>
                    </asp:Panel>
                    <br />
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="style14">
                &nbsp;</td>
            <td class="style13" style="text-align:center">
                <asp:GridView ID="grvbookcategorylist" runat="server" 
                    AutoGenerateColumns="False" Width="60%" DataKeyNames="Id" 
                    onrowcommand="grvbookcategorylist_RowCommand" AllowPaging="True" 
                    onpageindexchanging="grvbookcategorylist_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField HeaderText="���">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Container.DataItemIndex+1 %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Name" HeaderText="��������" />
                        <asp:TemplateField HeaderText="����">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbedit" runat="server" CommandArgument='<%#Eval("Id") %>' CommandName="editcategory">�༭</asp:LinkButton>
                                &nbsp;&nbsp;|&nbsp;&nbsp;
                                <asp:LinkButton ID="lbdelete" runat="server" CommandArgument='<%#Eval("Id") %>' CommandName="deletecategory" OnClientClick="javascript:return confirm('ȷ��ɾ����')">ɾ��</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>                    
                    </Columns>
                </asp:GridView>
            </td>
            <td>
              <div id="mydiv" runat="server" 
                    style="border-style: groove; position:absolute; top:279px; left:550px; text-align:center; height: 110px; width: 290px; background-color:#BBE188;" 
                    visible="false">
               <br />
               <p style="color:Red">��ͼ��������Ѿ�����ͼ�鲻�ܱ�ɾ��,</br>��ɾ���÷���������ͼ������ɾ��</p> 
               <br />
               <asp:Button ID="btnyes" runat="server" Text="ȷ��" BackColor="White" onclick="btnyes_Click"/>
              </div>  
            </td>
        </tr>
    </table>
</asp:Content>

