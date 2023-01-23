using CardboardWarehouse_DB;
using CardboardWarehouse_DS;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.IO;

namespace CardboardWarehouse_Logic
{
    public class CartonDataController
    {
        static readonly HashTable  _cartonTable;

        static CartonDataController()
        {
            _cartonTable = new HashTable();
            LoadDataFromJson();
            JsonLogic.UpdateJsonData(PathInfo.CartonJsonPath);
        }
        public static void LoadDataToGrid(DataGrid grid)
        {
            LoadDataFromJson();
            JsonLogic.UpdateJsonData(PathInfo.CartonJsonPath);
            _cartonTable.LoadDataToGrid(grid);
        }

        static public void LoadDataFromJson()
        {
            JsonDataInformer.LoadDataFromJson(PathInfo.CartonJsonPath);
           // JsonLogic.LoadJsonToTree(PathInfo.CartonJsonPath);
        }
        public static void LoadDataToGrid(DataGrid grid, Carton travel)
        {
            if(travel == null)
            {
               return;
            }
            //LoadDataToGrid(grid, travel.Left);
            //grid.Items.Add(new Carton(travel.X,travel.Y, travel.Count));
            //LoadDataToGrid(grid, travel.Right);
        }

        public static void AddCarton(Carton carton)
        {
            if(NotNull(carton))
            {
                _cartonTable.Add(carton);
                JsonLogic.UpdateJsonData(PathInfo.CartonJsonPath);
            }
        }

        public static void DeleteCarton(Carton carton)
        {
            if (NotNull(carton))
            {
                _cartonTable.Remove(carton);
                JsonLogic.UpdateJsonData(PathInfo.CartonJsonPath);
            }
        }

        public static Carton GetCarton(Carton carton)
        {
            if (NotNull(carton))
            {
                return _cartonTable.Get(carton.X, carton.Y);
            }
            else
            {
                return default!;
            }
        }

        public static void IncrementStock(Carton carton)
        {
            if (NotNull(carton))
            {
                Carton pointer = _cartonTable.Get(carton.X, carton.Y);
                pointer.Count++;
                UpdateCartonLastAction(pointer);
            }
            JsonLogic.UpdateJsonData(PathInfo.CartonJsonPath);
        }

        public static void DicrementCarton(Carton carton)
        {
            if (NotNull(carton) && carton.Count > 1)
            {
                _cartonTable.Get(carton.X, carton.Y).Count--;
            }
            else if(NotNull(carton) && carton.Count == 1)
            {
                _cartonTable.Remove(carton); 
            }
            JsonLogic.UpdateJsonData(PathInfo.CartonJsonPath);

        }

        // All perches i updating the last action
        public static void UpdateCartonLastAction(Carton carton)
        {
            carton.LastAction = DateTime.Now;
        }

        private static bool NotNull(Carton carton)
        {
            return carton != null; 
        }
    }
}
