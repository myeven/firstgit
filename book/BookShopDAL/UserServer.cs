using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookShopModels;
using System.Data.SqlClient;
using System.Data;

namespace BookShopDAL
{
    public class UserServer
    {
        public static Users GetUsersByLoginId(string LoginId)
        {
            #region 通过用户名返回用户信息
            Users users = new Users();
            string sql = "SELECT * FROM Users WHERE LoginId='" + LoginId + "'";    
            using(SqlDataReader dr=DbHelp.GetReader(sql))
            {
                if (dr.Read())
                {
                    users.ID = Convert.ToInt32(dr["ID"]);
                    users.LoginId = dr["LoginId"].ToString();
                    users.LoginPwd = dr["LoginPwd"].ToString();
                    users.Name = dr["Name"].ToString();
                    users.Phone = dr["Phone"].ToString();
                    users.Address = dr["Address"].ToString();
                    users.Mail = dr["Mail"].ToString();
                    int userroleid = Convert.ToInt32(dr["UserRoleId"]);
                    int userrolestate = Convert.ToInt32(dr["UserStateId"]);
                    dr.Close();
                    users.UserRoles = UserRolesServer.GetUserRolesById(userroleid);
                    users.UserStates = UserStatesServer.GetUserStatesById(userrolestate);
                }
                else
                {
                    users = null;
                }
            }
            return users;
            #endregion
        }
        public static Users GetUserById(int Id)
        {
            #region 通过用户Id返回用户信息
            Users users = new Users();
            string sql = "SELECT * FROM Users WHERE Id=" + Id ;
            using (SqlDataReader dr = DbHelp.GetReader(sql))
            {
                if (dr.Read())
                {
                    users.ID = Convert.ToInt32(dr["ID"]);
                    users.LoginId = dr["LoginId"].ToString();
                    users.LoginPwd = dr["LoginPwd"].ToString();
                    users.Name = dr["Name"].ToString();
                    users.Phone = dr["Phone"].ToString();
                    users.Address = dr["Address"].ToString();
                    users.Mail = dr["Mail"].ToString();
                    int userroleid = Convert.ToInt32(dr["UserRoleId"]);
                    int userrolestate = Convert.ToInt32(dr["UserStateId"]);
                    dr.Close();
                    users.UserRoles = UserRolesServer.GetUserRolesById(userroleid);
                    users.UserStates = UserStatesServer.GetUserStatesById(userrolestate);
                }
                else
                {
                    users = null;
                }
            }
            return users;
            #endregion
        }
        public static bool AddUser(Users user)
        {
            #region 注册用户
            if (user.UserRoles==null)
            {
                user.UserRoles = UserRolesServer.GetUserRolesById(1);
            }
            if (user.UserStates==null)
            {
                user.UserStates = UserStatesServer.GetUserStatesById(1);
            }
            string sql = @"INSERT INTO Users(LoginId,LoginPwd,Name,Address,Phone,Mail,UserRoleId,UserStateId) 
                           VALUES(@LoginId,@LoginPwd,@Name,@Address,@Phone,@Mail,@UserRoleId,@UserStateId)";
            SqlParameter[] para ={
                                     new SqlParameter("@LoginId",user.LoginId),
                                     new SqlParameter("@LoginPwd",user.LoginPwd),
                                     new SqlParameter("@Address",user.Address),
                                     new SqlParameter("@Phone",user.Phone),
                                     new SqlParameter("@Mail",user.Mail),
                                     new SqlParameter("@Name",user.Name),
                                     new SqlParameter("@UserRoleId",user.UserRoles.Id),
                                     new SqlParameter("@UserStateId",user.UserStates.Id)
                                 };
            int count=DbHelp.ExecuteCommand(sql, para);
            if (count> 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            #endregion
        }
        public static DataTable GetAllUsers(string Search)
        {
            #region 根据搜索关键字获取用户信息
            string sql = @"SELECT a.Id AS UserId,LoginId,Address,a.Name AS UserName,Mail,Phone,b.Name AS UserRole,b.Id As UserRoleId,  c.Name AS UserState,c.Id AS UserStateId 
FROM Users AS a 
LEFT JOIN UserRoles AS b 
ON a.UserRoleId=b.Id 
LEFT JOIN  UserStates AS c
ON a.UserStateId=c.Id WHERE 1=1  ";
            if (Search != "")
            {
                sql += " AND LoginId LIKE'%" + Search + "%' OR Address LIKE'%" + Search + "%' OR Mail LIKE'%" + Search + "%' OR Phone LIKE'%" + Search + "%' OR LoginId LIKE'%" + Search + "%' OR a.Name LIKE'%" + Search + "%' OR b.Name LIKE'%" + Search + "%'OR c.Name LIKE'%" + Search + "%'";
            }
            return DbHelp.GetDataTable(sql);
            #endregion
        }
        public static void DeleteUserById(int Id)
        {
            #region 根据用户Id删除用户
            string sql = "DELETE FROM Users WHERE Id=" + Id;
            DbHelp.GetExecuteNonQuery(sql);
            #endregion
        }
        public static bool UpdateUser(Users user)
        {
            #region 更新用户信息
            string sql = @"UPDATE Users SET LoginId=@LoginId,LoginPwd=@LoginPwd,Name=@Name,Address=@Address,Phone=@Phone,Mail=@Mail,UserRoleId=@UserRoleId,UserStateId=@UserStateId WHERE Id=@Id";
            SqlParameter[] para ={
                                     new SqlParameter("@LoginId",user.LoginId),
                                     new SqlParameter("@LoginPwd",user.LoginPwd),
                                     new SqlParameter("@Address",user.Address),
                                     new SqlParameter("@Phone",user.Phone),
                                     new SqlParameter("@Mail",user.Mail),
                                     new SqlParameter("@Name",user.Name),
                                     new SqlParameter("@UserRoleId",user.UserRoles.Id),
                                     new SqlParameter("@UserStateId",user.UserStates.Id),
                                     new SqlParameter("@Id",user.ID)
                                 };
            int count = DbHelp.ExecuteCommand(sql, para);
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            #endregion
        }
    }
}
