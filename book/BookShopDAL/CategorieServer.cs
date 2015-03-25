using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookShopModels;
using System.Data;
using System.Data.SqlClient;

namespace BookShopDAL
{
  public class CategorieServer
    {
        public static DataTable GetDataTableByCategories()
        {
           #region 返回所有的图书类别
          string sql = "SELECT * FROM Categories";
          return DbHelp.GetDataTable(sql);
          #endregion
        }
        public static Categories GetCategoriesById(int Id)
        {
            #region 根据图书分类Id获取分类信息
            Categories category = new Categories();
            string sql = "SELECT * FROM Categories WHERE Id="+Id;
            using (SqlDataReader dr = DbHelp.GetReader(sql))
            {
                if (dr.Read())
                {
                    category.Id = Convert.ToInt32(dr["Id"]);
                    category.Name = dr["Name"].ToString();
                }
                else
                {
                    category = null;
                }
            }
            return category;
            #endregion
        }
        public static void UpdateCategory(Categories category)
        {
            #region 根据图书分类Id更新分类信息

            string sql = "UPDATE Categories SET Name=@Name WHERE Id=@Id";
            SqlParameter[] para = {
                                      new SqlParameter("Name",category.Name),
                                      new SqlParameter("Id",category.Id)
                                  };
            DbHelp.GetExecuteNonQuery(sql, para);
            #endregion
        }
        public static void AddCategory(string Name)
        {
            #region 添加图书分类
            string sql = "INSERT INTO Categories(Name) VALUES(@Name)";
            SqlParameter[] para = {
                                      new SqlParameter("Name",Name)
                                  };
            DbHelp.GetExecuteNonQuery(sql, para);
            #endregion
        }
        public static void DeleteCategoryById(int Id)
        {
            #region 根据图书分类Id删除分类

            string sql = "DELETE FROM Categories WHERE Id=@Id";
            SqlParameter[] para = {
                                      new SqlParameter("Id",Id)
                                  };
            DbHelp.GetExecuteNonQuery(sql, para);            
            #endregion
        }
        public static bool FindCategoryIsBook(int Id)
        {
            #region 判断图书分类里是否有图书
            String sql = "SELECT * FROM Books WHERE CategoryId=" + Id;
            using (SqlDataReader dr = DbHelp.GetReader(sql))
            {
                if (dr.Read())
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            #endregion
        }
    }
}
