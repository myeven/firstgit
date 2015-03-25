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

public partial class MemberShip_BookList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        #region 初始化数据
        if (!IsPostBack)
        {
            if (Request.QueryString["CategoryId"] != null)
            {
                ViewState["CategorieID"] = Request.QueryString["CategoryId"].ToString();
            }
            else
            {
                ViewState["CategorieID"] = "";
            }
            ViewState["order"]="";
            ViewState["search"]="";
            BindData();
        }
        #endregion
    }
    public void BindData()
    {
        #region GridView绑定

        grvbooklist.DataSource = Bookmanager.GetBookListDataTable(ViewState["CategorieID"].ToString(), ViewState["order"].ToString(), ViewState["search"].ToString());
        grvbooklist.DataBind();
        #endregion
    }
    protected void  btnsortdate_Click(object sender, EventArgs e)
    {
        #region 图书按出版时间排序
        if (ddlsort.SelectedItem.Value == "升序")
        {
            ViewState["order"] = "PublishDate ASC";
        }
        else
        {
            ViewState["order"] = "PublishDate DESC";
        }
        BindData();
        this.btnsortprice.Enabled = true;
        this.btnsortdate.Enabled = false;

        #endregion
    }
    protected void  btnsortprice_Click(object sender, EventArgs e)
    {
        #region 图书按单价排序
        if (ddlsort.SelectedItem.Value == "升序")
        {
            ViewState["order"] = "UnitPrice ASC";
        }
        else
        {
            ViewState["order"] = "UnitPrice DESC";
        }
        BindData();
        this.btnsortprice.Enabled = false;
        this.btnsortdate.Enabled = true;

        #endregion
    }
    protected void imgbtnsearch_Click(object sender, ImageClickEventArgs e)
    {
        #region 搜索图书

        ViewState["search"]=txtsearch.Text.Trim();
        BindData();
        #endregion
    }
    protected void ddlsort_SelectedIndexChanged(object sender, EventArgs e)
    {
        #region 图书按单价或出版时间升序或降序排列
        if (ddlsort.SelectedItem.Value == "升序")
        {
            if (btnsortdate.Enabled == false)
            {
                ViewState["order"] = "PublishDate ASC";
            }
            else
            {
                ViewState["order"] = "UnitPrice ASC";
                
            }
            BindData();
        }
        else
        {
            if (btnsortdate.Enabled == false)
            {
                ViewState["order"] = "PublishDate DESC";
            }
            else
            {
                ViewState["order"] = "UnitPrice DESC";
            }
            BindData();
        }
        #endregion
    }
    protected void grvbooklist_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Buy")
        {
            #region 把图书添加到购物车

            ViewState["BookId"] = e.CommandArgument;
            if (Session["cart"] == null)
            {
                CreateCart();
            }
            else
            {
                DataTable car = (DataTable)Session["cart"];//把购物车取出赋值给DadaTable
                if (!ExitBook(car))
                {
                    BuildSession(car);
                }
            }
            Response.Redirect("~/Book/BookCar.aspx");

            #endregion
        }
    }
    public void CreateCart()
    {
        #region 创建购物车并将商品信息添加到购物车
        DataTable car = new DataTable();
        car.Columns.Add("BookId");
        car.Columns.Add("BookName");
        car.Columns.Add("BookNumber");
        car.Columns.Add("UnitPrice");
        car.Columns.Add("ImgUrl");
        BuildSession(car);
        #endregion
    }
    public void BuildSession(DataTable car)
    {
        #region 把商品信息添加到购物车
        DataRow dr = car.NewRow();
        Books book = Bookmanager.GetBookDetailById(Convert.ToInt32(ViewState["BookId"]));
        dr["BookId"] = book.Id;
        dr["BookName"] = book.Title;
        dr["BookNumber"] = 1;
        dr["UnitPrice"] = book.UnitPrice.ToString("0.00");
        dr["ImgUrl"] = book.ISBN;
        car.Rows.Add(dr);
        Session["cart"] = car;
        #endregion
    }
    public bool ExitBook(DataTable car)
    {
        #region 判断购物车里是否已存在选择的图书
        foreach (DataRow dr in car.Rows)
        {
            if (dr["BookId"].ToString() == ViewState["BookId"].ToString())
            {
                dr["BookNumber"] = Convert.ToInt32(dr["BookNumber"]) + 1;
                Session["cart"] = car;
                return true;
            }
        }
        return false;
        #endregion
    }
    protected void grvbooklist_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        #region 分页
        grvbooklist.PageIndex = e.NewPageIndex;
        BindData();
        #endregion
    }
    public string Formatstring(string str, int count)
    {
        #region 格式化图书简介

        if (str.Length <= count)
        {
            return str;
        }
        else
        {
            string newstr = "";
            newstr = str.Substring(0, count) + "......";
            return newstr;
        }
        #endregion
    }
    public string FormatDate(string date)
    {
        #region 格式化出版日期

        return Convert.ToDateTime(date).ToString("yyyy年MM月dd日");
        #endregion
    }
    public string FormatPrice(string price)
    {
        #region 格式化单价

        return Convert.ToDecimal(price).ToString("0.00");
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
}