using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookShopModels;
using System.Data.SqlClient;
using System.Data;

namespace BookShopDAL
{
   public class UserStatesServer
    {
        public static UserStates GetUserStatesById(int Id)
        {
            #region 通过用户状态Id返回用户的状态信息
            UserStates userstates = new UserStates();
            string sql = "SELECT * FROM UserStates WHERE Id=" + Id;
            using (SqlDataReader dr = DbHelp.GetReader(sql))
            {
                if (dr.Read())
                {
                    userstates.Id = Convert.ToInt32(dr["Id"]);
                    userstates.Name = dr["Name"].ToString();
                }
            }
            return userstates;
            #endregion
        }
        public static DataTable GetAllUserState()
        {
            #region 获取所有用户状态
            String sql = "SELECT * From UserStates";
            return DbHelp.GetDataTable(sql);
            #endregion
        }
    }
}
