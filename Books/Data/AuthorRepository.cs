using AutoMapper;
using AutoMapper.QueryableExtensions;
using Books.Dto;
using Books.Interfaces;
using Books.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Data
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        private readonly IMapper _mapper;
        public AuthorRepository(DataContext context) : base(context)
        {
             
        }
       
        public async Task<ActionResult<IEnumerable<GetAuthorDto>>> GetAllAuthors()
        {

            return await _context.AuthorInfo.ProjectTo<GetAuthorDto>(_mapper.ConfigurationProvider).ToListAsync();

        }

        public async Task<Author> GetAuthorsById(int id)
        {
            return await FindByCondition(d => d.AuthorId.Equals(id))
                .FirstOrDefaultAsync();
        }

        public void DeleteAuthor(Author author)
        {
            Remove(author);
        }
        public void UpdateAuthor(Author author)
        {
            Update(author);
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
