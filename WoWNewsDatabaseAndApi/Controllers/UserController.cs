using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Security.AccessControl;
using WoWNewsApi.DTOs;
using WoWNewsApi.Models;
using WoWNewsApi.Repositories;
using WoWNewsApi.Services.Contracts;

namespace WoWNewsApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : CustomBaseController
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
            return CreateActionResult(CustomResponseDto<User>.Success(200, user));
        }

        [HttpGet("uid/{uid}")]
        public async Task<IActionResult> GetByUid(string uid)
        {
            var user =  await _userService.GetByUidAsync(uid);
            return CreateActionResult(CustomResponseDto<User>.Success(200, user));
        }

        
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var users = await _userService.GetAllAsync();
            return CreateActionResult(CustomResponseDto<List<User>>.Success( 200, users.ToList()));
        }


        //Create
        [HttpPost]

        public async Task<IActionResult> Add(User user)
        {
            user = await _userService.AddAsync(user);
            return CreateActionResult(CustomResponseDto<User>.Success(201, user)); 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveOneUserById(int id)
        {
            await _userService.RemoveOneByIdAsync(id);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        //*****************************************************
        //I dont want to update option for this project for now
        //*****************************************************
    }
}
