using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShopModels
{
   public class Orders
    {
       private int _id;
       private DateTime _orderdate;
       private Users _users;
       private decimal _totalprice;
       public int Id
       {
           get { return _id; }
           set { _id = value; }
       }
       public DateTime OrderDate
       {
           get { return _orderdate; }
           set { _orderdate = value; }
       }
       public Users User
       {
           get { return _users; }
           set { _users = value; }
       }
       public decimal TotalPrice
       {
           get { return _totalprice; }
           set { _totalprice = value; }
       }
    }
}
