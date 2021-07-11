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
    public class PaperRepository : IPaperRepository
    {
        private readonly CMSContext _context;

        public PaperRepository(CMSContext context)
        {
            _context = context;
        }

        public async Task<Paper> AddAsync(Paper paper)
        {
            await _context.Papers.AddAsync(paper);
            return paper;
        }

        public Task<List<Paper>> FilterAsync(Expression<Func<Paper, bool>> predicate)
        {
            return _context.Papers.Where(predicate).ToListAsync();
        }

        public Task<List<Paper>> GetAllAsync()
        {
            return _context.Papers.ToListAsync();
        }

        public async Task ChangePaperStatusAsync(int paperId, string status)
        {
            var paper = await _context.Papers.FindAsync(paperId);
            paper.Status = status;
        }

        public Task<List<Paper>> GetPapersWithAuthorAndConferenceAsync(Expression<Func<Paper, bool>> predicate = null)
        {
            var query = _context.Papers.Include(x => x.AuthorNavigation).Include(x => x.Conference);

            if (predicate != null)
            {
                query.Where(predicate);
            }

            return query.ToListAsync();
        }
    }
}
