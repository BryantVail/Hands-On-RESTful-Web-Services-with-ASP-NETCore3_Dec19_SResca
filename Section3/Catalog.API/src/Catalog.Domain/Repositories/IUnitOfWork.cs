using System;
using System.Collections.Generic;
using System.Text;
//class namespaces
using System.Threading;
using System.Threading.Tasks;

namespace Catalog.Domain.Repositories
{

    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));

        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }

    //public interface IUnitOfWork : IDisposable
    //{

    //    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    //    Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken));

    //}
}
