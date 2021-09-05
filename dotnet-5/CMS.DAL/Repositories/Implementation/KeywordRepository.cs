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
    public class KeywordRepository : IKeywordRepository
    {
        private readonly CmsDbContext _context;

        public KeywordRepository(CmsDbContext context)
        {
            _context = context;
        }

        public Task<List<Keyword>> GetAllAsync()
        {
            return _context.Keywords.ToListAsync();
        }
    }
}
