using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookShopModels;
using BookShopDAL;
using System.Data;
using System.Data.SqlClient;

namespace BookShopBLL
{
   public class OrderManager
    {
        public static Orders AddOrder(Orders order)
        {
            #region 添加订单
            return OrdersServer.AddOrder(order);
            #endregion
        }
        public static Orders GetOrderById(int id)
        {
            #region 通过订单Id获取订单信息
            return OrdersServer.GetOrderById(id);
            #endregion
        }
        public static DataTable GetAllOrders(string stardate, string enddate)
        {
            #region 显示所有订单
            return OrdersServer.GetAllOrders(stardate, enddate);
            #endregion
        }
        public static DataTable GetOrdersByName(string name)
        {
            #region 用户名显示订单
            return OrdersServer.GetOrdersByName(name);
            #endregion
        }
        public static void DeleteOrderById(int Id)
        {
            #region 删除订单
            OrdersServer.DeleteOrderById(Id);
            #endregion
        }
    }
}
