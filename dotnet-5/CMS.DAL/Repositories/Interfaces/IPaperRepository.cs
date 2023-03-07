using CMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CMS.DAL.Repositories.Interfaces;

public interface IPaperRepository : IRepository
{
    Task<Paper> AddAsync(Paper Paper);
    Task<List<Paper>> FilterAsync(Expression<Func<Paper, bool>> predicate);
    Task<List<Paper>> GetAllAsync();
    Task<List<Paper>> GetPapersWithAuthorAndConferenceAsync(Expression<Func<Paper, bool>> predicate = null);
    Task ChangePaperStatusAsync(int paperId, string status);
}