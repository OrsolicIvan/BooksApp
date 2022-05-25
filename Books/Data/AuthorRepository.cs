using Books.Interfaces;
using Books.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Data
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(DataContext context) : base(context)
        {

        }
        public IEnumerable<Author> GetAllAuthors(int count)
        {
            return _context.AuthorInfo.OrderByDescending(d => d.AuthorId).Take(count).ToList();
        }


        //public void Delete(Author author)
        //{
        //    _context.Entry(author).State = EntityState.Deleted;
        //}

        //public async Task<Author> GetAuthorByIdAsync(int id)
        //{
        //    return await _context.AuthorInfo.FindAsync(id);
        //}

        //public async Task<Author> GetAuthorByUsernameAsync(string username)
        //{
        //    return await _context.AuthorInfo.SingleOrDefaultAsync(x => x.AuthorName == username);
        //}

        //public async Task<IEnumerable<Author>> GetAuthorsAsync()
        //{
        //    return await _context.AuthorInfo.ToListAsync();
        //}

        //public async Task<bool> SaveAllAsync()
        //{
        //    return await _context.SaveChangesAsync() > 0;
        //}

        //public void Update(Author author)
        //{
        //    _context.Entry(author).State = EntityState.Modified;
        //}
    }
}
