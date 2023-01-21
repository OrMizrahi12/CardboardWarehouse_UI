using System;
using System.Collections.Generic;
using System.Data;
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
using CardboardWarehouse_DS;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.VisualBasic.FileIO;

namespace CardboardWarehouse_UI.Pages.Admin
{
    /// <summary>
    /// Interaction logic for MainAdmin.xaml
    /// </summary>
    public partial class MainAdmin : Page
    {

        public MainAdmin()
        {
            InitializeComponent();
      

        }

        private void BtnToEditStock_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(new Uri("Pages/Admin/EditCartonStock.xaml", UriKind.Relative));
        }

        private void BtnToAddCarton_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(new Uri("Pages/Admin/AddCarton.xaml", UriKind.Relative));

        }

        private void BtnToSystemEvent_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(new Uri("Pages/Admin/LogEvent.xaml", UriKind.Relative));
        }




       

    }


}
