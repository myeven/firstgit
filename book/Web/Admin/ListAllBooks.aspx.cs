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

public partial class Admin_ListAllBooks : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["adminuser"] != null)
            {
                ViewState["CategoryID"] = "";
                ViewState["Sort"] = "";
                ViewState["Search"] = "";
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
        #region 绑定GridView
        grvbooklist.DataSource = Bookmanager.GetBookListDataTable(ViewState["CategoryID"].ToString(), ViewState["Sort"].ToString(), ViewState["Search"].ToString());
        grvbooklist.DataBind();
        #endregion
    }
    public void BindDDL()
    {
        #region 绑定图书分类
        DataTable dtbookcategory = CategoriesManager.GetDataTableByCategories();
        GridViewHelp.BindDDL(dtbookcategory,ddlbooksort,"Name","Id");
        GridViewHelp.BindDDL(dtbookcategory, ddlnewcategory,"Name","Id");
        #endregion
    }
    public string BindImg(Object img)
    {
        #region 绑定图片

        if (img != null)
        {
            return "~/Images/BookCovers/" + img.ToString() + ".jpg";
        }
        else
        {
            return "~/Images/暂无图片.jpg";
        }
        #endregion
    }

    #region 全选 反选
    protected void btnall_Click(object sender, EventArgs e)
    {
        GridViewHelp.ALlCheck(grvbooklist, "cbok");
    }
    protected void btnresever_Click(object sender, EventArgs e)
    {
        GridViewHelp.InsteadCheck(grvbooklist,"cbok");
    }
    #endregion

    protected void btndelete_Click(object sender, EventArgs e)
    {
        #region 删除所选
        foreach (GridViewRow grv in grvbooklist.Rows)
        {
            CheckBox chb = (CheckBox)grv.FindControl("cbok");
            if (chb.Checked == true)
            {
                Bookmanager.DeleteBookById(Convert.ToInt32(grvbooklist.DataKeys[grv.RowIndex].Value));
            }
        }
        BindData();
        #endregion
    }
    protected void grvbooklist_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        #region 换页
        grvbooklist.PageIndex = e.NewPageIndex;
        BindData();
        #endregion
    }
    protected void grvbooklist_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        #region 删除图书
        if (e.CommandName == "BookDelete")
        {
            Bookmanager.DeleteBookById(Convert.ToInt32(e.CommandArgument));
            BindData();
        }
        #endregion

        #region 转到图书详情
        if (e.CommandName == "BookDetail")
        {
            Response.Redirect("BookAdd.aspx?BookId=" + Convert.ToInt32(e.CommandArgument));
        }
        #endregion
    }
    protected void imgbtnsearch_Click(object sender, ImageClickEventArgs e)
    {
        #region 根据关键字搜索图书
        ViewState["Search"] =txtsearch.Text;
        ViewState["CategoryID"] = ddlbooksort.SelectedItem.Value;
        BindData();
        #endregion
    }
    protected void ddlbooksort_SelectedIndexChanged(object sender, EventArgs e)
    {
        #region 根据图书类别搜索图书
        txtsearch.Text = "";
        ViewState["Search"] = txtsearch.Text;
        ViewState["CategoryID"] = ddlbooksort.SelectedItem.Value;
        BindData();
        #endregion
    }
    protected void btnremove_Click(object sender, EventArgs e)
    {
        #region 移动图书
        foreach (GridViewRow grv in grvbooklist.Rows)
        {
            CheckBox chb = (CheckBox)grv.FindControl("cbok");
            if (chb.Checked == true)
            {
                int bookid = Convert.ToInt32(grvbooklist.DataKeys[grv.RowIndex].Value);
                int categoryid = Convert.ToInt32(ddlnewcategory.SelectedValue);
                Books book=Bookmanager.GetBookDetailById(bookid);
                book.Categories = CategoriesManager.GetCategoriesById(categoryid);
                Bookmanager.EditBook(book);
            }
        }
        BindData();
        #endregion
    }
}
