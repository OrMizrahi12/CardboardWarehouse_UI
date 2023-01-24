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

namespace CardboardWarehouse_UI.Pages.Customer
{
    public partial class FindCarton : Page
    {
        public FindCarton()
        {
            InitializeComponent();
            GiftController.LoadDataToGrid(GiftSGrid);
        }

        private void GiftSelected(object sender, MouseButtonEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;

            Gift? SelectedGift = dg.SelectedItem as Gift;

            RectanglePresent.Width = (double)(SelectedGift?.X!);
            RectanglePresent.Height = (double)(SelectedGift?.Y!);

           Carton mathCarton = CartonController.GetClosestCarton(SelectedGift.X, SelectedGift.Y); 
           
            if(mathCarton != null)
            {
                RectangleMath.Width = (double)mathCarton.X;
                RectangleMath.Height = (double)mathCarton.Y;
            }
        
        }
    }
}
