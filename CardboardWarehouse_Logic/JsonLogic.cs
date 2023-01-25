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
            if(path == PathInfo.CartonJsonPath)
            {
                string json = JsonConvert.SerializeObject(GeneralDataHolder.Cartons.Table);
                File.WriteAllText(path, json);
            }
            else if(path == PathInfo.GiftsJsonPath)
            {
                string json = JsonConvert.SerializeObject(GeneralDataHolder.Gifts.Table);
                File.WriteAllText(path, json);
            }
            else if(path == PathInfo.SoppingCartPath)
            {
                string json = JsonConvert.SerializeObject(GeneralDataHolder.CartList.Items);
                File.WriteAllText(path, json);
            }
            else if(path == PathInfo.PurchasePath)
            {
                string json = JsonConvert.SerializeObject(GeneralDataHolder.Purchase.Items);
                File.WriteAllText(path, json);
            }

        }

        public static Carton[] LoadDataFromJson( string path)
        {
            
            string json = File.ReadAllText(path);


            Carton[] ? cartons = JsonConvert.DeserializeObject<Carton[]>(json);

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

            return cartons!; 
        }

        public static Gift[] LoadGiftsFromJson(string path)
        {

            string json = File.ReadAllText(path);


            // its not gifts
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

            return gifts!;
        }

        public static Carton[] LoadCartFromJson(string path)
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

            return cartons!;
        }

        public static Purchase[] LoadPurchaseFromJson(string path)
        {
            Purchase[] ?purchases = JsonConvert.DeserializeObject<Purchase[]>(path);

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

            return purchases!; 
        }


    }
}
    
