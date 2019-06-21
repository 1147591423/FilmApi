using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Film.Model;
using Film.DAL;
using Newtonsoft.Json;

namespace Film.WebApi.Controllers
{
    public class DetailsController : ApiController
    {
        Details dl = new Details();
        [HttpGet]
        public List<CinemaList> CinemaShow(int CId)
        {
            return dl.CinemaShow(CId);
        }
        [HttpGet]
        public List<FilmInfo> FilmImg(int CId)
        {
            return dl.FilmImg(CId);
        }
        [HttpGet]
        public List<FilmInfo> Filmparticulars(int Id)
        {
            return dl.Filmparticulars(Id);
        }
        [HttpGet]
        public List<CinemaWithFilm> CinemaXinxi(int CId, int FId,DateTime ShowTime)
        {
            return dl.CinemaXinxi(CId,FId,ShowTime);
        }
        [HttpGet]
        public List<CinemaWithFilm> GetSitXinxi(int WId)
        {
            return dl.GetSitXinxi(WId);
        }
    }
}
