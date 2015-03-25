using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookShopDAL;
using System.Data;
using BookShopModels;
//~5~1~a~s~p~x~
namespace BookShopBLL
{
  public  class PublisherManager
    {
      public static DataTable GetDataTableByCategories()
      {
          #region 返回所有的图书出版社
          return  PublisherServer.GetDataTableByCategories();
          #endregion
      }
      public static Publishers GetPublishersById(int Id)
      {
          #region 根据图书出版社Id获取出版社信息
          return PublisherServer.GetPublishersById(Id);
          #endregion
      }
    }
}
