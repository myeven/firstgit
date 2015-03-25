using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookShopModels;
using BookShopDAL;
using System.Data;

namespace BookShopBLL
{
    public class UserManager
    {
        public static Users Login(string LoginId, string LoginPwd)
        {
            #region 通过用户名返回用户信息
            Users users = UserServer.GetUsersByLoginId(LoginId);
            if (users == null)
            {
                return users;
            }
            else
            {
                if (users.LoginPwd == LoginPwd)
                {
                    return users;
                }
                else
                {
                    users = null;
                    return users;
                }
            }
            #endregion
        }
        public static Users GetUserById(int Id)
        {
            #region 通过用户Id返回用户信息
            return UserServer.GetUserById(Id);
            #endregion
        }
        public static bool UserReg(Users user)
        {
            #region 注册用户
            if (UserServer.GetUsersByLoginId(user.LoginId) == null)
            {
                return UserServer.AddUser(user);
            }
            else
            {
                return false;
            }
            #endregion
        }
        public static DataTable GetAllUsers(string Search)
        {
            #region 根据搜索关键字获取用户列表
            return UserServer.GetAllUsers(Search);
            #endregion
        }
        public static void DeleteUserById(int Id)
        {
            #region 根据用户Id删除用户
            UserServer.DeleteUserById(Id);
            #endregion
        }
        public static bool UpdateUser(Users user)
        {
            #region 更新用户信息
            return UserServer.UpdateUser(user);
            #endregion
        }
    }
}
