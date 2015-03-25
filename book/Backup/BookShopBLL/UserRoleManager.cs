using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookShopDAL;
using BookShopModels;
using System.Data;
namespace BookShopBLL
{
  public class UserRoleManager
    {
        public static DataTable GetAllUserRoles()
        {
            #region 获取所有用户角色

            return UserRolesServer.GetAllUserRoles();

            #endregion
        }
        public static UserRoles GetUserRolesById(int Id)
        {
            #region 通过用户角色Id返回用户的角色信息

            return UserRolesServer.GetUserRolesById(Id);
            #endregion
        }
    }
}
