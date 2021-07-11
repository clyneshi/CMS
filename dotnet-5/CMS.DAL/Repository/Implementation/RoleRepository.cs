using CMS.DAL.Models;
using CMS.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CMS.DAL.Repository.Implementation
{
    public class RoleRepository : IRoleRepository
    {
        private readonly CMSContext _context;

        public RoleRepository(CMSContext context)
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
