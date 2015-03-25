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

public partial class Book_BookOrder : System.Web.UI.Page
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
        DataTable car = (DataTable)Session["cart"];
        TotalPrice(car);
        gvlist.DataSource = car;
        gvlist.DataBind();
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
    protected void lbtnreturn_Click(object sender, EventArgs e)
    {
        #region 返回购物
        Response.Redirect("~/Book/BookList.aspx");
        #endregion 
    }
    protected void imgbtnjudge_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["User"] == null)
        {
            Response.Redirect("~/MemberShip/UserLogin.aspx?operate=Redact");
        }
        else
        {
            if (lbtotalprice.Text != "")
            {
                Response.Redirect("RedactMyOrder.aspx");
            }
            else
            {
                Response.Write("<script>alert('您还没有选择任何商品！')</script>");
            }
        }
    }
    protected void lbtncancle_Click(object sender, EventArgs e)
    {
        Response.Redirect("BookCar.aspx");
    }
}
