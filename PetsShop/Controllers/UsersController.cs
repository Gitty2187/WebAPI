using Microsoft.AspNetCore.Mvc;
using Services;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetsShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        UserService userService = new UserService();
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return ["value1", "value2"];
        }



        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using (StreamReader reader = System.IO.File.OpenText("M:\\API\\Users.txt"))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.ID == id)
                        //RETURN USER TO CLIENT//write in c# code
                        return Ok(user);
                }
            }
            throw new Exception("User not found");

        }




        //POST api/<UsersController>
        [HttpPost("login")]
        public ActionResult Post([FromBody] string[] credentials)
        {
            User res = userService.login(credentials[0], credentials[1]);
            if (res == null)
                return NotFound();
            else
                return Ok(res);
        }




        //POST api/<UsersController>
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            User res = userService.register(user.userName, user.password, user.firstName, user.lastName);
            if (res == null)
                return NotFound();
            else
                return Unauthorized("not Success");
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Object userToUpdate)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText("M:\\API\\Users.txt"))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {

                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.ID == id)
                        textToReplace = currentUserInFile;
                }
            }

            if (textToReplace != string.Empty)
            {
                string text = System.IO.File.ReadAllText("M:\\API\\Users.txt");
                text = text.Replace(textToReplace, JsonSerializer.Serialize(userToUpdate));
                System.IO.File.WriteAllText("M:\\API\\Users.txt", text);
            }

        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
