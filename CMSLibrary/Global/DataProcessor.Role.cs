using CMSLibrary.Model;
using System.Collections.Generic;
using System.Linq;

namespace CMSLibrary.Global
{
    public static partial class DataProcessor
    {
        public static List<Role> GetRoles() => GlobalVariable.DbModel.Roles.ToList();

        public static Role GetRole(int? roleId) => GlobalVariable.DbModel.Roles.FirstOrDefault(r => r.roleId == roleId);
    }
}
