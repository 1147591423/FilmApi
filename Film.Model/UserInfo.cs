using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Film.Model
{
    public class UserInfo
    {
        public int UId { get; set; }
        public string PhoneNum { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public int UserSex { get; set; }
        public DateTime UserBirthday { get; set; }
        public string UserImg { get; set; }
    }
}
