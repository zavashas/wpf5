using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using vipief.ViewModel.Helpers;

namespace vipief.ViewModel
{
    internal class SettingViewModel
    {
        public ICommand ChangeThemeCommand { get; private set; }

        public SettingViewModel()
        {

            ChangeThemeCommand = new BindableCommand(ApplyNewTheme);
        }

        private void ApplyNewTheme(object parameter)
        {
            var windows = Application.Current.Windows;

            ResourceDictionary newTheme = new ResourceDictionary();
            newTheme.Source = new Uri("pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml");

            foreach (Window window in windows)
            {
                window.Resources.MergedDictionaries.Clear();
                window.Resources.MergedDictionaries.Add(newTheme);

                if ((window.Background as SolidColorBrush)?.Color == Colors.White)
                {
                    window.Background = Brushes.LightSteelBlue;
                }
                else
                {
                    window.Background = Brushes.White;
                }
            }
        }

    }

}
