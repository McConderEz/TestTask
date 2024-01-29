using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Model;

namespace TestTask.Controller
{
    public class UserController:ControllerBase
    {
        public List<Record> Users { get; set; }
    }
}
