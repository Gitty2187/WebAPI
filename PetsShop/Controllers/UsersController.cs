using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetsShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return ["value1", "value2"];
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            using (StreamReader reader = System.IO.File.OpenText("C:\\Users\\משתמש\\Desktop\\מסלול\\WebAPI\\Users.txt"))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.ID == id)
                        //RETURN USER TO CLIENT//write in c# code
                        return user.ToString();
                }
            }
            //RETURN NO USER FOUND //write in c# code
            //return "User Not Found"
            throw new Exception("User not found");

        }

        //POST api/<UsersController>
        [HttpPost("login")]
        public string Post([FromBody] string[] credentials)
        {
            string userName = credentials[0];
            string password = credentials[1];
            using (StreamReader reader = System.IO.File.OpenText("C:\\Users\\משתמש\\Desktop\\מסלול\\WebAPI\\Users.txt"))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.userName == userName && user.password == password)
                        //RETURN USER TO CLIENT
                        return JsonSerializer.Serialize(user);
                }
            }
            throw new Exception("User not found");
        }

        //POST api/<UsersController>
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            Console.WriteLine("Post");
            int numberOfUsers = System.IO.File.ReadLines("C:\\Users\\משתמש\\Desktop\\מסלול\\WebAPI\\Users.txt").Count();
            int id = numberOfUsers + 1;

            User newUser = new(user.userName, user.password, user.firstName, user.lastName, id);

            string userJson = JsonSerializer.Serialize(newUser);

            System.IO.File.AppendAllText("C:\\Users\\משתמש\\Desktop\\מסלול\\WebAPI\\Users.txt", userJson + Environment.NewLine);

            return CreatedAtAction(nameof(Get), newUser);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Object userToUpdate)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText("C:\\Users\\משתמש\\Desktop\\מסלול\\WebAPI\\Users.txt"))
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
                string text = System.IO.File.ReadAllText("C:\\Users\\משתמש\\Desktop\\מסלול\\WebAPI\\Users.txt");
                text = text.Replace(textToReplace, JsonSerializer.Serialize(userToUpdate));
                System.IO.File.WriteAllText("C:\\Users\\משתמש\\Desktop\\מסלול\\WebAPI\\Users.txt", text);
            }

        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
