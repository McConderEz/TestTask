using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TestTask.Model;

namespace TestTask.Controller
{
    public class ReportController: ControllerBase
    {
        public List<string> Paths;
        public List<User> Users;
        public List<Card> Cards;
        public List<Record> Records;

        public ReportController()
        {
            Paths = new List<string>();
            Users = new List<User>();
            Cards = new List<Card>();
            Records = new List<Record>();
        }


        public void Add(string[] paths)
        {
            Paths.AddRange(paths);            
        }
        
        public void GetData()
        {
            GetUsers();
            GetCards();
        }

        public void GetUsers()
        {
            var filePaths = Paths.Where(path => Path.GetExtension(path) == "csv");
            foreach(var path in filePaths)
            {
                Users.AddRange(LoadUsers(path));
            }
        }

        public void GetCards()
        {
            var filePaths = Paths.Where(path => Path.GetExtension(path) == "xml");
            foreach(var path in filePaths)
            {
                Cards.AddRange(LoadCards(path));
            }
        }

        public void GenerateReport()
        {
           
        }
    }
}
