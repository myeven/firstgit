using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookShopModels;
using System.Data;
using System.Data.SqlClient;

namespace BookShopDAL
{
   public class OrdersServer
    {
       public static Orders AddOrder(Orders order)
       {
           #region 添加订单
           string sql = "INSERT INTO Orders(OrderDate,UserId,TotalPrice) VALUES(@OrderDate,@UserId,@TotalPrice)";
           sql += ";select @@IDENTITY";
           SqlParameter[] para = {
                                     new SqlParameter("@OrderDate",order.OrderDate),
                                     new SqlParameter("@UserId",order.User.ID),
                                     new SqlParameter("@TotalPrice",order.TotalPrice)
                                 };
           int id = DbHelp.GetScalar(sql,para);
           Orders orders = GetOrderById(id);
           return orders;
           #endregion
       }
       public static Orders GetOrderById(int id)
       {
           #region 通过订单Id获取订单信息
           Orders order = new Orders();
           string sql = "SELECT * FROM Orders WHERE Id=" + id;
           using (SqlDataReader dr = DbHelp.GetReader(sql))
           {
               if (dr.Read())
               {
                   order.Id = Convert.ToInt32(dr["Id"]);
                   order.OrderDate = Convert.ToDateTime(dr["OrderDate"]);
                   order.TotalPrice = Convert.ToInt32(dr["TotalPrice"]);
                   int userid = Convert.ToInt32(dr["UserId"]);
                   dr.Close();
                   order.User = UserServer.GetUserById(userid);
               }
               else
               {
                   order = null;
               }
           }
           return order;
           #endregion
       }
       public static DataTable GetOrdersByName(string name)
       {
           #region 用户名显示订单
           string sql = @"SELECT A.*,B.Name AS UserName 
FROM Orders AS A
JOIN Users AS B
ON A.UserId=B.Id WHERE B.Name='"+name+"'";
          
           return DbHelp.GetDataTable(sql);
           #endregion
       }
       public static DataTable GetAllOrders(string stardate, string enddate)
       {
           #region 显示所有订单
           string sql = @"SELECT A.*,B.Name AS UserName 
FROM Orders AS A
JOIN Users AS B
ON A.UserId=B.Id ";
           if (stardate != "" && enddate != "")
           {
               sql += "WHERE OrderDate BETWEEN '" + stardate + "'AND '" + enddate + "'";
           }
           return DbHelp.GetDataTable(sql);
           #endregion
       }
       public static void DeleteOrderById(int Id)
       {
           #region 删除订单
           string sql = "DELETE FROM Orders WHERE Id="+Id;
           DbHelp.GetExecuteNonQuery(sql);
           #endregion
       }
    }
}
