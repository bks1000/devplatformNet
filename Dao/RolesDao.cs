using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dto;
using IDao;

namespace Dao
{
    public class RolesDao :IRolesDao
    {
        public List<roles> QueryAllRoles()
        {
            string sql = @"SELECT * FROM roles";
            return DapperService<roles>.GetInstance().QueryList(sql, null);
        }
    }
}
