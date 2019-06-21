using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Dapper;
using Film.Model;
using System.Security.Cryptography;

namespace Film.DAL
{
    public class Login
    {
        static string sqlconn = ConfigurationManager.AppSettings["SqlConnection"];
        IDbConnection db = new SqlConnection(sqlconn);
        // MD5加密
        public static string GetMd5(string str)
        { 
            MD5 md5 = MD5.Create();
            byte[] buffer = Encoding.Default.GetBytes(str);
            byte[] Md5buffer = md5.ComputeHash(buffer);
            string n = "";
            for (int i = 0; i < Md5buffer.Length; i++)
            {
                n += Md5buffer[i].ToString("x2");
            }
            return n;
        }
        public string UserLogin(string Num,string Password)
        {
            try
            {
                string sql = "select * from UserInfo where PhoneNum = @PhoneNum and [Password] = @Password";
                var result = db.Query<UserInfo>(sql, new { @PhoneNum = Num, @Password = GetMd5(Password) }).FirstOrDefault();
                return result.ToString();
            }
            catch 
            {

                throw;
            }
        }
        public int RegisterUser(UserInfo ui)
        {
            try

            {
                string sql = "insert into UserInfo values(@PhoneNum ,@Password ,@UserName ,@UserSex ,@UserBirthday ,@UserImg )";
                var result = db.Execute(sql, new { @PhoneNum = ui.PhoneNum, @Password = GetMd5(ui.Password), @UserName = ui.PhoneNum, @UserSex = 0, @UserBirthday = "", @UserImg = "" });
                return result;
            }
            catch
            {
                return 0;
            }           
        }
        public int EditUserPwd(string phoneNum,string passWord)
        {
            try
            {
                string sql = "update UserInfo set Password = @Password where PhoneNum = @phoneNum";
                var resule = db.Execute(sql, new { @Password = GetMd5(passWord), @phoneNum = phoneNum });
                return resule;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
