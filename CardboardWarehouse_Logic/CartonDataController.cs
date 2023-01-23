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
        static JsonLogic JsonLogic;
        static HashTable  _cartonTable;
        
        static CartonDataController()
        {
            _cartonTable = new HashTable();
            JsonLogic = new JsonLogic();
            LoadDataFromJson();
            JsonLogic.UpdateCartonDataInJson(PathInfo.CartonJsonPath);
        }
        public void LoadDataToGrid(DataGrid grid)
        {
            LoadDataFromJson();
            JsonLogic.UpdateCartonDataInJson(PathInfo.CartonJsonPath);

            _cartonTable.LoadDataToGrid(grid);

        }

        static public void LoadDataFromJson()
        {
            JsonLogic.LoadJsonToTree(PathInfo.CartonJsonPath);
        }
        public void LoadDataToGrid(DataGrid grid, Carton travel)
        {
            if(travel == null)
            {
                return;
            }
            //LoadDataToGrid(grid, travel.Left);
            //grid.Items.Add(new Carton(travel.X,travel.Y, travel.Count));
            //LoadDataToGrid(grid, travel.Right);

        }

        public void AddCarton(Carton carton)
        {
            if(NotNull(carton))
            {
                _cartonTable.Add(carton);
                JsonLogic.UpdateCartonDataInJson(PathInfo.CartonJsonPath);
            }
        }

        public void DeleteCarton(Carton carton)
        {
            if (NotNull(carton))
            {
                _cartonTable.Remove(carton);
                JsonLogic.UpdateCartonDataInJson(PathInfo.CartonJsonPath);
            }
        }

        public Carton GetCarton(Carton carton)
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

        public void IncrementStock(Carton carton)
        {
            if (NotNull(carton))
            {
                _cartonTable.Get(carton.X, carton.Y).Count++;
            }
            JsonLogic.UpdateCartonDataInJson(PathInfo.CartonJsonPath);

        }

        public void DicrementCarton(Carton carton)
        {
            if (NotNull(carton) && carton.Count > 1)
            {
                _cartonTable.Get(carton.X, carton.Y).Count--;
            }
            else if(NotNull(carton) && carton.Count == 1)
            {
                _cartonTable.Remove(carton); 
            }
            JsonLogic.UpdateCartonDataInJson(PathInfo.CartonJsonPath);

        }

        private bool NotNull(Carton carton)
        {
            return carton != null; 
        }


    }
}
