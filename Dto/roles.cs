using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class roles
    {
        public int rid { get; set; }//自增主键
        public string rname { get; set; }
        public string description { get; set; }
        public string isadmin { get; set; }
    }
}
