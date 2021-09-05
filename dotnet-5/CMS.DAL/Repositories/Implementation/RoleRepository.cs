using CMS.DAL.Models;
using CMS.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CMS.DAL.Repositories.Implementation
{
    public class RoleRepository : IRoleRepository
    {
        private readonly CmsDbContext _context;

        public RoleRepository(CmsDbContext context)
        {
            _context = context;
        }

        public Task<List<Role>> FilterAsync(Expression<Func<Role, bool>> predicate)
        {
            return _context.Roles.Where(predicate).ToListAsync();
        }

        public Task<List<Role>> GetAllAsync()
        {
            return _context.Roles.ToListAsync();
        }
    }
}
