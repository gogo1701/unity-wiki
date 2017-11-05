using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace UnityWeb.Data.Contracts
{
    public interface IUnityWikiDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        void Dispose();

        int SaveChanges();
    }
}
