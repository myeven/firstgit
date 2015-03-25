using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShopModels
{
   public class Users
    {
        private int _id;
        private string _loginid;
        private string _name;
        private string _loginpwd;
        private string _mail;
        private string _address;
        private string _phone;
        private UserRoles _userroles;
        private UserStates _userstates;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public string LoginId
        {
            get { return _loginid; }
            set { _loginid = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string LoginPwd
        {
            get { return _loginpwd; }
            set { _loginpwd = value; }
        }
        public string Mail
        {
            get { return _mail; }
            set { _mail = value; }
        }
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        public UserRoles UserRoles
        {
            get { return _userroles; }
            set { _userroles = value; }
        }
        public UserStates UserStates
        {
            get { return _userstates; }
            set { _userstates = value; }
        }            
    }
}
