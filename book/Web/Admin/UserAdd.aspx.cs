using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using BookShopBLL;
using BookShopModels;

public partial class Admin_UserAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["adminuser"] != null)
            {
                ViewState["UserId"] = Request.QueryString["UserId"];
                BindDDL();
            }
            else
            {
                Response.Redirect("AdminLogin.aspx");
            }
        }
    }
    public void BindDDL()
    {
        #region 绑定用户角色和状态
        DataTable dtuserrole = UserRoleManager.GetAllUserRoles();
        GridViewHelp.BindDDL(dtuserrole, ddluserrole,"Name","Id");
      
        DataTable dtuserstate = UserStateManager.GetAllUserState();
        GridViewHelp.BindDDL(dtuserstate,ddluserstate,"Name","Id");
        #endregion
    }
    protected void btnadd_Click(object sender, EventArgs e)
    {
        #region 注册用户
        Users user = new Users();
        user.LoginId = txtLoginId.Text;
        user.LoginPwd = txtpwd.Text;
        user.Mail = txtmail.Text;
        user.Name = txtname.Text;
        user.Phone = txtphone.Text;
        user.Address = txtaddress.Text;
        foreach (ListItem lt in ddluserstate.Items)
        {
            if (lt.Selected == true)
            {
                user.UserStates =UserStateManager.GetUserStatesById( Convert.ToInt32(lt.Value));
            }
        }
        foreach (ListItem lt in ddluserrole.Items)
        {
            if (lt.Selected == true)
            {
                user.UserRoles= UserRoleManager.GetUserRolesById(Convert.ToInt32(lt.Value));

            }
        }
        if (UserManager.UserReg(user))
        {
            Response.Redirect("ListAllUsers.aspx");
        }
        else
        {
            labmessage.Text = "该用户名已被注册，请选择其他用户名";
        }
        #endregion
    }
}
