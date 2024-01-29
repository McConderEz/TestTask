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
            var filePaths = Paths.Where(path => Path.GetExtension(path) == ".csv");
            foreach(var path in filePaths)
            {
                Users.AddRange(LoadUsers(path));
            }
        }

        public void GetCards()
        {
            var filePaths = Paths.Where(path => Path.GetExtension(path).Equals(".xml"));
            foreach(var path in filePaths)
            {
                Cards.AddRange(LoadCards(path));
            }
        }

        public void GenerateReport()
        {
            SearchingData();
            Save();
        }

        private void SearchingData()
        {
            while (Users.Count > 0 && Cards.Count > 0)
            {
                foreach (var card in Cards)
                {
                    foreach (var user in Users)
                    {
                        if (card.UserId == user.UserId)
                        {
                            Records.Add(new Record
                            {
                                UserId = user.UserId,
                                Pan = card.Pan,
                                Phone = user.Number,
                                FirstName = user.Name,
                                LastName = user.Name,
                                ExpDate = card.ExpDate,
                            });
                            break;
                        }
                    }
                }
                break;
            }
        }

        public void Save()
        {
            if(Records.Count > 0)
            {
                RecordList recordList = new RecordList();
                recordList.Records.AddRange(Records);
                Save(recordList, "test.json");
            }
        }
    }
}
