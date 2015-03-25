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
using BookShopModels;
using BookShopBLL;
using BookShopDAL;

public partial class Control_BookImages : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string picstr = "";
        string textstr = "";
        string linkstr = "";
        SqlConnection cn = DbHelp.Connection;
        string sql = "select top 4 Id,Title,ISBN from Books order by PublishDate DESC";
        SqlCommand cm = new SqlCommand(sql, cn);
        using (SqlDataReader dr = cm.ExecuteReader())
        {
            while (dr.Read())
            {
                picstr += "../Images/BookCovers/" + dr["ISBN"].ToString() + ".jpg |";
                textstr += Formatstring(dr["Title"].ToString(),20) + "|";
                linkstr += "BookDetail.aspx?BookId=" + dr["Id"].ToString()+"|";
            }
        }
        picstr = picstr.Remove(picstr.Length - 1, 1);
        textstr = textstr.Remove(textstr.Length - 1, 1);
        linkstr = linkstr.Remove(linkstr.Length - 1, 1);
        Page.RegisterClientScriptBlock("tp1", "<script type='text/javascript'>var links='" + linkstr + "'</script>");
        Page.RegisterClientScriptBlock("tp2", "<script type='text/javascript'>var pics='" + picstr + "'</script>");
        Page.RegisterClientScriptBlock("tp3", "<script type='text/javascript'>var texts='" + textstr + "'</script>");
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
    #region Web 窗体设计器生成的代码
    override protected void OnInit(EventArgs e)
    {
        //
        // CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
        //
        InitializeComponent();
        base.OnInit(e);
    }

    /// <summary>
    ///		设计器支持所需的方法 - 不要使用代码编辑器
    ///		修改此方法的内容。
    /// </summary>
    private void InitializeComponent()
    {
        this.Load += new System.EventHandler(this.Page_Load);

    }
    #endregion
}
