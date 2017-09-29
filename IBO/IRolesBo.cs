using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dto;

namespace IBO
{
    public interface IRolesBo
    {
        List<roles> QueryAllRoles();
    }
}
