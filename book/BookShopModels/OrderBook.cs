using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShopModels
{
   public  class OrderBook
    {
       private int _id;
       private Orders _order;
       private Books _book;
       private int _quantity;
       private decimal _unitprice;
       public int Id
       {
           get { return _id; }
           set { _id = value; }
       }
       public Orders Order
       {
           get { return _order; }
           set { _order = value; }
       }
       public Books Book
       {
           get { return _book; }
           set { _book = value; }
       }
       public int Quantity
       {
           get { return _quantity; }
           set { _quantity = value; }
       }
       public decimal UnitPrice
       {
           get { return _unitprice; }
           set { _unitprice = value; }
       }
    }
}
