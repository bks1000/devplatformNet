using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dto;

namespace IDao
{
    public interface IRolesDao
    {
        List<roles> QueryAllRoles();
    }
}
