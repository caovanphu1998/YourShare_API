using Equinox.Domain.Interfaces;
using Equinox.Infra.Data.Context;
using System.Threading.Tasks;

namespace Equinox.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        public EquinoxContext Context { get; }

        public UnitOfWork(EquinoxContext context)
        {
            Context = context;
        }
        public void Commit()
        {
            Context.SaveChanges();
        }

        public async Task CommitAsyn()
        {
            await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Context.Dispose();

        }
    }
}
