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

namespace CardboardWarehouse_UI.Pages.Admin
{

    public partial class EditCartonStock : Page
    {
        public EditCartonStock()
        {
            InitializeComponent();
            CartonController.LoadDataToGrid(CartonsGrid);
        }

        private void CartonSelected(object sender, MouseButtonEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            
            Carton? SelectedCarton = dg.SelectedItem as Carton;

            RectanglePresent.Width = (double)(SelectedCarton?.X!);
            RectanglePresent.Height= (double)(SelectedCarton?.Y!);
        }

        private void BtnDeletCarton_Click(object sender, RoutedEventArgs e)
        {
            if (CartonsGrid.SelectedItem is Carton SelectedCarton)
            {
                CartonController.DeleteCarton(SelectedCarton);
            }
            ClearCartonGrid();
            CartonController.LoadDataToGrid(CartonsGrid);

        }

        private void BtnIncrement_Click(object sender, RoutedEventArgs e)
        {
            if (CartonsGrid.SelectedItem is Carton SelectedCarton)
            {
                CartonController.IncrementStock(SelectedCarton);
            }
            ClearCartonGrid();
            CartonController.LoadDataToGrid(CartonsGrid);
        }

        private void BtnDecrement_Click(object sender, RoutedEventArgs e)
        {
            if (CartonsGrid.SelectedItem is Carton SelectedCarton)
            {
                CartonController.DicrementCarton(SelectedCarton);
                //CartonDataController.DicrementCarton(SelectedCarton);
            }
             ClearCartonGrid();
             CartonController.LoadDataToGrid(CartonsGrid);
             //CartonDataController.LoadDataToGrid(CartonsGrid);
        }

        private void BtnAddCarton_Click(object sender, RoutedEventArgs e)
        {
            CartonController.AddCarton(new Carton(int.Parse(TxtX.Text), int.Parse(TxtY.Text), int.Parse(TxtCount.Text), DateTime.Now, int.Parse(TxtPrice.Text)));
            ClearCartonGrid();
            CartonController.LoadDataToGrid(CartonsGrid);
        }

        private void ClearCartonGrid()
        {
            CartonsGrid.Items.Clear();
        }

    }
}
