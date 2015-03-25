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

public partial class Admin_ListAllOrders : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["adminuser"] != null)
            {
                ViewState["stardate"] = "";
                ViewState["enddate"] = "";
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
        #region 绑定信息
        gvorderlist.DataSource = OrderManager.GetAllOrders(ViewState["stardate"].ToString(), ViewState["enddate"].ToString());
        gvorderlist.DataBind();
        #endregion
    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        #region 根据起止日期查询订单
        labmessage.Text = "";
        if (txtstardate.Text != "" && txtenddate.Text != "" || txtstardate.Text == "" && txtenddate.Text == "")
        {
            ViewState["stardate"] = txtstardate.Text.Trim();
            ViewState["enddate"] = txtenddate.Text.Trim();
            BindData();
        }
        if (txtstardate.Text != "" && txtenddate.Text == "")
        {
            labmessage.Text = "请选择终止日期";
        }
        if (txtstardate.Text == "" && txtenddate.Text != "")
        {
            labmessage.Text = "请选择开始日期";
        }
        #endregion
    }
    protected void gvorderlist_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "lbtndetail")
        {
            Response.Redirect("OrderDetail.aspx?OrderId="+Convert.ToInt32(e.CommandArgument));
        }
        else if (e.CommandName == "lbtndelete")
        {
            OrderManager.DeleteOrderById(Convert.ToInt32(e.CommandArgument));
            BindData();
        }
    }
    protected void gvorderlist_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvorderlist.PageIndex = e.NewPageIndex;
        BindData();
    }
}
