using AutoMapper;
using Marketify.Business.DTOs.UserDTOs;
using Marketify.Entity.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Marketify.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IMapper _mapper;

        public UserController(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _roleManager = roleManager;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUserDTO loginUserDTO)
        {
              User user=await  _userManager.FindByEmailAsync(loginUserDTO.Email);
            if (user != null)
            {
               var result= _signInManager.PasswordSignInAsync(user, loginUserDTO.Password,isPersistent:false,lockoutOnFailure:false);
                if(result.IsCompletedSuccessfully)
                {
                    return Ok(result);
                }
            }
            return BadRequest();
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDTO createUserDTO)
        {
            User user=_mapper.Map<User>(createUserDTO);
           var result= await _userManager.CreateAsync(user,createUserDTO.Password);
         await   _userManager.AddToRoleAsync(user, "Customer");
            if(result.Succeeded)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users= await _userManager.Users.ToListAsync();
            if (users != null)
            {
                return Ok(users);

            }
            return BadRequest();
        }
        [HttpGet("WithoutAdmin")]
        public async Task<IActionResult> GetAllUsersWithoutAdmin()
        {

          var users= await _userManager.GetUsersInRoleAsync("Customer");
            if(users != null)
            {
                return Ok(users);
            }
            return BadRequest();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user=await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                return Ok(user);
            }
            return BadRequest();

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if(user != null)
            {
                await _userManager.DeleteAsync(user);
                return Ok();
            }
            return BadRequest();
        }
    }
}
