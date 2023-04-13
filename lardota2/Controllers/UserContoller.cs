using Domain.Interfaces;
using Domain.Models;
using lardota2.Contracts.User;
using Mapster;
using Microsoft.AspNetCore.Mvc;
namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        /// <summary>
        /// Поиск
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        /// POST /Todo
        /// {
        /// id:"251"
        /// }
        ///
        /// </remarks>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userService.GetAll());
        }
        /// <summary>
        /// Поиск по ID
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        /// POST /Todo
        /// {
        /// id:"222"
        /// }
        ///
        /// </remarks>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpGet("{id}")]
       
        public async Task<IActionResult> GetById(GetUserResponse response)
        {
            int UserDTo = Convert.ToInt32(response.Adapt<User>());
            await _userService.GetById(UserDTo);
            return Ok();
        }
        /// <summary>
        /// Создание пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        /// POST /Todo
        /// {
        /// "userid" : "21",
        /// "login1": "adsa",
        /// "password1": "adaaaaa",
        /// "role1": "user",
        /// </remarks>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpPost]
        
        public async Task<IActionResult> Add(CreateUserRequest request)
        {
            var UserDto = request.Adapt<User>();
            await _userService.Create(UserDto);
            return Ok();
        }
        /// <summary>
        /// Обновление пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        /// POST /Todo
        /// {
        /// "userid" : "21",
        /// "login1": "adsa",
        /// "password1": "adaaaaa",
        /// "role1": "user",
        /// </remarks>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpPut]
        
        public async Task<IActionResult> Update(CreateUserRequest request)
        {
            var Userdto = request.Adapt<User>();
            await _userService.Update(Userdto);
            return Ok();
        } 
        /// <summary>
        /// Удаление 
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        /// POST /Todo
        /// {
        /// id:"11"
        /// }
        /// </remarks>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpDelete]
       
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.Delete(id);
            return Ok();
        }
    }
}