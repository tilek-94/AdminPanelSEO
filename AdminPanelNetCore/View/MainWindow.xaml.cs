using AdminPanelNetCore.View.WindowViews;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace AdminPanelNetCore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //button1.IsChecked = false;
            button2.IsChecked = false;
            button3.IsChecked = false;
            button4.IsChecked = false;
            button5.IsChecked = false;
            button6.IsChecked = false;
            button7.IsChecked = false;
            button8.IsChecked = false;
           
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            button1.IsChecked = false;
            //button2.IsChecked = false;
            button3.IsChecked = false;
            button4.IsChecked = false;
            button5.IsChecked = false;
            button6.IsChecked = false;
            button7.IsChecked = false;
            button8.IsChecked = false;
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            button1.IsChecked = false;
            button2.IsChecked = false;
            //button3.IsChecked = false;
            button4.IsChecked = false;
            button5.IsChecked = false;
            button6.IsChecked = false;
            button7.IsChecked = false;
            button8.IsChecked = false;
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            button1.IsChecked = false;
            button2.IsChecked = false;
            button3.IsChecked = false;
            //button4.IsChecked = false;
            button5.IsChecked = false;
            button6.IsChecked = false;
            button7.IsChecked = false;
            button8.IsChecked = false;
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            button1.IsChecked = false;
            button2.IsChecked = false;
            button3.IsChecked = false;
            button4.IsChecked = false;
            //button5.IsChecked = false;
            button6.IsChecked = false;
            button7.IsChecked = false;
            button8.IsChecked = false;
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            button1.IsChecked = false;
            button2.IsChecked = false;
            button3.IsChecked = false;
            button4.IsChecked = false;
            button5.IsChecked = false;
            //button6.IsChecked = false;
            button7.IsChecked = false;
            button8.IsChecked = false;
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            button1.IsChecked = false;
            button2.IsChecked = false;
            button3.IsChecked = false;
            button4.IsChecked = false;
            button5.IsChecked = false;
            button6.IsChecked = false;
            //button7.IsChecked = false;
            button8.IsChecked = false;
        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            button1.IsChecked = false;
            button2.IsChecked = false;
            button3.IsChecked = false;
            button4.IsChecked = false;
            button5.IsChecked = false;
            button6.IsChecked = false;
            button7.IsChecked = false;
            //button8.IsChecked = false;

            Identification window1 = new Identification();
            window1.ValueChanged += new Action<string>((x) =>
            {
                blur.Radius = Convert.ToInt32(x);

            });

            if (blur.Radius == 15)
                blur.Radius = 0;
            else
            {

                window1.Owner = this;
                blur.Radius = 15;
                window1.ShowDialog();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Identification window1 = new Identification();
            window1.ValueChanged += new Action<string>((x) =>
            {
                blur.Radius = Convert.ToInt32(x);

            });

            if (blur.Radius == 15)
                blur.Radius = 0;
            else
            {

                window1.Owner = this;
                blur.Radius = 15;
                window1.ShowDialog();
            }
        }
    }
}
