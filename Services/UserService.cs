using Microsoft.VisualBasic;
using PetsShop;
using Repositories;
using System.Xml.Linq;
//using zxcvbn;
//using Zxcvbn;
//using Zxcvbn.Core;

namespace Services
{
    
    public class UserService
    {
        UserRepository repository = new UserRepository();
        public User login(String userName, String password)
        {
            if (userName == null || password == null)
                return null;
            return repository.login(userName, password);
        }
        public User register(String userName, String password, string name, string lastName)
        {
            if (userName == null || password == null)
                return null;
            return repository.register(userName, password, name, lastName);
        }

        public void update(User user) {
            if (user.userName == null || user.password == null)
                throw new Exception();
            try
            {
                repository.update(user);
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        public string checkPassword(string password)
        {
            if (password != null)
            {
                var zxcvbnResult = Zxcvbn.Core.EvaluatePassword(password);
                return zxcvbnResult.Score switch
                {
                    0 => "חלשה מאוד",
                    1 => "חלשה",
                    2 => "בינונית",
                    3 => "חזקה",
                    4 => "חזקה מאוד",
                    _ => "לא ידוע"
                };
            }
            return null;
    }
    }
}
