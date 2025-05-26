using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class UserDTO
    {
        public record UserDto(int Id, string UserName, string LastName, string FirstName, ICollection<Order> Orders);
        public record UserLoginDto(string UserName, string Password);
        public record UserRegisterDto(string UserName, string LastName, string Password, string FirstName);
    }
}
