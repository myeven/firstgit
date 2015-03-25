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

public partial class Admin_UserDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["adminuser"] != null)
            {
                ViewState["UserId"] = Request.QueryString["UserId"];
                BindData();
                BindRbl();
            }
            else
            {
                Response.Redirect("AdminLogin.aspx");
            }
            
        }
    }
    public void BindData()
    {
        Users user = UserManager.GetUserById(Convert.ToInt32(ViewState["UserId"]));
        this.txtLoginId.Text = user.LoginId;
        this.txtname.Text = user.Name;
        this.txtaddress.Text = user.Address;
        this.txtmail.Text = user.Mail;
        this.txtphone.Text = user.Phone;
        this.txtpwd.Text = user.LoginPwd;
    }
    public void BindRbl()
    {
        #region 绑定用户角色

        Users user = UserManager.GetUserById(Convert.ToInt32(ViewState["UserId"]));
        DataTable dtuserrole = UserRoleManager.GetAllUserRoles();
        GridViewHelp.BindRBL(dtuserrole, rbtnlistuserrole, "Name", "Id");

        foreach (ListItem lt in rbtnlistuserrole.Items)
        {
            if (lt.Text == user.UserRoles.Name)
            {
                lt.Selected = true;
            }
        }

        #endregion

        #region 绑定用户状态

        DataTable dtuserstate = UserStateManager.GetAllUserState();
        GridViewHelp.BindRBL(dtuserstate,rbtnlistuserstate, "Name", "Id");

        foreach (ListItem lt in rbtnlistuserstate.Items)
        {
            if (lt.Text == user.UserStates.Name)
            {
                lt.Selected = true;
            }
        }

        #endregion
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        #region 更新用户信息
        Users user = new Users();
        user.ID = Convert.ToInt32(ViewState["UserId"]);
        user.LoginId = this.txtLoginId.Text.Trim();
        user.Mail = this.txtmail.Text.Trim();
        user.Name = this.txtname.Text.Trim();
        user.Phone = this.txtphone.Text.Trim();
        user.Address = this.txtaddress.Text.Trim();
        user.LoginPwd = this.txtpwd.Text.Trim();
        foreach (ListItem lt in rbtnlistuserstate.Items)
        {
            if (lt.Selected == true)
            {
                user.UserStates = UserStateManager.GetUserStatesById(Convert.ToInt32(lt.Value));
            }
        }
        foreach (ListItem lt in rbtnlistuserrole.Items)
        {
            if (lt.Selected == true)
            {
                user.UserRoles = UserRoleManager.GetUserRolesById(Convert.ToInt32(lt.Value));
            }
        }
        if (UserManager.UpdateUser(user))
        {
            Response.Redirect("ListAllUsers.aspx");
        }
        else
        {
            Response.Write("<script>alert('更新失败')</script>");
        }
        #endregion
    }
}
