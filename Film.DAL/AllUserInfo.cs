using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Film.Model;

namespace Film.DAL
{
    public class AllUserInfo
    {
        static string sqlconn = ConfigurationManager.AppSettings["SqlConnection"];
        IDbConnection db = new SqlConnection(sqlconn);
        public List<UserInfo> BackDataByPhoneNum(string phoneNum)
        {
            string sql = "select * from UserInfo where PhoneNum =@PhoneNum";
            var result = db.Query<UserInfo>(sql,new { @PhoneNum=phoneNum}).ToList();
            return result;
        }
        public int EditUserInfo(UserInfo ui)
        {
            string sql = "update UserInfo set UserName = @UserName,UserSex=@UserSex,UserBirthday=@UserBirthday,UserImg=@UserImg where PhoneNum=@PhoneNum";
            var result = db.Execute(sql,new { @UserName=ui.UserName, @UserSex=ui.UserSex,@UserBirthday=ui.UserBirthday,@UserImg=ui.UserImg,@PhoneNum=ui.PhoneNum });
            return result;
        }
    }
}
