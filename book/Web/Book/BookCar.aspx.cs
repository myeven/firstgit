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

public partial class Book_BookCar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }
    public void BindData()
    {
        #region 绑定GridView和统计总价
        DataTable car = (DataTable)Session["cart"];
        gvlist.DataSource = car;
        gvlist.DataBind();

        TotalPrice(car);
        #endregion
    }
    public void TotalPrice(DataTable car)
    {
        #region 统计价格总和
        if (car != null)
        {
            decimal count = 0;
            decimal unitprice = 0;
            decimal totalprice = 0;
            foreach (DataRow dr in car.Rows)
            {
                count = Convert.ToDecimal(dr["BookNumber"]);
                unitprice = Convert.ToDecimal(dr["UnitPrice"]);
                totalprice += (count * unitprice);
            }
            lbtotalprice.Text = totalprice.ToString("0.00");
        }
        else
        {
            lbtotalprice.Text = "0";
        }
        #endregion
    }
    protected void lbtnclear_Click(object sender, EventArgs e)
    {
        #region 清空购物车
        Session["cart"] = null;
        BindData();
        #endregion
    }
    protected void gvlist_RowEditing(object sender, GridViewEditEventArgs e)
    {
        #region 编辑
        gvlist.EditIndex = e.NewEditIndex;
        BindData();
        #endregion
    }
    protected void gvlist_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        #region 更新购买的图书数量
        DataTable car = (DataTable)Session["cart"];
        foreach (DataRow dr in car.Rows)
        {
            if (dr["BookId"].ToString() == gvlist.DataKeys[e.RowIndex].Value.ToString())
            {
                dr["BookNumber"] = ((TextBox)gvlist.Rows[e.RowIndex].FindControl("txtnumber")).Text;
                Session["cart"] = car;
            }
        }
        gvlist.EditIndex = -1;
        BindData();
        #endregion
    }
    protected void gvlist_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        #region 取消更新
        gvlist.EditIndex = -1;
        BindData();
        #endregion
    }
    protected void gvlist_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        #region 删除
        DataTable car = (DataTable)Session["cart"];
        car.Rows[e.RowIndex].Delete();
        Session["cart"] = car;
        BindData();
        #endregion
    }
    protected void imgbtnreturn_Click(object sender, ImageClickEventArgs e)
    {
        #region 返回购物
        Response.Redirect("~/Book/BookList.aspx");
        #endregion 
    }
    protected void imgbtnjudge_Click(object sender, ImageClickEventArgs e)
    {
        #region 进入结算中心

        Response.Redirect("BookOrder.aspx");

        #endregion
    }
}
