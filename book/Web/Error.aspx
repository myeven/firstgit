<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Error.aspx.cs" Inherits="Error" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>出错啦</title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            height: 362px;
        }
    </style>
</head>
<body >
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2" style="text-align: center">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Error.jpg" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
