using DTOs;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Text.Json;
using System.Threading.Tasks;
using static DTOs.UserDTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860//

namespace PetsShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        // GET: api/<UsersController>//
        [HttpGet]
        public async Task<List<UserDto>> Get()
        {
            return await _userService.GetUsers();
        }



        // GET api/<UsersController>/5//
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> Get(int id)
        {
            return await _userService.getById(id);
        }

        //POST api/<UsersController>//
        [HttpPost("login")]
        public async Task<ActionResult<User>> Post([FromBody] UserLoginDto userLogin)
        {
            try
            {
                var res = await _userService.login(userLogin);
                return Ok(res);
            }
            catch(Exception e)
            {
                return NotFound(e);
            }
        }


        //POST api/<UsersController>//
        //register//
        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] UserRegisterDto userRegister)
        {
            int resPass = _userService.checkPassword(userRegister.Password);
            if (resPass < 2)
                return BadRequest("You must enter a stronger password");
            try
            {
                await _userService.register(userRegister);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        //POST api/<UsersController>//
        [HttpPost("checkPassword")]
        public IActionResult Post([FromBody] string password)
        {
            int res = _userService.checkPassword(password);

            string s = res switch
            {
                0 => "חלשה מאוד",
                1 => "חלשה",
                2 => "בינונית",
                3 => "חזקה",
                4 => "חזקה מאוד",
                _ => "לא ידוע"
            };

            return Ok(s);

        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Put(int id,[FromBody] UserRegisterDto user)
        {
            if (user.Password != null)
            {
                int resPass = _userService.checkPassword(user.Password);
                if (resPass < 2)
                    return BadRequest("You must enter a stronger password");
            }
            try
            {
                _userService.update(user, id);
                return Ok(user);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
