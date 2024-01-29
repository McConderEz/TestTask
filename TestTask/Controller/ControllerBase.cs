using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TestTask.Model;

namespace TestTask.Controller
{
    public class ControllerBase
    {

        /// <summary>
        /// Считывание данных с XML файла
        /// </summary>
        /// <param name="paths"></param>
        public List<Card> LoadCards(string path)
        {           
            //TODO:Сделать проверки
            XmlSerializer serializer = new XmlSerializer(typeof(List<Card>), new XmlRootAttribute("Cards"));
            List<Card> cards;
            using (var fs = new FileStream(path, FileMode.Open))
            {
                if (fs.Length > 0)
                {
                    cards = serializer.Deserialize(fs) as List<Card>;
                }
                else
                {
                    return null;
                }
            }

            return cards;
        }

        /// <summary>
        /// Считывание данных с CSV файла
        /// </summary>
        /// <param name="paths"></param>
        public List<User> LoadUsers(string path)
        {
            //TODO:Сделать проверки
            List<User> users = new List<User>();
            using (var sr = new StreamReader(path))
            {
                var header = sr.ReadLine();

                while (!sr.EndOfStream)
                {
                    var row = sr.ReadLine();
                    var values = row.Split(';');

                    users.Add(new User
                    {
                        UserId = Convert.ToInt32(values[0]),
                        Name = values[1],
                        SecondName = values[2],
                        Number = values[3]
                    });
                }
            }

            return users;
        }

        /// <summary>
        /// Создание файла отчёта формата json
        /// </summary>
        /// <param name="items"></param>
        /// <param name="fileName"></param>
        public void Save(RecordList items,string fileName)
        {
            //TODO: Сделать проверки
            using(var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                var option = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                };
                
                JsonSerializer.Serialize(fs, items, option);
            }
        }
    }
}
