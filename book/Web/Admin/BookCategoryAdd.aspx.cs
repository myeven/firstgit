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
using System.Data.SqlClient;
using BookShopBLL;
using BookShopModels;

public partial class Admin_BookCategoryAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["adminuser"] != null)
            {
                BindData();
            }
            else
            {
                Response.Redirect("AdminLogin.aspx");
            }
        }
    }
    public void BindData()
    {
        #region 绑定GridView
        DataTable dt = CategoriesManager.GetDataTableByCategories();
        grvbookcategorylist.DataSource = dt;       
        grvbookcategorylist.DataBind();
        #endregion
    }
    protected void grvbookcategorylist_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "editcategory")
        {
            #region 编辑
            Panel1.Visible = true;
            ViewState["operate"] = "edit";
            Categories category = CategoriesManager.GetCategoriesById(Convert.ToInt32(e.CommandArgument));
            txtbookcategory.Text = category.Name;
            #endregion
        }
        if (e.CommandName == "deletecategory")
        {
            #region 删除
            ViewState["CategoryId"] = e.CommandArgument;
            if (CategoriesManager.FindCategoryIsBook(Convert.ToInt32(ViewState["CategoryId"])))
            {
                CategoriesManager.DeleteCategoryById(Convert.ToInt32(ViewState["CategoryId"]));
            }
            else
            {
                mydiv.Visible = true;
            }
            BindData();
            #endregion
        }
    }  
    protected void btnok_Click(object sender, EventArgs e)
    {
        if (ViewState["operate"].ToString() == "edit")
        {
            #region 更新
            Categories category = CategoriesManager.GetCategoriesById(Convert.ToInt32(ViewState["categoryId"]));
            category.Name = txtbookcategory.Text.Trim();
            CategoriesManager.UpdateCategory(category);
            Panel1.Visible = false;
            BindData();
            #endregion
        }
        else
        {
            #region 添加
            CategoriesManager.AddCategory(txtbookcategory.Text);
            Panel1.Visible = false;
            BindData();
            #endregion
        }
    }
    protected void btncancle_Click(object sender, EventArgs e)
    {
        #region 取消
        txtbookcategory.Text = "";
        Panel1.Visible = false;
        #endregion
    }
    protected void btnadd_Click(object sender, EventArgs e)
    {
        #region 添加
        Panel1.Visible = true;
        ViewState["operate"] = "add";
        #endregion
    }
    protected void btnyes_Click(object sender, EventArgs e)
    {
        mydiv.Visible = false;
    }
    protected void grvbookcategorylist_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvbookcategorylist.PageIndex = e.NewPageIndex;
        BindData();
    }
}
