using System.Data.SqlTypes;
using WoWNewsApi.Models;

namespace WoWNewsApi.Services.Contracts
{
    public interface IUserService : IService<User>
    {
        Task<User> GetByUidAsync(string uid);

    }
}
