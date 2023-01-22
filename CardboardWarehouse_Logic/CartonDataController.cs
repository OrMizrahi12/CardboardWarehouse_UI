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
            _cartonTable = new HashTable(100);
            JsonLogic = new JsonLogic();
            Carton[] c = { new Carton(10, 101, 0), new Carton(120, 101, 0) };
            JsonLogic.UpdateCartonDataInJson(PathInfo.CartonJsonPath, c);
            
            LoadDataFromJson();
        }
        public void LoadDataToGrid(DataGrid grid)
        {
            Carton[] c = { new Carton(10, 101, 0), new Carton(120, 101, 0) };
            JsonLogic.UpdateCartonDataInJson(PathInfo.CartonJsonPath, c);
            LoadDataFromJson();

            _cartonTable.LoadDataToGrid(grid);

        }

        static public void LoadDataFromJson()
        {
            _cartonTable.cartons = JsonLogic.LoadJsonToTree(_cartonTable.cartons, PathInfo.CartonJsonPath);
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
            }
        }

        public void DeleteCarton(Carton carton)
        {
            if (NotNull(carton))
            {
                _cartonTable.Remove(carton); 
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

        private bool NotNull(Carton carton)
        {
            return carton != null; 
        }

        //public void UpdateStocK(bool increment,Carton carton)
        //{
        //    _cartonTable.UpdateStocK(increment, carton);
        //}

        //public void UpdateJsonCartonData()
        //{
        //    JsonLogic.UpdateCartonDataInJson(PathInfo.CartonJsonPath, _cartonTable.Root); 
        //}

    }
}
