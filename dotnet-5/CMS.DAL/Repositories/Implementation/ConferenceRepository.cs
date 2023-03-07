using CMS.DAL.Models;
using CMS.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CMS.DAL.Repositories.Implementation;

public class ConferenceRepository : IConferenceRepository
{
    private readonly CmsDbContext _context;

    public ConferenceRepository(CmsDbContext context)
    {
        _context = context;
    }

    public async Task<Conference> AddAsync(Conference conference)
    {
        await _context.Conferences.AddAsync(conference);
        return conference;
    }

    public Task<List<Conference>> FilterAsync(Expression<Func<Conference, bool>> predicate)
    {
        return _context.Conferences.Where(predicate).ToListAsync();
    }

    public Task<List<Conference>> GetAllAsync()
    {
        return _context.Conferences.ToListAsync();
    }

    public Task<List<Conference>> GetConferencesWithChairAsync(Expression<Func<Conference, bool>> predicate = null)
    {
        var query = _context.Conferences.Include(x => x.Chair);

        if (predicate != null)
        {
            query.Where(predicate);
        }

        return query.ToListAsync();
    }
}
