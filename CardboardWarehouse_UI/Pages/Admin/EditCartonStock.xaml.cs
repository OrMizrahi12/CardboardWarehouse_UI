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

namespace CardboardWarehouse_UI.Pages.Admin
{

    public partial class EditCartonStock : Page
    {
        public EditCartonStock()
        {
            InitializeComponent();
            CartonDataController.LoadDataToGrid(CartonsGrid);
        }

        private void CartonSelected(object sender, MouseButtonEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            
            Carton? SelectedCarton = dg.SelectedItem as Carton;

            MessageBox.Show(SelectedCarton?.X.ToString(), SelectedCarton?.Y.ToString());
        }

        private void BtnDeletCarton_Click(object sender, RoutedEventArgs e)
        {
            if (CartonsGrid.SelectedItem is Carton SelectedCarton)
            {
                CartonDataController.DeleteCarton(SelectedCarton);
            }
            ClearCartonGrid();
            CartonDataController.LoadDataToGrid(CartonsGrid);

        }

        private void BtnIncrement_Click(object sender, RoutedEventArgs e)
        {
            if (CartonsGrid.SelectedItem is Carton SelectedCarton)
            {
                CartonDataController.IncrementStock(SelectedCarton);
            }
            ClearCartonGrid();
            CartonDataController.LoadDataToGrid(CartonsGrid);
        }

        private void BtnDecrement_Click(object sender, RoutedEventArgs e)
        {
            if (CartonsGrid.SelectedItem is Carton SelectedCarton)
            {
                CartonDataController.DicrementCarton(SelectedCarton);
            }
            ClearCartonGrid();
            CartonDataController.LoadDataToGrid(CartonsGrid);
        }

        private void BtnAddCarton_Click(object sender, RoutedEventArgs e)
        {
            CartonDataController.AddCarton(new Carton(int.Parse(TxtX.Text), int.Parse(TxtY.Text), int.Parse(TxtCount.Text), DateTime.Now));
            ClearCartonGrid();
            CartonDataController.LoadDataToGrid(CartonsGrid);
        }

        private void ClearCartonGrid()
        {
            CartonsGrid.Items.Clear();
        }

    }
}
