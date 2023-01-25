using CardboardWarehouse_DS;
using CardboardWarehouse_Logic;
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
using CardboardWarehouse_Model;

namespace CardboardWarehouse_UI.Pages.Customer
{
    public partial class AddGift : Page
    {
        public AddGift()
        {
            InitializeComponent();
            GiftController.LoadDataToGrid(GiftSGrid);
        }

        private void BtnAddGift_Click(object sender, RoutedEventArgs e)
        {
            GiftController.AddGift(new Gift(int.Parse(TxtX.Text), int.Parse(TxtY.Text), DateTime.Now));
            RefreshGrid();
        }

        private void GiftSelected(object sender, MouseButtonEventArgs e)
        {

        }

        private void BtnRemoveGift_Click(object sender, RoutedEventArgs e)
        {
            Gift? SelectedGift = GiftSGrid.SelectedItem as Gift;
            GiftController.DeleteGift(SelectedGift!);
            RefreshGrid(); 
        }
        private void RefreshGrid()
        {
            GiftSGrid.Items.Clear();
            GiftController.LoadDataToGrid(GiftSGrid);
        }
    }
}
