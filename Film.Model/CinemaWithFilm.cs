using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Film.Model
{
    public class CinemaWithFilm
    {
        public int WId { get; set; }
        public int CId { get; set; }
        public int FId { get; set; }
        public DateTime ShowTime { get; set; }
        public string LanguageVersion { get; set; }
        public string Screens { get; set; }
        public decimal FilmPrice { get; set; }
        public string ShowBegin { get; set; }
        public string ShowEnd { get; set; }
        public string FilmCName { get; set; }
        public string FilmEName { get; set; }
        public string FilmType { get; set; }
        public string FilmSource { get; set; }
        public string FilmLength { get; set; }
        public DateTime FilmReleaseTime { get; set; }
        public int WantSee { get; set; }
        public float Grade { get; set; }
        public string FilmIntroduced { get; set; }
        public string FilmPhotos { get; set; }
        public float Filmoffice { get; set; }
    }
}
