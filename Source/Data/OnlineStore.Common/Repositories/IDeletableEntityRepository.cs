using System.Linq;

namespace OnlineStore.Common.Repositories
{
    public interface IDeletableEntityRepository<T> : IRepository<T> where T : class
    {
        IQueryable<T> AllWithDeleted();

        void ActualDelete(T Entity);
    }
}
