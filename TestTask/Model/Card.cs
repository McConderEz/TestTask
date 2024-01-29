using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TestTask.Model
{
    
    public class Card
    {
        [XmlAttribute("UserId")]
        public int UserId { get; set; }
        [XmlElement("Pan")]
        public string Pan { get; set; }
        [XmlElement("ExpDate")]
        public string ExpDate { get; set; }
        //[XmlArray("Cards"),XmlArrayItem("Card")]
        //public List<Card> Cards { get; set; }


        public Card(int userId, string pan, string expDate)
        {
            //TODO:Сделать проверки

            UserId = userId;
            Pan = pan;
            ExpDate = expDate;
        }

        public Card() { }
    }

}
