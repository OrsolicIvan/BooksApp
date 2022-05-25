using Books.Interfaces;
using Books.Models;

namespace Books.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly DataContext _context;
        public UnitOfWork(DataContext context)
        {
            _context = context;
            Authors = new AuthorRepository(_context);
            
        }
        public IAuthorRepository Authors { get; private set; }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
