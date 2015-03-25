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

public partial class Book_BookDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["BookId"] != null)
            {
                ViewState["BookId"] = Convert.ToInt32(Request.QueryString["BookId"]);
                BindData();
            }
            else
            {
                Response.Redirect("~/Book/BookList.aspx");
            }
        }
    }
    public void BindData()
    {
       #region 根据图书Id绑定GridView
        Books book = Bookmanager.GetBookDetailById(Convert.ToInt32( ViewState["BookId"]));
        book.Clicks++;
        Bookmanager.EditBook(book);

        this.lblAuthor.Text = book.Author;
        this.lblBookName.Text = book.Title;
        this.lblPublisher.Text = book.Publishers.Name;
        this.lbltypeName.Text = book.Categories.Name;
        this.lblISBN.Text = book.ISBN;
        this.lblPublishDate.Text = book.PublishDate.ToShortDateString();
        this.lblFonts.Text = book.WordsCount.ToString();
        this.lblPrice.Text = book.UnitPrice.ToString("0.00");
        this.lblContent.Text = book.ContentDescription;
        this.lblAuthorIntroduce.Text = book.AuthorDescription;
        this.lblRecomment.Text = book.EditorComment;
        this.lblCatagory.Text = book.TOC;
        this.lbclicks.Text = book.Clicks.ToString();
        this.imgBook.ImageUrl = "~/Images/BookCovers/" + book.ISBN + ".jpg";

        #endregion
    }
    protected void imgbtn_Buy_Click(object sender, ImageClickEventArgs e)
    {
       #region 把图书添加到购物车
        if (Session["cart"] == null)
        {
            DataTable car = CreateCart();
            BuildSession(car);//如果购物车是空的，创建一个购物车并把商品添加到购物车
        }
        else
        {
            DataTable car = (DataTable)Session["cart"];//如果购物车不是空的，把购物车从Session中取出赋值给一个新的购物车。
            if (!ExitBook(car))
            {
                BuildSession(car);//如果购物车中没有新购买的图书，就直接把图书添加到购物车中。反之将购买的图书数量加一
            }
        }
       Response.Redirect("~/Book/BookCar.aspx");        
       #endregion
    }
     public DataTable CreateCart()
    {
       #region 创建购物车
        DataTable car = new DataTable();
        car.Columns.Add("BookId");
        car.Columns.Add("BookName");
        car.Columns.Add("BookNumber");
        car.Columns.Add("UnitPrice");
        car.Columns.Add("ImgUrl");
        return car;
      #endregion
    }
    public void BuildSession(DataTable car)
    {
       #region 把商品信息添加到购物车
        DataRow dr = car.NewRow();
        dr["BookId"] = ViewState["BookId"];
        dr["BookName"] = lbltypeName.Text;
        dr["BookNumber"] = 1;
        dr["UnitPrice"] = lblPrice.Text;
        dr["ImgUrl"] = lblISBN.Text;
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
}
