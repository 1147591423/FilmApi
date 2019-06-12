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
namespace Film.WebApi.Controllers
{
    public class LoginAndFirstPageController : ApiController
    {
        Login lg = new Login();
        FirstPage fp = new FirstPage();
        [HttpGet]
        public UserInfo UserLogin(string userName, string passWord)
        {
            Log.FileLogService.Instance.Info($"用户名{userName}-密码{passWord}");


            return lg.UserLogin(userName, passWord);
        }
        [HttpGet]
        public List<FilmInfo> GetFilm()
        {
            return fp.GetFilm();
        }
        [HttpPost]
        public int RegisterUser(UserInfo ui)
        {
            return lg.RegisterUser(ui);
        }
        [HttpGet]
        public List<FilmInfo> FilmOrderByOffice()
        {
            return fp.FilmOrderByOffice();
        }
        [HttpGet]
        public List<FilmInfo> FilmOrderByGradee()
        {
            return fp.FilmOrderByGradee();
        }
    }
}
