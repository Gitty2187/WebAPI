using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Text.Json;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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


        // GET: api/<UsersController>
        [HttpGet]
        public Task<List<User>> Get()
        {
            return _userService.GetUsers();
        }



        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public Task<User> Get(int id)
        {
            return _userService.getById(id);
        }

        //POST api/<UsersController>
        [HttpPost("login")]
        public ActionResult Post([FromBody] string[] credentials)
        {
            Task res = _userService.login(credentials[0], credentials[1]);
            if (res == null)
                return NotFound();
            else
                return Ok(res);
        }


        //POST api/<UsersController>
        //register
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            int resPass = _userService.checkPassword(user.Password);
            if (resPass < 2)
                return BadRequest("You must enter a stronger password");
            Task res = _userService.register(user);
            if (res == null)
                return NotFound();
            else
                return Ok(res);
        }

        //POST api/<UsersController>
        [HttpPost("chekPassword")]
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
        public ActionResult Put(int id, [FromBody] User user)
        {
            if (user.Password != null)
            {
                int resPass = _userService.checkPassword(user.Password);
                if (resPass < 2)
                    return BadRequest("You must enter a stronger password");
            }
            try
            {
                _userService.update(user);
                return Ok(user);
            }
            catch
            {
                return BadRequest();
            }
        }
        
        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
