using CardboardWarehouse_Logic;
using CardboardWarehouse_Model;
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
    /// <summary>
    /// Interaction logic for Purchases.xaml
    /// </summary>
    public partial class Purchases : Page
    {
        ValidationController Vc;
        public Purchases()
        {
            InitializeComponent();
            Vc = new ValidationController(2);
            LoadDataToGrid();
            RefreshCopunGrid();
        }
        private void LoadDataToGrid()
        {
            purchaseGrid.Items.Clear();
            PurchaseController.LoadDataToGrid(purchaseGrid);
            GetCurrenProfit(); 
        }
        private void GetCurrenProfit()
        {
            TxtTotalProfit.Content =$"Total Balance: {PurchaseController.CulculateTotalProfit()}";
        }

        private void BtnAddCopun_Click(object sender, RoutedEventArgs e)
        {
            ValidationAttempt();

            if (Vc.SuccessValidation())
            {
                CopunController.AddCopun(new Copun(int.Parse(TxtCopunPrecent.Text), TxtCopunName.Text));
                RefreshCopunGrid();
                Vc.ClearValidationList();
            }
            else
            {
                MessageBox.Show("Validation Error");
            }
            
        }

        private void ValidationAttempt()
        {
            Vc.NumValidation(TxtCopunPrecent.Text, "Precent", 1, 90);
            Vc.StringValidation(TxtCopunName.Text);
        }

        private void RefreshCopunGrid()
        {
            CopunGrid.Items.Clear();
            CopunController.LoadCopunGrid(CopunGrid);
        }

        private void BtnDeleeteCopun_Click(object sender, RoutedEventArgs e)
        {
            if (CopunGrid.SelectedItem is Copun copun)
            {
                CopunController.DeleteCopun(copun);
                RefreshCopunGrid();
            }
        }
    }
}
