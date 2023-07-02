using Microsoft.EntityFrameworkCore;
using WoWNewsApi.Models;
using WoWNewsApi.Repositories.Contracts;

namespace WoWNewsApi.Repositories.Repos
{
    public class UserRepositoriy : GenericRepository<User>, IUserRepository
    {

        private readonly AppDbContext _context;
        private readonly DbSet<User> _dbSet;
        public UserRepositoriy(AppDbContext context) : base(context)
        {
            _context = context; 
            _dbSet = _context.Set<User>();
            
        }

        public async Task<User> GetByUidAsync(string uid)
        {
            return await _context.Set<User>().SingleOrDefaultAsync(x => x.Uid == uid);
        }
    }
}