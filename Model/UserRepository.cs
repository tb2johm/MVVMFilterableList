using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFilterableList.Model
{
    public class UserRepository
    {
        public static List<User> UserList = new List<User>
        {
            new User("Victoria", new List<User>{new User("Carl"), new User("Silvia")}),
            new User("Astrid", new List<User>{new User("Samuel"), new User("Hanna")})
        };

        public static List<User> GetUsers()
        {
            return UserList;
        }
    }
}
