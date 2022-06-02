using Books.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Books.Interfaces
{
    public interface IAuthorRepository : IGenericRepository<Author>
    {
        IEnumerable<Author> GetAll();
        Task<Author> GetAuthorsById(int id);
        void DeleteAuthor(Author author);
        void UpdateAuthor(Author author);
    }
}
