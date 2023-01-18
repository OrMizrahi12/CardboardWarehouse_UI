using GalaSoft.MvvmLight.Command;
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

namespace CardboardWarehouse_UI
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

        private void BtnToAdmin_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(new Uri("Pages/Admin/MainAdmin.xaml", UriKind.Relative));

        }

        private void BtnToCustomer_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(new Uri("Pages/Customer/MainCustomer.xaml", UriKind.Relative));

        }
    }
}
