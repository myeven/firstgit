using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BookShopModels;

namespace BookShopDAL
{
   public class PublisherServer
    {
       public static DataTable GetDataTableByCategories()
       {
           #region 返回所有的图书出版社
           string sql = "SELECT * FROM Publishers";
           return DbHelp.GetDataTable(sql);
           #endregion
       }
       public static Publishers GetPublishersById(int Id)
       {
           #region 根据图书出版社Id获取出版社信息
           Publishers publisher = new Publishers();
           string sql = "SELECT * FROM Publishers WHERE Id=" + Id;
           using (SqlDataReader dr = DbHelp.GetReader(sql))
           {
               if (dr.Read())
               {
                   publisher.Id = Convert.ToInt32(dr["Id"]);
                   publisher.Name = dr["Name"].ToString();
               }
               else
               {
                   publisher = null;
               }
           }
           return publisher;
           #endregion
       }
    }
}
