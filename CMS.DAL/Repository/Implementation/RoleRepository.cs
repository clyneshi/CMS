using CMS.DAL.Models;
using CMS.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DAL.Repository.Implementation
{
    public class RoleRepository : IRoleRepository
    {
        private readonly CMSDBEntities _context;

        public RoleRepository(CMSDBEntities context)
        {
            _context = context;
        }

        public IEnumerable<Role> Filter(Expression<Func<Role, bool>> predicate)
        {
            return _context.Roles.Where(predicate).ToList();
        }

        public IEnumerable<Role> GetAll()
        {
            return _context.Roles.ToList();
        }
    }
}
