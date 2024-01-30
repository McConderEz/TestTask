using Newtonsoft.Json;
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
        [JsonProperty("UserId")]
        public int UserId { get; set; }
        [JsonProperty("Pan")]
        public string Pan { get; set; }
        [JsonProperty("ExpDate")]
        public string ExpDate { get; set; }
        [JsonProperty("FirstName")]
        public string FirstName { get; set; }
        [JsonProperty("LastName")]
        public string LastName { get; set; }
        [JsonProperty("Phone")]
        public string Phone { get; set; }


        [Newtonsoft.Json.JsonConstructor]
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

        
        public Record() { }

    } 
}
