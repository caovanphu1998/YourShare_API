using Equinox.Infra.Data.Context;
using System;
using System.Threading.Tasks;

namespace Equinox.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        EquinoxContext Context { get; }
        void Commit();
        Task CommitAsyn();
    }
}
