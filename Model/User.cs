using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFilterableList.Model
{
    public class User
    {
        public string UserName { get; private set; }
        public List<User> Parents { get; private set; } 

        public User(string userName)
        {
            this.UserName = userName;
        }

        public User(string userName, List<User> parents)
        {
            this.UserName = userName;
            this.Parents = parents;
        }
    }
}
