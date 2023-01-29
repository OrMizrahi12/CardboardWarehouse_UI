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

    public partial class ShopingCart : Page
    {
        public ShopingCart()
        {
            InitializeComponent();
            ShoppingCartController.LoadDataToGrid(CartGrid);
            RefrechTotalPrice();
        }

        private void btnDeleteFromCart_Click(object sender, RoutedEventArgs e)
        {
            Carton? SelectedCarton = CartGrid.SelectedItem as Carton;

            if(SelectedCarton != null)
            {
                ShoppingCartController.RemoveFromCart(SelectedCarton);
                RefreshGrid();
            }
        }
        private void RefreshGrid()
        {
            CartGrid.Items.Clear();
            ShoppingCartController.LoadDataToGrid(CartGrid);
            RefrechTotalPrice();
        }
        private void RefrechTotalPrice()
        {
            totalPriceLabel.Content = $"Total Price: {ShoppingCartController.CulculateTotalPriceWithCopun()}";
        }

        private void BtnPay_Click(object sender, RoutedEventArgs e)
        {
            bool IsComplate = ShoppingCartController.GetPay(TxtPay.Text).isComplate;
            int exsses = ShoppingCartController.GetPay(TxtPay.Text).exsses;

            if (IsComplate)
            {
                MessageBox.Show($"Your exess is: {exsses}");
                ShoppingCartController.FinishProccess();
            }
            else
            {
                MessageBox.Show("Pay as well.");
            }
                
            RefreshGrid();
        }

        private void BtnAddCodeCopun_Click(object sender, RoutedEventArgs e)
        {
           bool succuss = ShoppingCartController.UpdateDiscount(TxtAddCopun.Text);
            if (succuss)
            {
                TxtSuccess.Content = $"You have copun of {ShoppingCartController.Discount}% !";
                TxtSuccess.Foreground = Brushes.Green;
            }
            else
            {
                TxtSuccess.Content = $"Sorry, the code in not exsist.";
                TxtSuccess.Foreground = Brushes.Red;
            }
            RefrechTotalPrice();
        }
    }
}
