using CMS.DAL.Models;
using CMS.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CMS.DAL.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly CMSContext _context;

        public UserRepository(CMSContext context)
        {
            _context = context;
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
        }

        public IEnumerable<User> Filter(Expression<Func<User, bool>> predicate)
        {
            return _context.Users.Where(predicate).ToList();
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public void Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }

        public IEnumerable<User> GetUserWithRole(Expression<Func<User, bool>> predicate = null)
        {
            var query = _context.Users.Include(x => x.Role);

            if (predicate != null)
            {
                query.Where(predicate);
            }

            return query.ToList();
        }
    }
}
