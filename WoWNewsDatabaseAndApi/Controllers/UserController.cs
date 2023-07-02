using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using WoWNewsApi.Models;
using WoWNewsApi.Repositories;
using WoWNewsApi.Services.Contracts;

namespace WoWNewsApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userservice)
        {
            _userService = userservice; 
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            return Ok(user);
        }

        [HttpGet("uid/{uid}")]
        public async Task<IActionResult> GetByUid(string uid)
        {
            var user =  await _userService.GetByUidAsync(uid);
            return Ok(user);
        }


        [HttpGet]
        public async Task<IActionResult> All()
        {
            var users = await _userService.GetAll();
            return Ok(users);
        }

        [HttpPost]

        public async Task<IActionResult> Add(User user)
        {
            await _userService.AddAsync(user);
            return NoContent();    
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveOneUserById(int id)
        {
            await _userService.RemoveOneByIdAsync(id);
            return NoContent();
        }
        //*****************************************************
        //I dont want to update option for this project for now
        //*****************************************************
    }
}
