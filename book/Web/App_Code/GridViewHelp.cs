using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
///GridViewHelp 的摘要说明
/// </summary>
public class GridViewHelp
{
    public GridViewHelp()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    public static void ALlCheck(GridView gv,string checkname)
    {
        #region 全选
        foreach (GridViewRow grv in gv.Rows)
        {
            CheckBox chb = (CheckBox)grv.FindControl(checkname);
            chb.Checked = true;
        }
        #endregion
    }
    public static void InsteadCheck(GridView gv, string checkname)
    {
        #region 反选
        foreach (GridViewRow grv in gv.Rows)
        {
            CheckBox chb = (CheckBox)grv.FindControl(checkname);
            if (chb.Checked == true)
            {
                chb.Checked = false;
            }
            else
            {
                chb.Checked = true;
            }
        }
        #endregion
    }
    public static void BindDDL(DataTable dt,DropDownList ddl,string text,string value)
    {
        #region 绑定DropDownList
        ddl.Items.Add(new ListItem("--请选择--", "0"));
        foreach (DataRow dr in dt.Rows)
        {
            ddl.Items.Add(new ListItem(dr[text].ToString(), dr[value].ToString()));

        }
        #endregion
    }
    public static void BindRBL(DataTable dt, RadioButtonList rbl, string text, string value)
    {
        #region 绑定RadioButtonList
        foreach (DataRow dr in dt.Rows)
        {
            rbl.Items.Add(new ListItem(dr[text].ToString(), dr[value].ToString()));

        }
        #endregion
    }

}
