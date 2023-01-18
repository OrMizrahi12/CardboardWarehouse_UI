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
using GalaSoft.MvvmLight.Command;

namespace CardboardWarehouse_UI.Pages.Customer
{
    /// <summary>
    /// Interaction logic for MainCustomer.xaml
    /// </summary>
    public partial class MainCustomer : Page
    {
        public MainCustomer()
        {
            InitializeComponent();
        }

        private void BtnToAddGift_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(new Uri("Pages/Customer/AddGift.xaml", UriKind.Relative));
            
        }
        private void BtnToFindCarton_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(new Uri("Pages/Customer/FindCarton.xaml", UriKind.Relative));
        }
        private void BtnToCart_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(new Uri("Pages/Customer/ShopingCart.xaml", UriKind.Relative));
        }
    }
}
