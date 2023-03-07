using CMS.DAL.Models;
using CMS.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CMS.DAL.Repositories.Implementation;

public class PaperReviewRepository : IPaperReviewRepository
{
    private readonly CmsDbContext _context;

    public PaperReviewRepository(CmsDbContext context)
    {
        _context = context;
    }

    public async Task<PaperReview> AddAsync(PaperReview paperReview)
    {
        await _context.PaperReviews.AddAsync(paperReview);
        return paperReview;
    }

    public Task<List<PaperReview>> FilterAsync(Expression<Func<PaperReview, bool>> predicate)
    {
        return _context.PaperReviews
            .Include(x => x.Paper)
            .Include(x => x.User)
            .Where(predicate)
            .ToListAsync();
    }

    public void Delete(PaperReview paperReview)
    {
        _context.PaperReviews.Remove(paperReview);
    }

    public async Task ChangePaperRatingAsync(int paperReviewId, int rating)
    {
        var paperReview = await _context.PaperReviews.FindAsync(paperReviewId);
        paperReview.PaperRating = rating;
    }
}
