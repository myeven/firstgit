using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookShopModels;
using System.Data.SqlClient;
using System.Data;

namespace BookShopDAL
{
   public class UserRolesServer
    {
        public static UserRoles GetUserRolesById(int Id)
       {
           #region 通过用户角色Id返回用户的角色信息
           UserRoles userroles = new UserRoles();
            string sql = "SELECT * FROM UserRoles WHERE Id="+Id;
            using(SqlDataReader dr=DbHelp.GetReader(sql))
            {
                if (dr.Read())
                {
                    userroles.Id = Convert.ToInt32(dr["Id"]);
                    userroles.Name = dr["Name"].ToString();
                }
            }
            return userroles;
            #endregion
        }
        public static DataTable GetAllUserRoles()
        {
            #region 获取所有用户角色
            String sql = "SELECT * From UserRoles";
            return DbHelp.GetDataTable(sql);
            #endregion
        }
    }
}
