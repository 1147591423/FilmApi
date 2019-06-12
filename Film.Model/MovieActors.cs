using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Film.Model
{
    public class MovieActors
    {
        public int MId { get; set; }//主键
        public int FId { get; set; }//电影Id
        public int AId { get; set; }//演员Id
    }
}
