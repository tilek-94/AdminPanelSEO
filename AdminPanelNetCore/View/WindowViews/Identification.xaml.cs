using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AdminPanelNetCore.View.WindowViews
{
    /// <summary>
    /// Логика взаимодействия для Identification.xaml
    /// </summary>
    public partial class Identification : Window
    {
        public event Action<string> ValueChanged;
        private int flag = 0;
        public Identification()
        {
            InitializeComponent();
        }

        private void button_1_Click(object sender, RoutedEventArgs e)
        {

            if (LogTextBox.Text == "Admin" && PassTextBox.Password == "12345")
            {

                ValueChanged("0");
                flag = 1;
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль!", "Внимание !", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void button_2_Click(object sender, RoutedEventArgs e)
        {
            flag = 0;
            this.Close();
        }

        private void Win_Closed(object sender, EventArgs e)
        {
            if(flag==0)
            Application.Current.Shutdown();
        }
    }
}
