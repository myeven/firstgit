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
using System.IO;

/// <summary>
///FunctionHelp 的摘要说明
/// </summary>
public class FunctionHelp
{
    public FunctionHelp()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    public static bool JudgeFileUploadimg(FileUpload FileUploadimg, string strMapPath, string Bfilename, string[] arrexit)
    {
        #region 上传图片到服务器
        bool isexit = false;
        bool isok = false;
        string filename = FileUploadimg.FileName;
        string serverload = HttpContext.Current.Server.MapPath(strMapPath);
        string fileexit = System.IO.Path.GetExtension(filename);
        string newfilename = "";
        foreach (string str in arrexit)
        {
            if (fileexit == str)
            {
                isexit = true;
                break;
            }
        }
        if (isexit)
        {
            newfilename = Bfilename + fileexit;
            FileUploadimg.SaveAs(serverload + newfilename);
            isok = true;
        }
        return isok;
       #endregion
    }
}
