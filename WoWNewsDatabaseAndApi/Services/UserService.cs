using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WoWNewsApi.Models;
using WoWNewsApi.Repositories.Contracts;
using WoWNewsApi.Services.Contracts;
using WoWNewsApi.UnitOfWork;

namespace WoWNewsApi.Services
{
    public class UserService : Service<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IGenericRepository<User> repository, IUnitOfWork unitOfWork, IUserRepository userRepository) : base(repository, unitOfWork)
        {
            _userRepository = userRepository;   
        }

        

        public async Task<User> GetByUidAsync(string uid)
        {
            return await _userRepository.GetByUidAsync(uid);
           
        }
    }
}
