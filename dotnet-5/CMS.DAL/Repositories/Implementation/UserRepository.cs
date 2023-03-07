using CMS.DAL.Models;
using CMS.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CMS.DAL.Repositories.Implementation;

public class UserRepository : IUserRepository
{
    private readonly CmsDbContext _context;

    public UserRepository(CmsDbContext context)
    {
        _context = context;
    }

    public async Task<User> AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
        return user;
    }

    public async Task<List<User>> FilterAsync(Expression<Func<User, bool>> predicate)
    {
        return await _context.Users.Where(predicate).ToListAsync();
    }

    public async Task<List<User>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task UpdateAsync(User untracked)
    {
        var user = await _context.Users.FindAsync(untracked.Id);

        user.Name = untracked.Name;
        user.Email = untracked.Email;
        user.Contact = untracked.Contact;
        user.Password = untracked.Password;
    }

    public Task<List<User>> GetUserWithRoleAsync(Expression<Func<User, bool>> predicate = null)
    {
        var query = _context.Users.Include(x => x.Role);

        if (predicate != null)
        {
            query.Where(predicate);
        }

        return query.ToListAsync();
    }
}
