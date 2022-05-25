using System;

namespace Books.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAuthorRepository Authors { get; }
        int Complete();
    }
}
