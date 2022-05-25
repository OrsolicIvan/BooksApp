using Books.Models;

namespace Books.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(Customer user);
    }
}
