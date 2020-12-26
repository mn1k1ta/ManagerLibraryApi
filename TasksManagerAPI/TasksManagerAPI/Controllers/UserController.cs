using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.ModelsDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TasksManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService service;

        public UserController(IUserService service)
        {
            this.service = service;
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<IActionResult> CreateUserAsync(UserModelDTO user)
        {
            var serviceActionResult = await service.CreateUserAsync(user);
            return serviceActionResult.Succedeed
                       ? (IActionResult)Ok(serviceActionResult)
                       : BadRequest(serviceActionResult);
        }
        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUserAsync(UserModelDTO user)
        {
            var serviceActionResult = await service.EditUserAsync(user);
            return serviceActionResult.Succedeed
                       ? (IActionResult)Ok(serviceActionResult)
                       : BadRequest(serviceActionResult);
        }
        [HttpDelete]
        [Route("DeleteUser")]
        public async Task<IActionResult> DeleteUserAsync(int user)
        {
            var serviceActionResult = await service.DeleteUserAsync(user);
            return serviceActionResult.Succedeed
                       ? (IActionResult)Ok(serviceActionResult)
                       : BadRequest(serviceActionResult);
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            return Ok(await service.GetAllUsersAsync());
        }
        [HttpGet]
        [Route("GetUserById")]
        public async Task<IActionResult> GetUserByIdAsync(int id)
        {
            return Ok(await service.GetUserByIdAsync(id));
        }
        [HttpGet]
        [Route("GetAllUsersSortByName")]
        public async Task<IActionResult> GetAllUsersSortByNameAsync()
        {
            return Ok(await service.GetAllUsersSortByNameAsync());
        }
        [HttpGet]
        [Route("GetAllUsersSortByLastName")]
        public async Task<IActionResult> GetAllUsersSortByLastNameAsync()
        {
            return Ok(await service.GetAllUsersSortByLastNameAsync());
        }
        [HttpGet]
        [Route("GetAllUsersSortByGroup")]
        public async Task<IActionResult> GetAllUsersSortByGroupAsync()
        {
            return Ok(await service.GetAllUsersSortByGroupAsync());
        }
    }
}
