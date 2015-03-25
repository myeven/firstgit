using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShopModels
{
  public  class Publishers
    {
        private int _id;
        private string _name;
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
    }
}
