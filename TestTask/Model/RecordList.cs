using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Model
{
    public class RecordList
    {
        public List<Record> Records { get; set; }

        public RecordList()
        {
            Records = new List<Record>();
        }
    }
}
