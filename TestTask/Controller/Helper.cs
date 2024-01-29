using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Controller
{
    public static class Helper
    {

        public static string DateToString(this DateTime dt)
        {
            string str = dt.ToString("dd/MM/yyyy");
            return str;
        }
    }
}
