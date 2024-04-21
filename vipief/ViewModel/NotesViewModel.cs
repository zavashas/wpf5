using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using vipief.Model;
using vipief.ViewModel.Helpers;

namespace vipief.ViewModel
{
    internal class NotesViewModel : BindingHelper
    {
        #region Свойства

        private Note selected = new Note();
        public Note Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Note> notes;
        public ObservableCollection<Note> Notes
        {
            get { return notes; }
            set
            {
                notes = value;
                OnPropertyChanged();
            }
        }



        #endregion

        #region Команды


        public BindableCommand AddCommand { get; set; }
        public BindableCommand UpdateCommand { get; set; }
        public BindableCommand DeleteCommand { get; set; }



        #endregion

        public NotesViewModel()
        {
            AddCommand = new BindableCommand(_ => AddItems());
            UpdateCommand = new BindableCommand(_ => UpdateNote(), _ => Selected != null);

            DeleteCommand = new BindableCommand(_ => DeleteNote(), _ => Selected != null);

            Notes = XmlNote.LoadData();


        }
        public void AddItems()
        {
            Notes.Add(Selected);
            XmlNote.SaveData(Notes);
            Selected = new Note();
        }

        private void UpdateNote()
        {
            if (Selected != null)
            {
                int index = Notes.IndexOf(Selected);

                if (index != -1)
                {
                    Notes[index] = Selected;
                    XmlNote.SaveData(Notes);
                }
            }
        }



        private void DeleteNote()
        {
            Notes.Remove(Selected);
            XmlNote.SaveData(Notes);
        }
    }
}