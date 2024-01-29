using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Model
{
    public class Card
    {
        public int UserId { get; set; }
        public string Pan { get; set; }
        public string ExpDate { get; set; }


        public Card(int userId, string pan, string expDate)
        {
            //TODO:Сделать проверки

            UserId = userId;
            Pan = pan;
            ExpDate = expDate;
        }
    }
}
