using CMS.Library.Model;
using System.Collections.Generic;
using System.Linq;

namespace CMS.Library.Global
{
    public static partial class DataProcessor
    {
        public static List<Role> GetRoles()
        {
            return GlobalVariable.DbModel.Roles.ToList();
        }

        public static Role GetRole(int? roleId)
        {
            return GlobalVariable.DbModel.Roles.FirstOrDefault(r => r.roleId == roleId);
        }
    }
}
