using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
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
            int maxAttemptsCount = 5;
            int currentAttempt = 0;
            bool success = false;

            //TODO:Сделать проверки
            List<User> users = new List<User>();

            while (!success && currentAttempt < maxAttemptsCount)
            {
                try
                {
                    
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
                    success = true;
                }
                catch(IOException)
                {
                    currentAttempt++;
                    Thread.Sleep(1000);
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

            RecordList existingRecords = new RecordList();
            if (File.Exists(fileName))
            {
                string existingData = File.ReadAllText(fileName);
                existingRecords = JsonConvert.DeserializeObject<RecordList>(existingData);
            }

            RecordList mergedRecords = new RecordList();
            mergedRecords.Records = existingRecords.Records.Concat(items.Records).ToList();

            using(var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                var option = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                };
                
                System.Text.Json.JsonSerializer.Serialize(fs, mergedRecords, option);
            }
        }
    }
}
