using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vipief.Model;
using vipief.ViewModel.Helpers;

namespace vipief.ViewModel
{
    internal class TasksViewModel : BindingHelper
    {
        #region Свойства


        private TaskList selected = new TaskList();
        public TaskList Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<TaskList> tasks;
        public ObservableCollection<TaskList> Tasks
        {
            get { return tasks; }
            set
            {
                tasks = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Команды

        public BindableCommand AddCommand { get; set; }
        public BindableCommand UpdateCommand { get; set; }
        public BindableCommand DeleteCommand { get; set; }

        #endregion

        public TasksViewModel()
        {
            AddCommand = new BindableCommand(_ => AddTask());

            UpdateCommand = new BindableCommand(_ => UpdateTask(), _ => Selected != null);

            DeleteCommand = new BindableCommand(_ => DeleteTask(), _ => Selected != null);

            Tasks = XmlTask.LoadData();
        }

        private void AddTask()
        {
            Tasks.Add(Selected);
            XmlTask.SaveData(Tasks);
            Selected = new TaskList();

        }

        private void UpdateTask()
        {
            if (Selected != null)
            {
                var existingTask = Tasks.FirstOrDefault(t => t.Name == Selected.Name);
                if (existingTask != null)
                {
                    int index = Tasks.IndexOf(existingTask);
                    if (index != -1)
                    {
                        Tasks[index] = Selected;
                        XmlTask.SaveData(Tasks);
                    }
                }
            }
        }


        private void DeleteTask()
        {
            Tasks.Remove(Selected);
            XmlTask.SaveData(Tasks);

        }
    }
}
