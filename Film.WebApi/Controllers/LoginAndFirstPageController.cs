using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using Film.DAL;
using Film.Model;
using Newtonsoft.Json;
namespace Film.WebApi.Controllers
{
    public class LoginAndFirstPageController : ApiController
    {
        Login lg = new Login();
        FirstPage fp = new FirstPage();
        AllUserInfo ai = new AllUserInfo();
        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        [HttpGet]
        public string UserLogin(string userName, string passWord)
        {
            try
            {
                if (userName == null || passWord == null)
                {
                    Log.FileLogService.Instance.Info("空数据");
                    return "null";
                }
                Log.FileLogService.Instance.Info($"用户登录.用户名{userName}");
                return lg.UserLogin(userName, passWord);
            }
            catch (Exception)
            {

                throw;
            }

        }
        /// <summary>
        /// 获取所有电影
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<FilmInfo> GetFilm()
        {
            try
            {
                return fp.GetFilm();
            }
            catch (Exception)
            {

                throw;
            }

        }
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="ui"></param>
        /// <returns></returns>
        [HttpPost]
        public int RegisterUser(string ui)
        {
            try
            {
                UserInfo model = JsonConvert.DeserializeObject<UserInfo>(ui);
                Log.FileLogService.Instance.Info($"用户注册.用户手机号{model.PhoneNum}");
                return lg.RegisterUser(model);
            }
            catch (Exception)
            {

                throw;
            }

        }
        /// <summary>
        /// 票房排序
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<FilmInfo> FilmOrderByOffice()
        {
            try
            {
                return fp.FilmOrderByOffice();
            }
            catch (Exception)
            {

                throw;
            }

        }
        /// <summary>
        /// 评分排序
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<FilmInfo> FilmOrderByGradee()
        {
            return fp.FilmOrderByGradee();
        }
        /// <summary>
        /// 修改没密码
        /// </summary>
        /// <param name="phoneNum"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        [HttpPut]
        public int EditUserPwd(string phoneNum, string passWord)
        {
            try
            {
                Log.FileLogService.Instance.Info($"修改密码.用户手机号{phoneNum}");
                return lg.EditUserPwd(phoneNum, passWord);
            }
            catch (Exception)
            {

                throw;
            }

        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="AName"></param>
        /// <returns></returns>
        [HttpGet]
        
        public List<FilmInfo> SearchFilm(string AName)
        {
            return fp.SearchFilm(AName);
        }
        [HttpGet]
        public List<UserInfo> BackDataByPhoneNum(string phoneNum)
        {
            return ai.BackDataByPhoneNum(phoneNum);
        }
        /// <summary>
        /// /修改用户信息
        /// </summary>
        /// <param name="ui"></param>
        /// <returns></returns>
        [HttpPut]
        public int EditUserInfo(string ui)
        {
            try
            {
                var result = JsonConvert.DeserializeObject<UserInfo>(ui);
                Log.FileLogService.Instance.Info($"修改信息.用户手机号{result.PhoneNum}");
                return ai.EditUserInfo(result);
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
