﻿using CardboardWarehouse_DS;
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
            totalPriceLabel.Content = $"Total Price: {ShoppingCartController.TotalPrice}";
        }

        private void BtnPay_Click(object sender, RoutedEventArgs e)
        {
            PurchaseController.AddPurchase(new Purchase(ShoppingCartController.ItemsCount, ShoppingCartController.TotalPrice, DateTime.UtcNow));
            RefreshGrid();
        }
    }
}
