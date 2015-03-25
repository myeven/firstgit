using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using BookShopModels;
using BookShopBLL;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Cookies["UserName"] != null && Request.Cookies["Pwd"] != null)
            {
                cbok.Checked = true;
                txtUserName.Text = Request.Cookies["UserName"].Value;
                txtpwd.Attributes.Add("value", Request.Cookies["Pwd"].Value);
            }
        }
    }
    protected void imgbtnlogin_Click(object sender, ImageClickEventArgs e)
    {
        #region 登陆

        Users user = UserManager.Login(txtUserName.Text, txtpwd.Text);
        if (user == null)
        {
            labmessage.Text = "输入的用户名或密码错误";
        }
        else
        {
            if (user.UserRoles.Id == 3)
            {
                if (user.UserStates.Id == 1)
                {
                    if (cbok.Checked == true)
                    {
                        Response.Cookies["UserName"].Value = txtUserName.Text;
                        Response.Cookies["Pwd"].Value = txtpwd.Text;
                        Response.Cookies["UserName"].Expires = DateTime.MaxValue;
                        Response.Cookies["Pwd"].Expires = DateTime.MaxValue;
                    }
                    else
                    {
                        Response.Cookies["UserName"].Expires = DateTime.MinValue;
                        Response.Cookies["Pwd"].Expires = DateTime.MinValue;
                    }
                    Session["adminuser"] = user;
                    Response.Redirect("AdminMain.aspx");
                }
                else
                {
                    labmessage.Text = "您的账号已被禁用";
                }
            }
            else
            {
                labmessage.Text = "您没有访问权限";
            }
        }
       #endregion
    }
                        
    protected void imgbtnreset_Click(object sender, ImageClickEventArgs e)
    {
        txtpwd.Text = "";
        txtUserName.Text = "";
    } 
}