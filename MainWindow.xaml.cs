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

namespace WpfApp4
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            UserControl1 spend = new UserControl1();
            newthing.Children.Add(spend);
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            List<string> datas = new List<string>();
            foreach (UserControl1 spend in newthing.Children)
            {
                string Line = "";                
                Line += spend.time.Text;
                Line += "|" + spend.things.Text;
                Line += "|" + spend.money.Text;

                datas.Add(Line);
            }

            System.IO.File.WriteAllLines(@"D:\data.txt", datas);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string[] lines = System.IO.File.ReadAllLines(@"D:\data.txt");

            foreach (string line in lines)
            {
                string[] part = line.Split('|');
                UserControl1 spend = new UserControl1();

                spend.time.Text = part[0];
                spend.things.Text = part[1];
                spend.money.Text = part[2];

                newthing.Children.Add(spend);
            }
        }
    }
}
