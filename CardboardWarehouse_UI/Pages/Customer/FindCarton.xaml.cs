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
    public partial class FindCarton : Page
    {
        Carton mathCarton = new(0,0,0,DateTime.Now,0);
        public FindCarton()
        {
            InitializeComponent();
            GiftController.LoadDataToGrid(GiftSGrid);
            btnAddToCart.Visibility = Visibility.Hidden;
        }

        private void GiftSelected(object sender, MouseButtonEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;

            Gift? SelectedGift = dg.SelectedItem as Gift;

            RectanglePresent.Width = (double)(SelectedGift?.X!);
            RectanglePresent.Height = (double)(SelectedGift?.Y!);

            mathCarton = CartonController.GetClosestCarton(SelectedGift.X, SelectedGift.Y); 
           
            if(mathCarton != null && mathCarton.Count != 0)
            {
                ShowMathResult(mathCarton.X, mathCarton.Y, "Math!", "Green");
                btnAddToCart.Visibility = Visibility.Visible;
            }
            else 
            {
                ShowMathResult(0, 0, "Not Found", "Red");
                btnAddToCart.Visibility = Visibility.Hidden;
            }
        }

        private void ShowMathResult(int x, int y, string txt, string color)
        {
            RectangleMath.Width = x;
            RectangleMath.Height = y;
            txtMath.Content = txt;

            BrushConverter converter = new();
            txtMath.Foreground = (Brush)converter.ConvertFromString(color)!;
        }

        private void BtnAddToCart_Click(object sender, RoutedEventArgs e)
        {
            if(mathCarton.X != 0 && mathCarton.Y != 0)
            {
                bool added = ShoppingCartController.AddToCart(mathCarton);

                if (added)
                {
                    MessageBox.Show("The carton are added to cart!");
                }
                else
                {
                    MessageBox.Show("out of stock");
                }
                
                btnAddToCart.Visibility = Visibility.Hidden;
            }
             
        }
    }
}
