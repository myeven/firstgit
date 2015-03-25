<%@ Page Language="C#" MasterPageFile="~/Master/Admin.master" AutoEventWireup="true" CodeFile="BookAdd.aspx.cs" Inherits="Admin_BookAdd" Title="第三波书店 图书添加" validateRequest="false"%>

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
                书名：</td>
                                                 <td class="tdleft">
                                                     <asp:TextBox ID="txttitle" runat="server"></asp:TextBox>
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                         ErrorMessage="*不为空" ControlToValidate="txttitle"></asp:RequiredFieldValidator>
                                                 </td>
                                             </tr>
                                             <tr>
                                                 <td class="tdright">
                                                     作者：</td>
                                                 <td class="tdleft">
                                                     <asp:TextBox ID="txtauthor" runat="server"></asp:TextBox>
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                         ErrorMessage="*不为空" ControlToValidate="txtauthor"></asp:RequiredFieldValidator>
                                                 </td>
                                             </tr>
                                             <tr>
                                                 <td class="tdright">
                                                     图书封面</td>
                                                 <td class="tdleft">
                                                     <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/暂无图片.jpg" 
                                                         Height="120px" Width="100px" />
                                                     <asp:FileUpload ID="FileUploadimg" runat="server" />
                                                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="labimessage" runat="server" ForeColor="Red" Font-Size="X-Large"></asp:Label>
                                                 </td>
                                             </tr>
                                             <tr>
                                                 <td class="tdright">
                                                     价格：</td>
                                                 <td class="tdleft">
                                                     <asp:TextBox ID="txtprice" runat="server"></asp:TextBox>
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                                         ErrorMessage="*不为空" ControlToValidate="txtprice" Display="Dynamic"></asp:RequiredFieldValidator>
                                                     <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                                         ErrorMessage="价格格式不正确" ControlToValidate="txtprice" 
                                                         Operator="DataTypeCheck" Type="Double"></asp:CompareValidator>
                                                 </td>
                                             </tr>
                                             <tr>
                                                 <td class="tdright">
                                                     分类名：</td>
                                                 <td class="tdleft">
                                                     <asp:DropDownList ID="ddlcategory" runat="server">
                                                     </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                    ErrorMessage="*不为空" ControlToValidate="ddlcategory" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
                                                 </td>
                                             </tr>
                                             <tr>
                                                 <td class="tdright">
                                                     出版社：</td>
            <td class="tdleft">
                <asp:DropDownList ID="ddlpublisher" runat="server">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                    ErrorMessage="*不为空" ControlToValidate="ddlpublisher" Display="Dynamic" 
                    InitialValue="0"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="tdright">
                ISBN：</td>
            <td class="tdleft">
                <asp:TextBox ID="txtISBN" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ErrorMessage="*不为空" ControlToValidate="txtISBN" Display="Dynamic"></asp:RequiredFieldValidator>
                                                     <asp:CompareValidator ID="CompareValidator3" runat="server" 
                                                         ErrorMessage="*ISBN应为整数" 
                    ControlToValidate="txtISBN" Operator="DataTypeCheck" Type="Integer" 
                    Display="Dynamic"></asp:CompareValidator>
                <asp:Label ID="labisbnmessage" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="tdright">
                文章字数：</td>
            <td class="tdleft">
                <asp:TextBox ID="txtcount" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ErrorMessage="*不为空" ControlToValidate="txtcount" Display="Dynamic"></asp:RequiredFieldValidator>
                                                     <asp:CompareValidator ID="CompareValidator2" runat="server" 
                                                         ErrorMessage="*字数应为整数" 
                    ControlToValidate="txtcount" Operator="DataTypeCheck" Type="Integer" 
                    Display="Dynamic"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td class="tdright">
                出版日期：</td>
            <td class="tdleft">
                <asp:TextBox ID="txtpublishdate" runat="server" onclick="WdatePicker()"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                    ErrorMessage="*不为空" ControlToValidate="txtpublishdate"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="tdright">
                目录：</td>
            <td class="tdleft">
                <FTB:FreeTextBox ID="ftbtoc" runat="server" ButtonPath="../FreeTextBox/ftb/officeXP/">
                </FTB:FreeTextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                    ErrorMessage="*不为空" ControlToValidate="ftbtoc"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="tdright">
                内容简介：</td>
                                                 <td class="tdleft">
                                                     <asp:TextBox ID="txtcontentdescription" runat="server" TextMode="MultiLine" 
                                                         Height="80px" Width="272px"></asp:TextBox>
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                                         ErrorMessage="*不为空" ControlToValidate="txtcontentdescription"></asp:RequiredFieldValidator>
                                                 </td>
                                             </tr>
                                             <tr>
                                                 <td class="tdright">
                                                     作者简介：</td>
                                                 <td class="tdleft">
                                                     <asp:TextBox ID="authordescription" runat="server" TextMode="MultiLine" 
                                                         Height="88px" Width="269px"></asp:TextBox>
                                                 </td>
                                             </tr>
                                             <tr>
                                                 <td class="tdright">
                                                     编者推荐：</td>
                                                 <td class="tdleft">
                                                     <asp:TextBox ID="txtrecommand" runat="server" TextMode="MultiLine" Height="88px" Width="269px"></asp:TextBox>
                                                 </td>
                                             </tr>
                                             <tr>
                                                 <td class="tdright">
                                                     &nbsp;</td>
            <td class="tdleft">
                <asp:Button ID="btnok" runat="server" Text="确定" onclick="btnok_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btncancle" runat="server" Text="取消" CausesValidation="False" 
                    onclick="btncancle_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
        </tr>
    </table>
</asp:Content>

