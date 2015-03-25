<%@ Page Language="C#" MasterPageFile="~/Master/Admin.master" AutoEventWireup="true" CodeFile="BookAdd.aspx.cs" Inherits="Admin_BookAdd" Title="��������� ͼ�����" validateRequest="false"%>

<%@ Register assembly="FreeTextBox" namespace="FreeTextBoxControls" tagprefix="FTB" %>

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

    <script src="../Control/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <table style="width:96%;border:1px solid #BBE188;border-collapse:collapse">
        <tr>
            <td class="tdright">
                ������</td>
                                                 <td class="tdleft">
                                                     <asp:TextBox ID="txttitle" runat="server"></asp:TextBox>
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                         ErrorMessage="*��Ϊ��" ControlToValidate="txttitle"></asp:RequiredFieldValidator>
                                                 </td>
                                             </tr>
                                             <tr>
                                                 <td class="tdright">
                                                     ���ߣ�</td>
                                                 <td class="tdleft">
                                                     <asp:TextBox ID="txtauthor" runat="server"></asp:TextBox>
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                         ErrorMessage="*��Ϊ��" ControlToValidate="txtauthor"></asp:RequiredFieldValidator>
                                                 </td>
                                             </tr>
                                             <tr>
                                                 <td class="tdright">
                                                     ͼ�����</td>
                                                 <td class="tdleft">
                                                     <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/����ͼƬ.jpg" 
                                                         Height="120px" Width="100px" />
                                                     <asp:FileUpload ID="FileUploadimg" runat="server" />
                                                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="labimessage" runat="server" ForeColor="Red" Font-Size="X-Large"></asp:Label>
                                                 </td>
                                             </tr>
                                             <tr>
                                                 <td class="tdright">
                                                     �۸�</td>
                                                 <td class="tdleft">
                                                     <asp:TextBox ID="txtprice" runat="server"></asp:TextBox>
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                                         ErrorMessage="*��Ϊ��" ControlToValidate="txtprice" Display="Dynamic"></asp:RequiredFieldValidator>
                                                     <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                                         ErrorMessage="�۸��ʽ����ȷ" ControlToValidate="txtprice" 
                                                         Operator="DataTypeCheck" Type="Double"></asp:CompareValidator>
                                                 </td>
                                             </tr>
                                             <tr>
                                                 <td class="tdright">
                                                     ��������</td>
                                                 <td class="tdleft">
                                                     <asp:DropDownList ID="ddlcategory" runat="server">
                                                     </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                    ErrorMessage="*��Ϊ��" ControlToValidate="ddlcategory" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
                                                 </td>
                                             </tr>
                                             <tr>
                                                 <td class="tdright">
                                                     �����磺</td>
            <td class="tdleft">
                <asp:DropDownList ID="ddlpublisher" runat="server">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                    ErrorMessage="*��Ϊ��" ControlToValidate="ddlpublisher" Display="Dynamic" 
                    InitialValue="0"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="tdright">
                ISBN��</td>
            <td class="tdleft">
                <asp:TextBox ID="txtISBN" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ErrorMessage="*��Ϊ��" ControlToValidate="txtISBN" Display="Dynamic"></asp:RequiredFieldValidator>
                                                     <asp:CompareValidator ID="CompareValidator3" runat="server" 
                                                         ErrorMessage="*ISBNӦΪ����" 
                    ControlToValidate="txtISBN" Operator="DataTypeCheck" Type="Integer" 
                    Display="Dynamic"></asp:CompareValidator>
                <asp:Label ID="labisbnmessage" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="tdright">
                ����������</td>
            <td class="tdleft">
                <asp:TextBox ID="txtcount" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ErrorMessage="*��Ϊ��" ControlToValidate="txtcount" Display="Dynamic"></asp:RequiredFieldValidator>
                                                     <asp:CompareValidator ID="CompareValidator2" runat="server" 
                                                         ErrorMessage="*����ӦΪ����" 
                    ControlToValidate="txtcount" Operator="DataTypeCheck" Type="Integer" 
                    Display="Dynamic"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td class="tdright">
                �������ڣ�</td>
            <td class="tdleft">
                <asp:TextBox ID="txtpublishdate" runat="server" onclick="WdatePicker()"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                    ErrorMessage="*��Ϊ��" ControlToValidate="txtpublishdate"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="tdright">
                Ŀ¼��</td>
            <td class="tdleft">
                <FTB:FreeTextBox ID="ftbtoc" runat="server" ButtonPath="../FreeTextBox/ftb/officeXP/">
                </FTB:FreeTextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                    ErrorMessage="*��Ϊ��" ControlToValidate="ftbtoc"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="tdright">
                ���ݼ�飺</td>
                                                 <td class="tdleft">
                                                     <asp:TextBox ID="txtcontentdescription" runat="server" TextMode="MultiLine" 
                                                         Height="80px" Width="272px"></asp:TextBox>
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                                         ErrorMessage="*��Ϊ��" ControlToValidate="txtcontentdescription"></asp:RequiredFieldValidator>
                                                 </td>
                                             </tr>
                                             <tr>
                                                 <td class="tdright">
                                                     ���߼�飺</td>
                                                 <td class="tdleft">
                                                     <asp:TextBox ID="authordescription" runat="server" TextMode="MultiLine" 
                                                         Height="88px" Width="269px"></asp:TextBox>
                                                 </td>
                                             </tr>
                                             <tr>
                                                 <td class="tdright">
                                                     �����Ƽ���</td>
                                                 <td class="tdleft">
                                                     <asp:TextBox ID="txtrecommand" runat="server" TextMode="MultiLine" Height="88px" Width="269px"></asp:TextBox>
                                                 </td>
                                             </tr>
                                             <tr>
                                                 <td class="tdright">
                                                     &nbsp;</td>
            <td class="tdleft">
                <asp:Button ID="btnok" runat="server" Text="ȷ��" onclick="btnok_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btncancle" runat="server" Text="ȡ��" CausesValidation="False" 
                    onclick="btncancle_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
        </tr>
    </table>
</asp:Content>

