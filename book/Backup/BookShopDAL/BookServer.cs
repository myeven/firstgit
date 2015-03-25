using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using BookShopModels;

namespace BookShopDAL
{
   public class BookServer
    {
       public static DataTable GetBookListDataTable(string CategorieId,string order,string search)
       {
           #region 绑定图书列表
           string sql = @"SELECT book.Id AS bookId,category.Name AS categoryname, * FROM 
Books AS book
LEFT JOIN Categories AS category
ON book.CategoryId=category.Id
LEFT JOIN Publishers AS publish
ON book.PublisherId=publish.Id WHERE 1=1 ";
           if (CategorieId != "")
           {
               sql += "AND CategoryId=" +Convert.ToInt16(CategorieId);
           }
           if(search!="")
           {
               sql += "AND Title LIKE '%" + search + "%' OR PublishDate LIKE '%" + search + "%'OR UnitPrice LIKE '%" + search + "%' OR Author LIKE '%" + search + "%'";
           }
           if (order != "")
           {
               sql += "ORDER BY " + order;
           }
           return DbHelp.GetDataTable(sql);
           #endregion
       }
       public static Books GetBookDetailById(int Id)
       {
           #region 通过图书Id获取图书详细信息
           Books book = new Books();
           string sql = "SELECT * FROM Books WHERE Id=" + Id;
           using (SqlDataReader dr=DbHelp.GetReader(sql))
           {
               if (dr.Read())
               {
                   book.Id = Convert.ToInt32(dr["Id"]);
                   book.AuthorDescription = dr["AurhorDescription"].ToString();
                   book.Author = dr["Author"].ToString();
                   book.Clicks = Convert.ToInt32(dr["Clicks"]);
                   book.ContentDescription = dr["ContentDescription"].ToString();
                   book.EditorComment = dr["EditorComment"].ToString();
                   book.ISBN = dr["ISBN"].ToString();
                   book.PublishDate = Convert.ToDateTime(dr["PublishDate"]);
                   book.Title = dr["Title"].ToString();
                   book.TOC = dr["TOC"].ToString();
                   book.UnitPrice = Convert.ToDecimal(dr["UnitPrice"]);
                   book.WordsCount = Convert.ToInt32(dr["WordsCount"]);

                   int PublisherID = Convert.ToInt32(dr["PublisherId"]);
                   int CategorieID = Convert.ToInt32(dr["CategoryId"]);
                   dr.Close();
                   book.Publishers = GetBookPublishersById(PublisherID);
                   book.Categories = GetBookCategoriesById(CategorieID);
               }
               else
               {
                   book = null;
               }
           }
           return book;
           #endregion
       }
       public static bool SearchISBN(string isbn)
       {
           #region 查询是否存在ISBN
           string sql = "SELECT * FROM Books WHERE ISBN='" + isbn+"'";
           int i = DbHelp.GetScalar(sql);
           if (i > 0)
           {
               return true;
           }
           else
           {
               return false;
           }
           #endregion
       }
       public static Publishers GetBookPublishersById(int Id)
       {
           #region 通过图书编号查询图书出版社信息
           Publishers pubilsher = new Publishers();
           string sql = "SELECT * FROM Publishers WHERE Id=" + Id;
           using (SqlDataReader dr = DbHelp.GetReader(sql))
           {
               if (dr.Read())
               {
                   pubilsher.Id=Convert.ToInt32(dr["ID"]);
                   pubilsher.Name=dr["Name"].ToString();
               }
           }
           return pubilsher;
           #endregion
       }
       public static Categories GetBookCategoriesById(int Id)
       {
           #region 通过图书编号查询图书类别信息
           Categories categories = new Categories();
           string sql = "SELECT * FROM Categories WHERE Id=" + Id;
           using (SqlDataReader dr = DbHelp.GetReader(sql))
           {
               if (dr.Read())
               {
                   categories.Id = Convert.ToInt32(dr["ID"]);
                   categories.Name = dr["Name"].ToString();
               }
           }
           return categories;
           #endregion
       }
       public static DataTable GetHotBooks(int top,int notop)
       {
           #region 查询热门图书
           string sql = @"SELECT Top " + top + " * FROM Books WHERE ID NOT IN(SELECT TOP " + notop + " Id FROM Books ORDER BY clicks DESC) ORDER BY clicks DESC";
           return DbHelp.GetDataTable(sql);
           #endregion
       }
       public static DataTable GetNewBooks(int top)
       {
           #region 查询最新图书
           string sql = "SELECT Top " + top + " * FROM Books ORDER BY PublishDate DESC";
           return DbHelp.GetDataTable(sql);
           #endregion
       }
       public static DataTable GetNewMonthBooks(int top)
       {
           #region 查询本月最新图书
           string sql = "SELECT Top " + top + " * FROM Books WHERE DATEDIFF(month,PublishDate,getdate())=0 ORDER BY PublishDate DESC";
           return DbHelp.GetDataTable(sql);
           #endregion
       }
       public static void AddBook(Books book)
       {
           #region 添加图书
           string sql = "INSERT INTO Books(Title,Author,PublisherId, PublishDate,ISBN,WordsCount,UnitPrice,ContentDescription,AurhorDescription,EditorComment,TOC, CategoryId,Clicks) VALUES(@Title,@Author,@PublisherId, @PublishDate,@ISBN,@WordsCount,@UnitPrice,@ContentDescription,@AurhorDescription,@EditorComment,@TOC, @CategoryId,@Clicks)";
           SqlParameter[] para ={
                                    new SqlParameter("@Title",book.Title),
                                    new SqlParameter("@Author",book.Author),
                                    new SqlParameter("@PublisherId",book.Publishers.Id),
                                    new SqlParameter("@PublishDate",book.PublishDate),
                                    new SqlParameter("@ISBN",book.ISBN),
                                    new SqlParameter("@WordsCount",book.WordsCount),
                                    new SqlParameter("@UnitPrice",book.UnitPrice),
                                    new SqlParameter("@ContentDescription",book.ContentDescription),
                                    new SqlParameter("@AurhorDescription",book.AuthorDescription),
                                    new SqlParameter("@EditorComment",book.EditorComment),
                                    new SqlParameter("@TOC",book.TOC),
                                    new SqlParameter("@CategoryId",book.Categories.Id),
                                    new SqlParameter("@Clicks",book.Clicks)                                                                                          };
           DbHelp.GetExecuteNonQuery(sql, para);
           #endregion
       }
       public static void EditBook(Books book)
       {
           #region 更新图书信息

           string sql = @"UPDATE Books SET Title=@Title,
                                           Author=@Author,
                                           PublisherId=@PublisherId,
                                           PublishDate=@PublishDate,
                                           ISBN=@ISBN,
                                           WordsCount=@WordsCount,
                                           UnitPrice=@UnitPrice,
                                           ContentDescription=@ContentDescription,
                                           AurhorDescription=@AurhorDescription,
                                           EditorComment=@EditorComment,
                                           TOC=@TOC,
                                           CategoryId=@CategoryId,
                                           Clicks=@Clicks
 WHERE Id="+book.Id;
           SqlParameter[] para ={
                                    new SqlParameter("@Title",book.Title),
                                    new SqlParameter("@Author",book.Author),
                                    new SqlParameter("@PublisherId",book.Publishers.Id),
                                    new SqlParameter("@PublishDate",book.PublishDate),
                                    new SqlParameter("@ISBN",book.ISBN),
                                    new SqlParameter("@WordsCount",book.WordsCount),
                                    new SqlParameter("@UnitPrice",book.UnitPrice),
                                    new SqlParameter("@ContentDescription",book.ContentDescription),
                                    new SqlParameter("@AurhorDescription",book.AuthorDescription),
                                    new SqlParameter("@EditorComment",book.EditorComment),
                                    new SqlParameter("@TOC",book.TOC),
                                    new SqlParameter("@CategoryId",book.Categories.Id),
                                    new SqlParameter("@Clicks",book.Clicks)                                                                                          };
           DbHelp.GetExecuteNonQuery(sql,para);
           #endregion
       }      
       public static void DeleteBookById(int Id)
       {
           #region 通过图书Id删除图书
           string sql = "DELETE  FROM Books WHERE Id=" + Id;
           DbHelp.GetExecuteNonQuery(sql);
           #endregion
       }      
    }
}
