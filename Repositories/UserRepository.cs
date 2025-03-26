using PetsShop;
using System.Text.Json;

namespace Repositories
{
    public class UserRepository
    {
        public User login(String userName,String password)
        {
            using (StreamReader reader = System.IO.File.OpenText("M:\\API\\Users.txt"))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.userName == userName && user.password == password)
                        //RETURN USER TO CLIENT
                        return user;
                }
            }
            return null;
        }

        public User register(String userName, String password, string name, string lastName)
        {
            int numberOfUsers = System.IO.File.ReadLines("M:\\API\\Users.txt").Count();
            int id = numberOfUsers + 1;

            User newUser = new(userName, password, name, lastName, id);

            string userJson = JsonSerializer.Serialize(newUser);
           
                System.IO.File.AppendAllText("M:\\API\\Users.txt", userJson + Environment.NewLine);

                return newUser;
           
        }
    }
}
