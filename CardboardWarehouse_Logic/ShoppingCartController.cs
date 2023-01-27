using CardboardWarehouse_DB;
using CardboardWarehouse_DS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using CardboardWarehouse_Model;

namespace CardboardWarehouse_Logic
{
    public class ShoppingCartController
    {
        private static float _totalPrice; 
        public static int ItemsCount { get { return GeneralDataHolder.CartList.Count;} }
        public static float TotalPrice { get { return _totalPrice; } }

        public static float Discount { get; private set; }
        public static void LoadDataToGrid(DataGrid grid)
        {
            LoadDataHelper(grid);
        }

        public static void LoadDataHelper(DataGrid grid)
        {
            for (int i = 0; i < GeneralDataHolder.CartList.Count; i++)
            {
                grid.Items.Add(GeneralDataHolder.CartList.Items[i]);
            }
        }

        static public void LoadDataFromJson()
        {
            JsonDataInformer.LoadCartFromJson(PathInfo.SoppingCartPath);
        }
        static public bool AddToCart(Carton carton)
        {
            if (CartonNotNull(carton))
            {
                if (CartonController.GetCarton(carton).Count != 0)
                {
                    GeneralDataHolder.CartList.Add(carton);
                    CartonController.DicrementCarton(carton);
                    _totalPrice += CartonController.GetCarton(carton).Price;
                    return true;    
                }
                return false;
            }
            return false;
        }

        static public void RemoveFromCart(Carton carton)
        {
           if(CartonNotNull(carton))
           {
               GeneralDataHolder.CartList.Remove(carton);                
               CartonController.IncrementStock(carton);
              _totalPrice -= CartonController.GetCarton(carton).Price;
            }
        }
        static private bool CartonNotNull(Carton carton)
        {
            return carton != null; 
        }

        static public void ClearCart()
        {
            GeneralDataHolder.CartList.Clear();
            _totalPrice = 0;
        }

        public static bool UpdateDiscount(string codeCopun)
        {
            Discount = CopunController.GetPrecent(codeCopun);

            if(Discount != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }                          
        public static float CulculateTotalPriceWithCopun()
        {
            if(Discount > 0)
            {
              
                return TotalPrice * (100 - Discount) / 100;
            }
            else
            {
                return TotalPrice; 
            }
             
        }
    }
}
