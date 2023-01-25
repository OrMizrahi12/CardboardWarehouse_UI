using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using CardboardWarehouse_DB;
using CardboardWarehouse_DS;
using CardboardWarehouse_Model;

namespace CardboardWarehouse_Logic
{
    public class PurchaseController
    {
        // To fix!
        public static void LoadDataToGrid(DataGrid grid)
        {
            JsonDataInformer.LoadPurchaseFromJson();
            JsonLogic.UpdateJsonData(PathInfo.PurchasePath);
            LoadPurchaseGrid(grid);
        }


        static public void AddPurchase(Purchase purchase)
        {
            GeneralDataHolder.Purchase.Add(purchase);
            ShoppingCartController.ClearCart();
        }

        static public void LoadPurchaseGrid(DataGrid dataGrid)
        {
            for (int i = 0; i < GeneralDataHolder.Purchase.Count; i++)
            {
                dataGrid.Items.Add(GeneralDataHolder.Purchase[i]);
            }
        }

        static public int CulculateTotalProfit()
        {
            int totalProfit = 0;

            for (int i = 0; i < GeneralDataHolder.Purchase.Count; i++)
            {
                totalProfit += GeneralDataHolder.Purchase[i].TotalPrice;
            }

            return totalProfit; 
        }
    }
}
