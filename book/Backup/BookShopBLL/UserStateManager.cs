using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookShopDAL;
using BookShopModels;
using System.Data;

namespace BookShopBLL
{
   public  class UserStateManager
    {
        public static DataTable GetAllUserState()
        {
            #region 获取所有用户状态
            return UserStatesServer.GetAllUserState();
            #endregion
        }
        public static UserStates GetUserStatesById(int Id)
        {
            #region 通过用户状态Id返回用户的状态信息
            
            return  UserStatesServer.GetUserStatesById(Id);
            #endregion
        }
    }
}
