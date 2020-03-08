using CMS.DAL.Models;
using CMS.DAL.Repository.Implementation;
using System;
using System.Threading.Tasks;

namespace CMS.DAL.Core
{
    internal class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly CMSDBEntities _context;
        private readonly UserRepository _userRepository;

        public UnitOfWork()
        {
            _context = new CMSDBEntities();
            _userRepository = new UserRepository(_context);
        }

        public UserRepository UserRepository => _userRepository;

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed && disposing)
            {
                _context.Dispose();
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
