using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TestTask.Model
{
    [DataContract]
    public class Record
    {
        public int UserId { get; set; }
        public string Pan { get; set; }
        public string ExpDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }


        [JsonConstructor]
        public Record(int userId, string pan,string expDate, string firstName, string lastName, string phone)
        {
            //TODO:Сделать проверки

            UserId = userId;
            Pan = pan;
            ExpDate = expDate;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;

        }


    } 
}
