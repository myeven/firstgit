using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BookShopDAL;
using BookShopModels;

namespace BookShopBLL
{
   public class CategoriesManager
    {
        public static DataTable GetDataTableByCategories()
       {
           #region 返回所有图书类别
           return CategorieServer.GetDataTableByCategories();
           #endregion 
       }
        public static Categories GetCategoriesById(int Id)
        {
            #region 根据图书分类Id获取分类信息

            return CategorieServer.GetCategoriesById(Id);
            #endregion
        }
        public static void UpdateCategory(Categories category)
        {
            #region 根据图书分类Id更新分类信息

            CategorieServer.UpdateCategory(category);
            #endregion
        }
        public static void AddCategory(string Name)
        {
            #region 添加图书分类
            CategorieServer.AddCategory(Name);
            #endregion
        }
        public static void DeleteCategoryById(int Id)
        {
            #region 根据图书分类Id删除分类
            CategorieServer.DeleteCategoryById(Id);
            #endregion
        }
        public static bool FindCategoryIsBook(int Id)
        {
            #region 判断图书分类里是否有图书
            return CategorieServer.FindCategoryIsBook(Id);
            #endregion
        }
    }
}
