using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookShopModels;
using System.Data;
using System.Data.SqlClient;

namespace BookShopDAL
{
  public class OrderBookServer
    {
      public static void AddOrderBook(OrderBook orderbook)
     {
            #region 添加订单详情
            string sql = "INSERT INTO OrderBook(OrderID,BookID,Quantity,UnitPrice) VALUES(@OrderID,@BookID,@Quantity,@UnitPrice)";
            SqlParameter[] para = {
                                     new SqlParameter("@OrderID",orderbook.Order.Id),
                                     new SqlParameter("@BookID",orderbook.Book.Id),
                                     new SqlParameter("@Quantity",orderbook.Quantity),
                                     new SqlParameter("@UnitPrice",orderbook.UnitPrice)
                                 };
            DbHelp.GetExecuteNonQuery(sql,para);
            #endregion
     }
      public static OrderBook GetOrderbookByOrderid(int orderid)
      {
            #region 通过订单Id获取订单详细信息
            OrderBook orderbook = new OrderBook();
            string sql = "SELECT * FROM OrderBook WHERE OrderID=" + orderid;
            using (SqlDataReader dr = DbHelp.GetReader(sql))
            {
                if (dr.Read())
                {
                    orderbook.Id = Convert.ToInt32(dr["Id"]);
                    orderbook.Quantity = Convert.ToInt32(dr["Quantity"]);
                    orderbook.UnitPrice = Convert.ToDecimal(dr["UnitPrice"]);
                    int OrderId = Convert.ToInt32(dr["OrderID"]);
                    int bookid = Convert.ToInt32(dr["BookId"]);
                    dr.Close();
                    orderbook.Book = BookServer.GetBookDetailById(bookid);
                    orderbook.Order = OrdersServer.GetOrderById(OrderId);
                }
                else
                {
                    orderbook = null;
                }
            }
            return orderbook;
            #endregion
      }
      public static DataTable GetOrderBook(int orderid)
      {
            #region 通过订单Id获取订单详情的DataTable
          string sql = @"SELECT A.Id AS OrderBookId,C.ISBN AS ISBN ,D.Name AS Name ,A.Quantity AS Quantity,C.Title AS Title,A.UnitPrice AS UnitPrice,B.OrderDate AS OrderDate
FROM OrderBook AS A
RIGHT JOIN  Orders AS B
ON A.OrderID=B.Id
LEFT JOIN Books AS C
ON A.BookID=C.Id
LEFT JOIN Users AS D
ON B.UserId=D.Id
WHERE A.OrderId=
" + orderid;
          return DbHelp.GetDataTable(sql);
          #endregion 
      }
    }
}
