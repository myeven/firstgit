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

public partial class MemberShip_Main : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }
    public void  BindData()
    {
      #region 绑定DstaList数据
      dlrecommand.DataSource = Bookmanager.GetHotBooks(1, 4);
      dlrecommand.DataBind();
      dlhot.DataSource = Bookmanager.GetHotBooks(4, 10);
      dlhot.DataBind();
      dlmonthnew.DataSource = Bookmanager.GetNewMonthBooks(4);
      dlmonthnew.DataBind();
      ddlhotbok.DataSource = Bookmanager.GetNewBooks(20);
      ddlhotbok.DataBind();
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
    public string Formatstring(string str, int count)
    {
        #region 格式化字符串

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
    public string FormatPrice(Object price)
    {
        #region 格式化单价

        return Convert.ToDecimal(price).ToString("0.00");
        #endregion
    }
    public string Discount_Price(string price,double discount)
    {
        #region 折扣后的单价单价

        return (Convert.ToDouble(price) * discount).ToString("0.00");
        #endregion
    }
    protected void dlrecommand_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
