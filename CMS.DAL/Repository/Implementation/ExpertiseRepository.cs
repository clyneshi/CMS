using CMS.DAL.Models;
using CMS.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DAL.Repository.Implementation
{
    public class ExpertiseRepository : IExpertiseRepository
    {
        private readonly CMSDBEntities _context;

        public ExpertiseRepository(CMSDBEntities context)
        {
            _context = context;
        }

        public void Add(Expertise expertise)
        {
            _context.Expertises.Add(expertise);
        }

        public IEnumerable<Expertise> Filter(Expression<Func<Expertise, bool>> predicate)
        {
            return _context.Expertises
                .Include(x => x.keyword)
                .Include(x => x.User)
                .Where(predicate)
                .ToList();
        }

        public IEnumerable<Expertise> GetAll()
        {
            return _context.Expertises
                .Include(x => x.keyword)
                .Include(x => x.User)
                .ToList();
        }

        public void Delete(Expertise expertise)
        {
            _context.Expertises.Remove(expertise);
        }
    }
}
