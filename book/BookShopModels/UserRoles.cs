using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//_5_1_a_s_p_x
namespace BookShopModels
{
    public class UserRoles
    {
        private int _id;
        private string _name;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}
