
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WoWNewsApi.Models;

namespace WoWNewsApi.Repositories.Contracts
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetByUidAsync(string uid);
    }
}
