using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using vipief.Model;

namespace vipief.ViewModel.Helpers
{
    public static class XmlTask
    {
        private static string xmlFilePath = "Tasks.xml";

        public static ObservableCollection<TaskList> LoadData()
        {
            ObservableCollection<TaskList> tasks = new ObservableCollection<TaskList>();
            if (File.Exists(xmlFilePath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<TaskList>));
                using (FileStream fs = new FileStream(xmlFilePath, FileMode.Open))
                {
                    tasks = (ObservableCollection<TaskList>)serializer.Deserialize(fs);
                }
            }
            return tasks;
        }

        public static void SaveData(ObservableCollection<TaskList> tasks)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<TaskList>));
            using (TextWriter writer = new StreamWriter(xmlFilePath))
            {
                serializer.Serialize(writer, tasks);
            }
        }
    }
}
