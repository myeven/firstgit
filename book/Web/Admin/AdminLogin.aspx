<%@ Page Language="C#" Theme="login" AutoEventWireup="true" CodeFile="AdminLogin.aspx.cs" Inherits="login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>第三波书店|后台管理系统登录</title>
<style type="text/css">
<!--
body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
	background-color: #016aa9;
	overflow:hidden;
}
.login {
	color: #000000;
	font-size: 12px;
	text-align:right;
}
-->
</style>

</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align:center">
    <table style="width:100%;height:100%;" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td><table style="width:931px; text-align:center;"border="0" cellpadding="0" 
            cellspacing="0">
      <tr>
        <td  style="height:235px; background-image:url(../Images/Admin/login_03.gif)">&nbsp;</td>
      </tr>
      <tr>
        <td style="height:53px"><table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td style="height:53px;width:394px;background-image:url(../Images/Admin/login_05.gif)" >
                &nbsp;</td>
            <td style="width:206px;background-image:url(../Images/Admin/login_06.gif)">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td style="height:25px;width:16%;" ><div class="login" >用户</div></td>
                    <td style="height:25px;width:57%;" >
                        <asp:TextBox ID="txtUserName" runat="server"  ></asp:TextBox>
                    </td>
                    <td style="height:25px;width:27%;">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*用户名"
                            ValidationGroup="v1" ControlToValidate="txtUserName" Font-Size="Small"></asp:RequiredFieldValidator></td>
                  </tr>
                  <tr>
                    <td style="height:25px;"><div class="login" >密码</div></td>
                    <td style="height:25px;">
                        <asp:TextBox ID="txtpwd" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                    <td style="height:25px;">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*密码"
                            ValidationGroup="v1" ControlToValidate="txtpwd" Font-Size="Small"></asp:RequiredFieldValidator></td>
                  </tr>
                </table>
                </td>
            <td style="width:362px;background-image:url(../Images/Admin/login_07.gif)">&nbsp;</td>
          </tr>
        </table></td>
      </tr>
      <tr>
		<td>
			<table border="0" cellpadding="0" cellspacing="0" width="962">
			  <tr>
			   <td><img  src="../Images/Admin/login_08_r1_c1.gif" width="432" height="48"  id="Img2" alt="" /></td>
			   <td valign="top" style="width:362px;background-image:url(../Images/Admin/login_08_r1_c2.gif);text-align:left;">
                   <asp:CheckBox ID="cbok" runat="server" Text="记住密码" />
                   <br />
                   <asp:ImageButton ID="imgbtnlogin" runat="server" ImageUrl="../Images/Admin/dl.gif" 
                       OnClick="imgbtnlogin_Click" ValidationGroup="v1" />&nbsp;
                   <asp:ImageButton ID="imgbtnreset" runat="server" ImageUrl="../Images/Admin/cz.gif" 
                       onclick="imgbtnreset_Click" style="height: 18px" />&nbsp;
				    <asp:Label ID="labmessage" runat="server" 
                       style="font-size: 12px; color:Red; margin:0px; vertical-align:middle;"></asp:Label>
			   </td>
			  </tr>
			  <tr>
				   <td>
						<img  src="../Images/Admin/login_08_r2_c1.gif" width="432" height="165"  id="Img4" alt="" />
				   </td>
				   <td>
						<img src="../Images/Admin/login_08_r2_c2.gif" width="530" height="165"  id="Img5" alt="" />
				   </td>
			  </tr>
			</table>
		
		</td> 
      </tr>
    </table></td>
  </tr>
</table>
    </div>          
    </form>
</body>
</html>



