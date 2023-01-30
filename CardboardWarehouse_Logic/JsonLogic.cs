using CardboardWarehouse_DB;
using CardboardWarehouse_DS;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Xml;
using CardboardWarehouse_Model;

namespace CardboardWarehouse_Logic
{
    
    public class JsonLogic
    {
        public static void UpdateJsonData(string path)
        {
            try
            {
                if (path == PathInfo.CartonJsonPath)
                {
                    string json = JsonConvert.SerializeObject(GeneralDataHolder.Cartons.Table);
                    File.WriteAllText(path, json);
                }
                else if (path == PathInfo.GiftsJsonPath)
                {
                    string json = JsonConvert.SerializeObject(GeneralDataHolder.Gifts.Table);
                    File.WriteAllText(path, json);
                }
                else if (path == PathInfo.SoppingCartPath)
                {
                    string json = JsonConvert.SerializeObject(GeneralDataHolder.CartList.Items);
                    File.WriteAllText(path, json);
                }
                else if (path == PathInfo.PurchasePath)
                {
                    string json = JsonConvert.SerializeObject(GeneralDataHolder.Purchase.Items);
                    File.WriteAllText(path, json);
                }
                else if (path == PathInfo.BestSellerPath)
                {
                    string json = JsonConvert.SerializeObject(GeneralDataHolder.BestSellers.Items);
                    File.WriteAllText(path, json);

                }
            }
            catch
            {
                LogEventController.AddLogEvent("Path Error");

            }
        }

        public static void LoadDataFromJson( string path)
        {

            try
            {
                string json = File.ReadAllText(path);
                Carton[]? cartons = JsonConvert.DeserializeObject<Carton[]>(json);

                if (cartons != null)
                {
                    for (int i = 0; i < cartons.Length; i++)
                    {
                        if (cartons[i] != null)
                        {
                            if (GeneralDataHolder.Cartons.Table != null)
                            {
                                CartonController.AddCarton(cartons[i]);
                            }

                        }
                    }
                }
            }
            catch
            {
                LogEventController.AddLogEvent("Json Load error");
            }

        }

        public static void LoadGiftsFromJson(string path)
        {
            try
            {
                string json = File.ReadAllText(path);
                Gift[]? gifts = JsonConvert.DeserializeObject<Gift[]>(json);

                if (gifts != null)
                {
                    for (int i = 0; i < gifts.Length; i++)
                    {
                        if (gifts[i] != null)
                        {
                            if (GeneralDataHolder.Gifts != null)
                            {
                                GiftController.AddGift(gifts[i]);
                            }

                        }
                    }
                }
            }
            catch 
            {
                LogEventController.AddLogEvent("Json Load error");
            }
        }

        public static void LoadCartFromJson(string path)
        {
            try
            {
                string json = File.ReadAllText(path);
                Carton[]? cartons = JsonConvert.DeserializeObject<Carton[]>(json);

                if (cartons != null)
                {
                    for (int i = 0; i < cartons.Length; i++)
                    {
                        if (cartons[i] != null)
                        {
                            if (GeneralDataHolder.CartList.Items != null)
                            {
                                ShoppingCartController.AddToCart(cartons[i]);
                            }
                        }
                    }
                }
            }
            catch 
            {
                LogEventController.AddLogEvent("Json Load error");
            }
        }

        public static void LoadPurchaseFromJson(string path)
        {
            try
            {
                string json = File.ReadAllText(path);

                Purchase[]? purchases = JsonConvert.DeserializeObject<Purchase[]>(json);
                GeneralDataHolder.Purchase.Clear();

                if (purchases != null)
                {
                    for (int i = 0; i < purchases.Length; i++)
                    {
                        if (purchases[i] != null)
                        {
                            if (GeneralDataHolder.Purchase.Items != null)
                            {
                                PurchaseController.AddPurchase(purchases[i]);
                            }

                        }
                    }
                }
            }
            catch 
            {
                LogEventController.AddLogEvent("Json Load error");
            }
        }

        public static void LoadBestSellerFromJson(string path)
        {
            try
            {
                string json = File.ReadAllText(path);
                BestSeller[]? bestSellers = JsonConvert.DeserializeObject<BestSeller[]>(json);
                GeneralDataHolder.BestSellers.Clear();

                if (bestSellers != null)
                {
                    foreach (var item in bestSellers)
                    {
                        if (item != null)
                        {
                            GeneralDataHolder.BestSellers.Add(item);
                        }
                    }
                }
            }
            catch 
            {
                LogEventController.AddLogEvent("Json Load error");
            }
        }
    }
}
    
