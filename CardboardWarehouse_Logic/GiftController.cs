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
    public class GiftController
    {
        static readonly GenericHash<Gift> _giftsTable;

        static GiftController()
        {
            _giftsTable = new GenericHash<Gift>(GeneralDataHolder.Gifts!);
            LoadDataFromJson();
            JsonLogic.UpdateJsonData(PathInfo.GiftsJsonPath);
        }
        public static void LoadDataToGrid(DataGrid grid)
        {
            LoadDataFromJson();
            JsonLogic.UpdateJsonData(PathInfo.GiftsJsonPath);
            _giftsTable.LoadDataToGrid(grid);

        }

        static public void LoadDataFromJson()
        {
            JsonDataInformer.LoadGiftsFromJson(PathInfo.GiftsJsonPath);
            //JsonLogic.LoadJsonToTree(PathInfo.CartonJsonPath);
        }


        public static void AddGift(Gift gifts)
        {
            if (NotNull(gifts))
            {
                _giftsTable.Add(gifts);
                JsonLogic.UpdateJsonData(PathInfo.GiftsJsonPath);
            }
        }

        public static void DeleteGift(Gift gifts)
        {
            if (NotNull(gifts))
            {
                _giftsTable.Remove(gifts);
                JsonLogic.UpdateJsonData(PathInfo.GiftsJsonPath);
            }
        }

        public static Gift GetGift(Gift gifts)
        {
            if (NotNull(gifts))
            {
                return _giftsTable.Get(gifts);
            }
            else
            {
                return default!;
            }
        }

        //public static void IncrementStock(Gift gifts)
        //{
        //    if (NotNull(carton))
        //    {
        //        Carton pointer = _giftsTable.Get(carton);
        //        pointer.Count++;
        //        UpdateCartonLastAction(pointer);
        //    }
        //    JsonLogic.UpdateJsonData(PathInfo.CartonJsonPath);
        //}

        //public static void DicrementCarton(Gift gifts)
        //{
        //    if (NotNull(carton) && carton.Count > 1)
        //    {
        //        _giftsTable.Get(carton).Count--;
        //    }
        //    else if (NotNull(carton) && carton.Count == 1)
        //    {
        //        _giftsTable.Remove(carton);
        //    }
        //    JsonLogic.UpdateJsonData(PathInfo.CartonJsonPath);

        //}

        // All perches i updating the last action
        //public static void UpdateCartonLastAction(Gift gifts)
        //{
        //    gifts.LastAction = DateTime.Now;
        //}

        private static bool NotNull(Gift gifts)
        {
            return gifts != null;
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
