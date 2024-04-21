using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using vipief.Model;
using static System.Net.Mime.MediaTypeNames;

namespace vipief.ViewModel.Helpers
{
    public static class XmlNote
    {
        private static string xmlFilePath = "Notes.xml";

        public static ObservableCollection<Note> LoadData()
        {
            ObservableCollection<Note> notes = new ObservableCollection<Note>();
            if (File.Exists(xmlFilePath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Note>));
                using (FileStream fs = new FileStream(xmlFilePath, FileMode.Open))
                {
                    try
                    {
                        notes = (ObservableCollection<Note>)serializer.Deserialize(fs);
                    }
                    catch (InvalidOperationException)
                    {
                        notes = new ObservableCollection<Note>();
                    }
                }
            }
            return notes;
        }



        public static void SaveData(ObservableCollection<Note> notes)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Note>));
            using (TextWriter writer = new StreamWriter(xmlFilePath))
            {
                serializer.Serialize(writer, notes);
            }
        }
    }
}