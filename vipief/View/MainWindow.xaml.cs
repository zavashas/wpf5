using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using vipief.Model;
using vipief.View;
using vipief.ViewModel;
using vipief.ViewModel.Helpers;

namespace vipief
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void NotesBtn_Click(object sender, RoutedEventArgs e)
        {
            NotesWindow window1 = new NotesWindow();

            window1.Show();


        }

        private void TasksBtn_Click(object sender, RoutedEventArgs e)
        {
            TasksWindow window2 = new TasksWindow();
            window2.Show();
        }



        private void Setting_Click(object sender, RoutedEventArgs e)
        {
            SettingWindow window3 = new SettingWindow();
            window3.Show();
        }
    }
}
