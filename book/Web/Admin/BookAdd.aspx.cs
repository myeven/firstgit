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
public partial class Admin_BookAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["adminuser"] != null)
            {
                ViewState["BookId"]=Request.QueryString["BookId"];
                if (ViewState["BookId"]!= null)
                {
                    BindDDL();
                    BindData();
                }
                else
                {
                    BindDDL();
                    btnok.Text = "添加";
                }
            }
            else
            {
                Response.Redirect("AdminLogin.aspx");
            }
        }
    }
    public void BindData()
    {
        #region 绑定数据
        Books book = Bookmanager.GetBookDetailById(Convert.ToInt32(ViewState["BookId"]));
        txtauthor.Text = book.Author;
        txtcontentdescription.Text = book.ContentDescription;
        txtcount.Text = book.WordsCount.ToString();
        txtISBN.Text = book.ISBN;
        txtprice.Text = book.UnitPrice.ToString();
        txtpublishdate.Text = book.PublishDate.ToString();
        txtrecommand.Text = book.EditorComment;
        txttitle.Text = book.Title;
        ftbtoc.Text = book.TOC;
        authordescription.Text = book.AuthorDescription;
        Image1.ImageUrl = "~/Images/BookCovers/" + book.ISBN + ".jpg";
        foreach (ListItem lt in ddlcategory.Items)
        {
            if (lt.Value == book.Categories.Id.ToString())
            {
                lt.Selected = true;
            }
        }
        foreach (ListItem lt in ddlpublisher.Items)
        {
            if (lt.Value == book.Publishers.Id.ToString())
            {
                lt.Selected = true;
            }
        }
        #endregion
    }
    public void BindDDL()
    {
        #region 绑定图书分类和出版社
        DataTable dt = CategoriesManager.GetDataTableByCategories();
        GridViewHelp.BindDDL(dt,ddlcategory,"Name","Id");

        DataTable dt2 = PublisherManager.GetDataTableByCategories();
        GridViewHelp.BindDDL(dt2, ddlpublisher, "Name", "Id");
        #endregion
    }
    protected void btnok_Click(object sender, EventArgs e)
    {
        if (ViewState["BookId"] != null)
        {
            #region 更新图书
            if (FileUploadimg.HasFile)
            {
                string[] arrexit = { ".jpg" };
                DateTime dt=DateTime.Now;
                string Bfilename = dt.Year.ToString("0000") + dt.Month.ToString("00") + dt.Second.ToString("00") + dt.Millisecond.ToString("00");
                bool isok = FunctionHelp.JudgeFileUploadimg(FileUploadimg, "~/Images/BookCovers/", Bfilename, arrexit);
                if (isok)
                {
                    Books book = Bookmanager.GetBookDetailById(Convert.ToInt32(ViewState["BookId"]));
                    book = GetBook(book);
                    book.ISBN = Bfilename;
                    Bookmanager.EditBook(book);
                    Response.Redirect("~/Admin/ListAllBooks.aspx");
                }
                else
                {
                   labimessage.Text = "上传图片格式不正确";
                }
            }
            else
            {
                Books book = Bookmanager.GetBookDetailById(Convert.ToInt32(ViewState["BookId"]));
                book = GetBook(book);
                Bookmanager.EditBook(book);
                Response.Redirect("~/Admin/ListAllBooks.aspx");
            }
            #endregion
        }
        else
        {
            #region 添加图书
            if (Bookmanager.SearchISBN(txtISBN.Text))
            {
                labisbnmessage.Text = "该ISBN已存在";
            }
            else
            {
                if (FileUploadimg.HasFile)
                {
                    string[] arrexit = { ".jpg" };
                    bool isok = FunctionHelp.JudgeFileUploadimg(FileUploadimg, "~/Images/BookCovers/", txtISBN.Text, arrexit);
                    if (isok)
                    {
                        Books book = new Books();
                        book = GetBook(book);
                        Bookmanager.AddBook(book);
                        labimessage.Text = "添加成功";
                    }
                    else
                    {
                        labimessage.Text = "上传图片格式不正确";
                    }
                }
            }
            #endregion
        }
    }
    public Books GetBook(Books book)
    {
        #region 获取图书信息
        book.Author = txtauthor.Text;
        book.ContentDescription = txtcontentdescription.Text;
        book.WordsCount = Convert.ToInt32(txtcount.Text);
        book.ISBN = txtISBN.Text;
        book.UnitPrice = Convert.ToDecimal(txtprice.Text);
        book.PublishDate = Convert.ToDateTime(txtpublishdate.Text);
        book.EditorComment = txtrecommand.Text;
        book.Title = txttitle.Text;
        book.TOC = ftbtoc.Text;
        book.AuthorDescription = authordescription.Text;
        book.Publishers = PublisherManager.GetPublishersById(Convert.ToInt32(ddlpublisher.SelectedValue));
        book.Categories = CategoriesManager.GetCategoriesById(Convert.ToInt32(ddlcategory.SelectedValue));
        return book;
        #endregion
    }
    protected void btncancle_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/ListAllBooks.aspx");
    }
}
