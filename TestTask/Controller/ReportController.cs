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
        public RecordList RecordList;

        public event EventHandler ReportReady;

        public ReportController()
        {
            Paths = new List<string>();
            Users = new List<User>();
            Cards = new List<Card>();
            RecordList = new RecordList();
        }


        public void Add(string[] paths)
        {
            Paths.AddRange(paths);            
        }
        
        public void GetData()
        {
            GetUsers();
            GetCards();
            Paths.Clear();
        }

        private void GetUsers()
        {
            var filePaths = Paths.Where(path => Path.GetExtension(path) == ".csv");
            foreach(var path in filePaths)
            {
                var loadedUsers = LoadUsers(path);
                foreach(var user in loadedUsers)
                {
                    if(!Users.Any(exUser => exUser.UserId == user.UserId))
                    {
                        Users.Add(user);
                    }
                }
            }            
        }

        private void GetCards()
        {
            var filePaths = Paths.Where(path => Path.GetExtension(path).Equals(".xml"));
            foreach(var path in filePaths)
            {
                var loadedCards = LoadCards(path);
                foreach(var card in loadedCards)
                {
                    if (!Cards.Any(exCard => exCard.UserId == card.UserId))
                    {
                        Cards.Add(card);
                    }
                }
                
            }
        }

        public void GenerateReport(string path)
        {
            Save(path);
        }
        //TODO:Сделать, чтобы старые данные не дублировались при добавлении новых файлов в директорию.
        //TODO:Сделать уведомление при возможности сформировать отчёт

        public void SearchingData()
        {
            while (Users.Count > 0 && Cards.Count > 0)
            {
                foreach (var card in Cards)
                {
                    foreach (var user in Users)
                    {                      
                        if (card.UserId == user.UserId)
                        {
                            RecordList.Records.Add(new Record
                            {
                                UserId = user.UserId,
                                Pan = card.Pan,
                                Phone = user.Number,
                                FirstName = user.Name,
                                LastName = user.Name,
                                ExpDate = card.ExpDate,
                            });
                            ReportReady?.Invoke(this, EventArgs.Empty);
                            break;
                        }
                    }                   
                }
                break;
            }
            Users.RemoveAll(user => RecordList.Records.Any(record => record.UserId == user.UserId));
            Cards.RemoveAll(card => RecordList.Records.Any(record => record.UserId == card.UserId));
        }

        public void Save(string path)
        {
            if(RecordList.Records.Count > 0)
            {
                Save(RecordList, path);
                RecordList.Records.Clear();
            }
        }
    }
}
