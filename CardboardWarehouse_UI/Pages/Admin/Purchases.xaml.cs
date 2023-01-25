﻿using CardboardWarehouse_Logic;
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
        public Purchases()
        {
            InitializeComponent();
            PurchaseController.LoadDataToGrid(purchaseGrid); 
        }
    }
}
