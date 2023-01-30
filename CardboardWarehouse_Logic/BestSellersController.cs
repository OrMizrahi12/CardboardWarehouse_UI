using CardboardWarehouse_DB;
using CardboardWarehouse_Logic.Interfaces;
using CardboardWarehouse_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CardboardWarehouse_Logic
{
    public class BestSellersController 
    {
        public static void LoadDataToGrid(DataGrid grid)
        {
            JsonDataInformer.LoadBestSellersFromJson(PathInfo.BestSellerPath);
            JsonLogic.UpdateJsonData(PathInfo.BestSellerPath);
            LoadSalesToGrid(grid);
        }
        public static void AddSell(Carton carton)
        {
            if(NotNull(carton))
            {
                if (ItemExsist(carton))
                {
                    UpdateExsistItem(carton);
                    JsonDataInformer.UpdateJsonData(PathInfo.BestSellerPath);
                }
                else
                {
                    GeneralDataHolder.BestSellers.Add(new BestSeller(1, carton.Price, carton));
                    JsonDataInformer.UpdateJsonData(PathInfo.BestSellerPath);
                }
            }
        }

        private static void UpdateExsistItem(Carton carton)
        {
            BestSeller bestSeller = FindSales(carton);

            if (NotNull(bestSeller))
            {
                bestSeller.Sales++;
                bestSeller.TotalProfit += bestSeller.Carton.Price;
            }
        }
        private static BestSeller FindSales(Carton carton)
        {
            foreach (var item in GeneralDataHolder.BestSellers.Items)
            {
                if(AreTheSame(item.Carton, carton))
                {
                    return item;
                }
            }
            return null!;
        }
        private static bool ItemExsist(Carton carton)
        {
            if (NotNull(carton!))
            {
                foreach (var sale in GeneralDataHolder.BestSellers.Items)
                {
                    if (NotNull(sale))
                    {
                        if (AreTheSame(sale?.Carton!, carton))
                        {
                            return true;
                        }
                    }
                }
            }
            return false; 
        }
        private static bool NotNull(object carton)
        {
            if(carton != null)
            {
                return true;
            }
            else
            {
                return false; 
            }
        }
        private static bool AreTheSame(Carton A, Carton B)
        {
            if(A == B || A.Equals(B) || A.ToString() == B.ToString() || A.X == B.X && A.Y == B.Y)
            {
                return true;
            }
            else
            {
                return false;   
            }
        }

        public static void LoadSalesToGrid(DataGrid dataGrid)
        {
            foreach (var sale in GeneralDataHolder.BestSellers.Items)
            {
                dataGrid.Items.Add(sale); 
            }
        }
    }
}
