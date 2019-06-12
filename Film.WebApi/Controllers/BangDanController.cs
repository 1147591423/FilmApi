using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Film.DAL;
using Film.Model;

namespace Film.WebApi.Controllers
{
    public class BangDanController : ApiController
    {
        FilmDal dl = new FilmDal();
        //热映口碑榜
        [HttpGet]
        public List<FilmInfo> HotShow()
        {
            return dl.HotShow();
        }
        //最受期待榜
        [HttpGet]
        public List<FilmInfo> Anticipated()
        {
            return dl.Anticipated();
        }
        //票房榜
        [HttpGet]
        public List<FilmInfo> Office()
        {
            return dl.Office();
        }
    }
}
