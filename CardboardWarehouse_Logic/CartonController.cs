using CardboardWarehouse_DB;
using CardboardWarehouse_DS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CardboardWarehouse_Logic
{
    public class CartonController
    {
        static readonly GenericHash<Carton> _cartonTable;

        static CartonController()
        {
            _cartonTable = new GenericHash<Carton>(GeneralDataHolder.Cartons);
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
            //JsonLogic.LoadJsonToTree(PathInfo.CartonJsonPath);
        }


        public static void AddCarton(Carton carton)
        {
            if (NotNull(carton))
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
                return _cartonTable.Get(carton);
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
                Carton pointer = _cartonTable.Get(carton);
                pointer.Count++;
                UpdateCartonLastAction(pointer);
            }
            JsonLogic.UpdateJsonData(PathInfo.CartonJsonPath);
        }

        public static void DicrementCarton(Carton carton)
        {
            if (NotNull(carton) && carton.Count > 1)
            {
                _cartonTable.Get(carton).Count--;
            }
            else if (NotNull(carton) && carton.Count == 1)
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
        //public void LoadDataToGrid(DataGrid dataGrid)
        //{
        //    for (int i = 0; i < _size; i++)
        //    {
        //        if (_table[i] != null)
        //        {
        //            dataGrid.Items.Add(_table[i]);
        //        }
        //    }
        //}
    }
}
