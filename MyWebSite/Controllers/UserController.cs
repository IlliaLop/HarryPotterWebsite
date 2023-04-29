using System.Text.Json;
using System.Text.Json.Serialization;
using BLL.Services;
using DLL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HarryPotterWebsite.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}", Name = "GetAllUserInfoById")]
        public async Task<IActionResult> Get(uint id)
        {
            var user = await _userService.Get(id);

            if (user == null)
            {
                return NotFound($"{id} not found");
            }

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };

            return Ok(JsonSerializer.Serialize(user, options));
        }

        [HttpPut("{id}", Name = "UpdateInformationById")]
        public async Task<IActionResult> UpdateUser(uint id, AllUserInfo allUserInfo)
        {
            var user = new User()
            {
                Login = allUserInfo.UserLogin,
                Password = allUserInfo.UserPassword
            };
            var userInfo = new UserInfo()
            {
                Email = allUserInfo.UserInfoEmail,
                Name = allUserInfo.UserInfoName
            };
            user.UserInfo = userInfo;

            var result = await _userService.UpdateUser(user, id);

            if (result == 0)
            {
                return NotFound($"{id} not found");
            }

            return NoContent();
        }
        
        [HttpPost("AddUser")]
        public async Task<ActionResult<User>> AddUser(AllUserInfo allUserInfo)
        {
            var user = new User()
            {
                Login = allUserInfo.UserLogin,
                Password = allUserInfo.UserPassword
            };
            var userInfo = new UserInfo()
            {
                Email = allUserInfo.UserInfoEmail,
                Name = allUserInfo.UserInfoName
            };

            user.UserInfo = userInfo;
            var addedUser = await _userService.AddUser(user);

            if (addedUser == null)
            {
                return BadRequest("User cant be added");
            }

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };

            return Ok(JsonSerializer.Serialize(addedUser, options));
        }
        
        [HttpDelete("{id}", Name = "DeleteInformationById")]
        public async Task<IActionResult> DeleteUser(uint id)
        {
            var user = await _userService.Get(id);

            if (user == null)
            {
                return NotFound($"{id} not found");
            }

            var result = await _userService.DeleteUser(user);

            if (result == 0)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}