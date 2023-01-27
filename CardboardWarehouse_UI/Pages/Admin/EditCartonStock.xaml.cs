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
using CardboardWarehouse_DB;

namespace CardboardWarehouse_UI.Pages.Admin
{

    public partial class EditCartonStock : Page
    {
        ValidationController Vc;
        public EditCartonStock()
        {
            InitializeComponent();
            CartonController.LoadDataToGrid(CartonsGrid);
            Vc = new ValidationController(4);
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
            RefreshGrid();

        }

        private void BtnIncrement_Click(object sender, RoutedEventArgs e)
        {
            if (CartonsGrid.SelectedItem is Carton SelectedCarton)
            {
                CartonController.IncrementStock(SelectedCarton);

            }
            RefreshGrid();
        }

        private void BtnDecrement_Click(object sender, RoutedEventArgs e)
        {
            if (CartonsGrid.SelectedItem is Carton SelectedCarton)
            {
                CartonController.DicrementCarton(SelectedCarton);
            }
            RefreshGrid();
        }

        private void BtnAddCarton_Click(object sender, RoutedEventArgs e)
        {

            ValidationAttempt();

            if (Vc.SuccessValidation())
            {
                CartonController.AddCarton(new Carton(int.Parse(TxtX.Text), int.Parse(TxtY.Text), int.Parse(TxtCount.Text), DateTime.Now, int.Parse(TxtPrice.Text)));
                Vc.ClearValidationList();
            }
            else
            {
                MessageBox.Show("Validation Error");
            }
            RefreshGrid();

        }

        private void ValidationAttempt()
        {
            Vc.NumValidation(TxtX.Text, "x");
            Vc.NumValidation(TxtY.Text, "y");
            Vc.NumValidation(TxtCount.Text, "Count");
            Vc.NumValidation(TxtPrice.Text, "Price");
        }

        private void BtnRemoveUnuse_Click(object sender, RoutedEventArgs e)
        {
            CartonController.GarbejCollection();
            RefreshGrid();
        }

        private void BtnUndo_Click(object sender, RoutedEventArgs e)
        {
            CartonController.CartonUndoActions();
            RefreshGrid();
        }

        private void BtnRedo_Click(object sender, RoutedEventArgs e)
        {
            CartonController.CartonRedoAction();
            RefreshGrid();
        }
        private void RefreshGrid()
        {
            CartonsGrid.Items.Clear();
            CartonController.LoadDataToGrid(CartonsGrid);
        }

    }
}
