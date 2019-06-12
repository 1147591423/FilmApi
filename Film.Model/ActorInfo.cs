using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Film.Model
{
    public class ActorInfo
    {
        public int AId { get; set; }//主键
        public string ActorCName { get; set; }//演员中文名
        public string ActorEName { get; set; }//演员英文名
        public DateTime ActorBirthday { get; set; }//演员生日
        public string ActorRemark { get; set; }//演员介绍
        public string ActorBirthPlace { get; set; }//演员出生地
        public int ActorSex { get; set; }//演员性别
        public string ActorNationality { get; set; }//演员国籍
        public string ActorPhotos { get; set; }//演员照片
    }
}
