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

public partial class Admin_UserList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["adminuser"] != null)
            {
                BindData();
                BindDDL();
            }
            else
            {
                Response.Redirect("AdminLogin.aspx");
            }
        }
    }
    public void BindData()
    {
        #region 初始化数据
        string Search = "";
        if (txtsearch.Text != "")
        {
            Search = txtsearch.Text.Trim();
        }
        grvuserlist.DataSource = UserManager.GetAllUsers(Search);
        grvuserlist.DataBind();
        #endregion
    }
    public void BindDDL()
    {
        #region 绑定用户角色
        DataTable dtuserrole = UserRoleManager.GetAllUserRoles();
        GridViewHelp.BindDDL(dtuserrole, dluserrole,"Name","Id");
        #endregion
    }
    protected void btnno_Click(object sender, EventArgs e)
    {
        #region 批量禁用用户
        foreach (GridViewRow grv in grvuserlist.Rows)
        {
            CheckBox chb = (CheckBox)grv.FindControl("cbok");
            if (chb.Checked == true)
            {
                Users user = UserManager.GetUserById(Convert.ToInt32(grvuserlist.DataKeys[grv.RowIndex].Value));
                user.UserStates = UserStateManager.GetUserStatesById(2);
                UserManager.UpdateUser(user);
            }
        }
        BindData();
        #endregion
    }
    protected void btnallow_Click(object sender, EventArgs e)
    {
        #region 批量启用用户
        foreach (GridViewRow grv in grvuserlist.Rows)
        {
            CheckBox chb = (CheckBox)grv.FindControl("cbok");
            if (chb.Checked == true)
            {
                Users user = UserManager.GetUserById(Convert.ToInt32(grvuserlist.DataKeys[grv.RowIndex].Value));
                user.UserStates = UserStateManager.GetUserStatesById(1);
                UserManager.UpdateUser(user);
            }
        }
        BindData();
        #endregion
    }
    protected void imgbtnsearch_Click(object sender, ImageClickEventArgs e)
    {
        BindData();//搜索
    }
    protected void grvuserlist_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "UserDetail")
        {   
            #region 转到用户详细信息
            Response.Redirect("UserDetail.aspx?UserId="+e.CommandArgument);
            #endregion
        }
        if (e.CommandName == "UserState")
        {
            #region 更改用户状态
            int userId = Convert.ToInt32(e.CommandArgument);
            Users user = UserManager.GetUserById(userId);
            if (user.UserStates.Id == 1)
            {
                user.UserStates.Id = 2;
            }
            else
            {
                user.UserStates.Id = 1;
            }
            user.UserStates = UserStateManager.GetUserStatesById(user.UserStates.Id);
            UserManager.UpdateUser(user);
            BindData();
            #endregion
        }
    }
    protected void dluserrole_SelectedIndexChanged(object sender, EventArgs e)
    {
        #region 选择用户角色
        string Search = dluserrole.SelectedItem.Text;
        grvuserlist.DataSource = UserManager.GetAllUsers(Search);
        grvuserlist.DataBind();
        #endregion
    }
    protected void grvuserlist_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        #region 换页
        grvuserlist.PageIndex = e.NewPageIndex;
        BindData();
        #endregion
    }

    #region 全选 反选 删除所选

    protected void btnall_Click(object sender, EventArgs e)
    {
        GridViewHelp.ALlCheck(grvuserlist, "cbok");        
    }
    protected void btnresever_Click(object sender, EventArgs e)
    {
        GridViewHelp.InsteadCheck(grvuserlist, "cbok");  
    }
    protected void btndelete_Click(object sender, EventArgs e)
    {
       
        foreach (GridViewRow grv in grvuserlist.Rows)
        {
            CheckBox chb = (CheckBox)grv.FindControl("cbok");
            if (chb.Checked == true)
            {
                UserManager.DeleteUserById(Convert.ToInt32(grvuserlist.DataKeys[grv.RowIndex].Value));
            }
        }
        BindData();
    }
    #endregion
}
