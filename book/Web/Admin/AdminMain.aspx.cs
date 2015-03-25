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

public partial class Admin_AdminMain : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["adminuser"] != null)
            {
                Users user = (Users)Session["adminuser"];
                labname.Text = "【" + user.Name + "】";
            }
            else
            {
                Response.Redirect("AdminLogin.aspx");
            }
        }
    }
}
