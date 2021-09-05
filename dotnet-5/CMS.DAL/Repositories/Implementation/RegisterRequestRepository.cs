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
    public class RegisterRequestRepository : IRegisterRequestRepository
    {
        private readonly CmsDbContext _context;

        public RegisterRequestRepository(CmsDbContext context)
        {
            _context = context;
        }

        public async Task<RegisterRequest> AddAsync(RegisterRequest registerRequest)
        {
            await _context.RegisterRequests.AddAsync(registerRequest);
            return registerRequest;
        }

        public Task<List<RegisterRequest>> FilterAsync(Expression<Func<RegisterRequest, bool>> predicate)
        {
            return _context.RegisterRequests
                .Include(x => x.Conference)
                .Include(x => x.Role)
                .Where(predicate)
                .ToListAsync();
        }

        public async Task ChangeRegisterRequestStatusAsync(int requestId, string status)
        {
            var registerRequest = await _context.RegisterRequests.FindAsync(requestId);
            registerRequest.Status = status;
        }
    }
}
