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
    public class KeywordRepository : IKeywordRepository
    {
        private readonly CMSContext _context;

        public KeywordRepository(CMSContext context)
        {
            _context = context;
        }

        public Task<List<Keyword>> GetAllAsync()
        {
            return _context.Keywords.ToListAsync();
        }
    }
}
