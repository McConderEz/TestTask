using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Model
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Number { get; set; }

        public User(int userId, string name, string secondName, string number)
        {
            UserId = userId;
            Name = name;
            SecondName = secondName;
            Number = number;
        }

        public User() { }
    }
}
