using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookShopModels;
using System.Data;
using System.Data.SqlClient;
using BookShopDAL;

namespace BookShopBLL
{
   public class OrderBookManager
    {
        public static void AddOrderBook(OrderBook orderbook)
        {
            #region 添加订单详情
            OrderBookServer.AddOrderBook(orderbook);
            #endregion
        }
        public static OrderBook GetOrderbookByOrderid(int orderid)
        {
            #region 通过订单Id获取订单详细信息
            return OrderBookServer.GetOrderbookByOrderid(orderid);
            #endregion
        }
        public static DataTable GetOrderBook(int orderid)
        {
            #region 通过订单Id获取订单详情的DataTable
            return OrderBookServer.GetOrderBook(orderid);
            #endregion
        }
    }
}
