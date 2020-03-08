using CMS.DAL.Models;
using CMS.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace CMS.DAL.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly CMSDBEntities _context;

        public UserRepository(CMSDBEntities context)
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
    }
}
