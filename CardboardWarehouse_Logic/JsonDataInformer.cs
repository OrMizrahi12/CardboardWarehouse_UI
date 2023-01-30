using CardboardWarehouse_DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardboardWarehouse_Logic
{
    public class JsonDataInformer
    {
        public static void UpdateJsonData(string path)
        {
            JsonLogic.UpdateJsonData(path);
        }

        public static void LoadDataFromJson(string path)
        {
            JsonLogic.LoadDataFromJson(path);
        }

        public static void LoadCartFromJson(string path)
        {
            JsonLogic.LoadCartFromJson(path);
        }

        public static void LoadGiftsFromJson(string path)
        {
            JsonLogic.LoadGiftsFromJson(path);
        }

        public static void LoadPurchaseFromJson()
        {
            JsonLogic.LoadPurchaseFromJson(PathInfo.PurchasePath);
        }

        public static void LoadBestSellersFromJson(string path)
        {
            JsonLogic.LoadBestSellerFromJson(path); 
        }
    }
}
