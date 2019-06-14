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
        [HttpGet]
        public string UserLogin(string userName, string passWord)
        {
            try
            {
                if (userName == null || passWord == null)
                {
                    Log.FileLogService.Instance.Info($"空数据");
                    return "null";
                }
                Log.FileLogService.Instance.Info($"用户名{userName}");
                return lg.UserLogin(userName, passWord);
            }
            catch (Exception)
            {

                throw;
            }

        }
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
        [HttpPost]
        public int RegisterUser(string ui)
        {
            try
            {
                UserInfo model = JsonConvert.DeserializeObject<UserInfo>(ui);
                Log.FileLogService.Instance.Info($"用户手机号{model.PhoneNum}");
                return lg.RegisterUser(model);
            }
            catch (Exception)
            {

                throw;
            }

        }
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
        [HttpGet]
        public List<FilmInfo> FilmOrderByGradee()
        {
            return fp.FilmOrderByGradee();
        }
        [HttpPut]
        public int EditUserPwd(string phoneNum, string passWord)
        {
            try
            {
                Log.FileLogService.Instance.Info($"用户手机号{phoneNum}");
                return lg.EditUserPwd(phoneNum, passWord);
            }
            catch (Exception)
            {

                throw;
            }

        }
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
        [HttpPut]
        public int EditUserInfo(UserInfo ui)
        {
            return ai.EditUserInfo(ui);
        }
    }
}
