using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Film.Model;
using Dapper;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Film.DAL
{
    public class FilmDal
    {
        static string sqlconn = ConfigurationManager.AppSettings["SqlConnection"];
        IDbConnection db = new SqlConnection(sqlconn);
        //热映口碑榜
        public List<FilmInfo> HotShow()
        {
            string str = "select top(10) b.FilmCName,CONVERT(varchar(100),b.FilmReleaseTime,23) FilmReleaseTime,b.FilmPhotos,b.Grade,c.ActorCName from MovieActors a inner join FilmInfo b on a.FId=b.FId inner join ActorInfo c on a.AId = c.AId order by Grade desc";
            var result = db.Query<FilmInfo>(str).ToList();
            return result;
        }
        //最受期待榜
        public List<FilmInfo> Anticipated()
        {
            string str = "select top(10) b.FilmCName,CONVERT(varchar(100),b.FilmReleaseTime,23)FilmReleaseTime,b.FilmPhotos,b.WantSee,c.ActorCName from MovieActors a inner join FilmInfo b on a.FId=b.FId inner join ActorInfo c on a.AId = c.AId order by WantSee desc";
            var result = db.Query<FilmInfo>(str).ToList();
            return result;
        }
        //票房榜
        public List<FilmInfo> Office()
        {
            string str = "select  top(10) b.FilmCName,CONVERT(varchar(100),b.FilmReleaseTime,23)FilmReleaseTime ,b.FilmPhotos,b.Filmoffice,c.ActorCName from MovieActors a inner join FilmInfo b on a.FId=b.FId inner join ActorInfo c on a.AId = c.AId order by Filmoffice desc";
            var result = db.Query<FilmInfo>(str).ToList();
            return result;
        }
    }
}
