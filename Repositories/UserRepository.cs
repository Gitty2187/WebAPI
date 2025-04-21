using Microsoft.VisualBasic;
using PetsShop;
using System.Text.Json;

namespace Repositories
{
    public class UserRepository
    {
        public User login(String userName,String password)
        {
            using (StreamReader reader = System.IO.File.OpenText("Users.txt"))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.userName == userName && user.password == password)
                        return user;
                }
            }
            return null;
        }

        public User register(String userName, String password, string name, string lastName)
        {
            int numberOfUsers = System.IO.File.ReadLines("Users.txt").Count();
            int id = numberOfUsers + 1;

            User newUser = new(userName, password, name, lastName, id);

            string userJson = JsonSerializer.Serialize(newUser);
           
                System.IO.File.AppendAllText("Users.txt", userJson + Environment.NewLine);

                return newUser;
        }

        public void update(User userToUpdate)
        {
            try
            {
                string textToReplace = string.Empty;
                using (StreamReader reader = System.IO.File.OpenText("Users.txt"))
                {
                    string currentUserInFile;
                    while ((currentUserInFile = reader.ReadLine()) != null)
                    {

                        User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                        if (user.ID == userToUpdate.ID)
                        {
                            textToReplace = currentUserInFile;
                            break;
                        }
                    }
                }

                if (textToReplace != string.Empty)
                {
                    if(userToUpdate.password == null)
                        userToUpdate.password = ((User)textToReplace).password;
                    string text = System.IO.File.ReadAllText("Users.txt");
                    text =  text.Replace(textToReplace, JsonSerializer.Serialize(userToUpdate));
                    System.IO.File.WriteAllText("Users.txt", text);
                }
            }
            catch   
            {
                throw new Exception();
            }
             
        }

       
    }
}
