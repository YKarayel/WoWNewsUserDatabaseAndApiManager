using WoWNewsApi.Repositories;

namespace WoWNewsApi.UnitOfWork
{
    public interface IUnitOfWork
    {
        void SaveChanges();
        Task SaveChangesAsync();

    }
}
