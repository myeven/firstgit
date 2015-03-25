using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BookShopModels;
using BookShopDAL;
namespace BookShopBLL
{
     public  class Bookmanager
    {
         public static DataTable GetBookListDataTable(string CategorieId, string order, string search)
         {
             #region 返回所有图书列表
             return BookServer.GetBookListDataTable(CategorieId,order,search);
             #endregion
         }
         public static Books GetBookDetailById(int Id)
         {
             #region 通过图书Id获取图书详细信息
             return BookServer.GetBookDetailById(Id);
             #endregion
         }
         public static bool SearchISBN(string isbn)
         {
             #region 查询是否存在ISBN
             return BookServer.SearchISBN(isbn);
             #endregion
         }
         public static DataTable GetHotBooks(int top,int notop)
         {
             #region 查询热门图书
             return BookServer.GetHotBooks(top,notop);
             #endregion
         }
         public static DataTable GetNewBooks(int top)
         {
             #region 查询最新图书
             return BookServer.GetNewBooks(top);
             #endregion
         }
         public static DataTable GetNewMonthBooks(int top)
         {
             #region 查询本月最新图书
             return BookServer.GetNewMonthBooks(top);
             #endregion
         }
         public static void EditBook(Books book)
         {
            #region 更新图书信息

           BookServer.EditBook(book);

           #endregion
         }        
         public static void AddBook(Books book)
         {
             #region 添加图书
             BookServer.AddBook(book);
             #endregion
         }
         public static void DeleteBookById(int Id)
         {
             #region 通过图书Id删除图书
             BookServer.DeleteBookById(Id);
             #endregion
         }
    }
}
