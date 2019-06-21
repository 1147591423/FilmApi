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
    public class Details
    {
        static string sqlconn = ConfigurationManager.AppSettings["SqlConnection"];
        IDbConnection db = new SqlConnection(sqlconn);
        public List<CinemaList> CinemaShow(int CId)
        {
            string str = "select * from CinemaList where CId=@CId";
            var result = db.Query<CinemaList>(str,new { @CId=CId}).ToList();
            return result;
        }
        //获取图片信息
        public List<FilmInfo> FilmImg(int CId)
        {
            string str = "select distinct b.FilmPhotos, b.FId from CinemaWithFilm a inner join FilmInfo b on a.FId=b.FId inner join CinemaList c on a.CId=c.CId where c.CId=@CId";
            var result = db.Query<FilmInfo>(str, new { @CId = CId }).ToList();
            return result;
        } 
        //获取影片信息
        public List<FilmInfo> Filmparticulars(int Id)
        {
            string str = "select * from  ActorInfo a inner join  MovieActors b on a.AId=b.AId inner join FilmInfo c  on b.FId=c.FId where c.FId=@Id";
            var result = db.Query<FilmInfo>(str, new { @Id = Id }).ToList();
            return result;
        }
        public List<CinemaWithFilm> CinemaXinxi(int CId, int FId,DateTime ShowTime)
        {
            string str = "select * from CinemaWithFilm a inner join FilmInfo b on a.FId=b.FId inner join CinemaList c on a.CId=c.CId where c.CId=@CId and b.FId=@FId and CONVERT(varchar, a.ShowTime,23) = @ShowTime";
            var result = db.Query<CinemaWithFilm>(str, new { @CId = CId, @FId = FId ,@ShowTime=ShowTime}).ToList();
            return result;
        }
        //选座详情
        public List<CinemaWithFilm> GetSitXinxi(int WId)
        {
            string str = "select * from CinemaWithFilm a inner join FilmInfo b on a.FId=b.FId inner join CinemaList c on a.CId=c.CId where WId =@WId";
            var result = db.Query<CinemaWithFilm>(str, new { @WId = WId }).ToList();
            return result;
        }
       
    }
}
