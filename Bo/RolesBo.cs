using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBO;
using IDao;

namespace Bo
{
    public class RolesBo : IRolesBo
    {
        private IRolesDao dal;

        public RolesBo(IRolesDao dao)
        {
            dal = dao;
        }

        public List<Dto.roles> QueryAllRoles()
        {
            return dal.QueryAllRoles();
        }
    }
}
