using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AdminPanelNetCore.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для OptionsTV.xaml
    /// </summary>
    public partial class OptionsTV : UserControl
    {
        public OptionsTV()
        {
            InitializeComponent();
        }

        private void Sound_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = SoundCombo.SelectedIndex;
            if (index == 1)
            {
                LanguageCombo.Visibility = Visibility.Visible;
            }
            else if (index == 2)
            {
                LanguageCombo.Visibility = Visibility.Hidden;
            }
            else if (index == 3)
            {
                LanguageCombo.Visibility = Visibility.Hidden;
            }
        }
    }
}
