using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vipief.Model
{
    public class TaskList
    {
        public TaskList(string name, bool isCompleted)
        {
            Name = name;
            IsCompleted = isCompleted;
        }

        public TaskList()
        {

        }

        public string Name { get; set; }
        public bool IsCompleted { get; set; }
    }
}
