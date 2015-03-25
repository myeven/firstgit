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
using BookShopModels;
using BookShopBLL;

public partial class Book_RedactMyOrder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
            BindInfomation();
        }
    }
    public void BindData()
    {
        #region 绑定Gridview
        DataTable car = (DataTable)Session["cart"];
        TotalPrice(car);
        gvlist.DataSource = car;
        gvlist.DataBind();
        #endregion
    }
    public void BindInfomation()
    {
        #region 绑定购买商品用户的信息
        Users user = (Users)Session["user"];
        labname.Text = user.Name;
        labmail.Text = user.Mail;
        labphone.Text = user.Phone;
        labaddress.Text = user.Address;
        if (user.UserRoles.Id == 2)
        {
            Panel1.Visible = true;
            labsaleprice.Text = (Convert.ToDouble(labtotalprice.Text) * 0.9).ToString("0.00");
        }
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
            labtotalprice.Text = totalprice.ToString("0.00");
        }
        else
        {
            labtotalprice.Text = "0";
        }
        #endregion
    }
    protected void imgbtnokClick(object sender, ImageClickEventArgs e)
    {
        #region 提交订单
        if (labtotalprice.Text != "0")
        {
            if (Session["cart"] != null)
            {
               Orders order=AddOrder();
               AddOrderBook(order);
               BindData();
            }
            else
            {
                labmessage.Text = "订单已经添加成功";
            }
        }
        else
        {
            labmessage.Text = "您还没有选择任何商品";
        }
        #endregion
    }
    public Orders AddOrder()
    {
        #region 添加订单
        Orders order = new Orders();
        order.User = (Users)Session["user"];
        if (Panel1.Visible == true)//如果用户是VIP会员
        {
            order.TotalPrice = Convert.ToDecimal(labsaleprice.Text);//总价是打折后的价格
        }
        else
        {
            order.TotalPrice = Convert.ToDecimal(labtotalprice.Text);
        }
        order.OrderDate = DateTime.Now;
        order = OrderManager.AddOrder(order);
        return order;
        #endregion
    }
    public void AddOrderBook( Orders order)
    {
        #region 添加订单详情
        DataTable car=(DataTable)Session["cart"];
        OrderBook orderbook = new OrderBook();
        foreach (DataRow dr in car.Rows)
        {
            orderbook.Order = order;
            orderbook.Quantity = Convert.ToInt32(dr["BookNumber"]);
            orderbook.UnitPrice = Convert.ToDecimal(dr["UnitPrice"]);
            orderbook.Book = Bookmanager.GetBookDetailById(Convert.ToInt32(dr["BookId"]));
            OrderBookManager.AddOrderBook(orderbook);
        }
        Session["cart"] = null;
        labsaleprice.Text = "0.00";
        labtotalprice.Text = "0.00";
        labmessage.Text = "订单添加成功，请等待商家回应";
        #endregion
    }
    protected void lbtnreturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Book/BookCar.aspx");
    }
}
