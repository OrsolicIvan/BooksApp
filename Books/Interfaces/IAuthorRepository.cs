using Books.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Books.Interfaces
{
    public interface IAuthorRepository : IGenericRepository<Author>
    {
        IEnumerable<Author >GetAllAuthors(int count);

    }
}
