using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vipief.Model
{
    public class Note
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? Date { get; set; }
        public Note()
        {
        }

        public Note(string name, string description, DateTime? date)
        {
            Name = name;
            Description = description;
            Date = date;
        }
    }

}