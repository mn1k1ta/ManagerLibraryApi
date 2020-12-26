using DAL.Interfaces;
using DAL.Repository;
using System;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDocumentModelRepository taskModelRepository;
        private IUserModelRepository userModelRepository;
        private LibraryDbContext _context;
        public UnitOfWork(LibraryDbContext context)
        {
            this._context = context;
        }
        public IUserModelRepository UserModelRepository
        {
            get
            {
                if (userModelRepository == null)
                    userModelRepository = new UserModelRepository(_context);
                return userModelRepository;
            }
        }
        public IDocumentModelRepository TaskModelRepository 
        { 
            get
            {
                if (taskModelRepository == null)
                    taskModelRepository = new DocumentModelRepository(_context);
                return taskModelRepository;
            }
        }

        public async Task SaveAsync()
        {
           await _context.SaveChangesAsync();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            { 
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
