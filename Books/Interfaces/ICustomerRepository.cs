using Books.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Books.Interfaces
{
    public interface ICustomerRepository
    {
        void Update(Customer customer);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<Customer>> GetCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int id);
        Task<Customer> GetCustomerByUsernameAsync(string username);
    }
}
