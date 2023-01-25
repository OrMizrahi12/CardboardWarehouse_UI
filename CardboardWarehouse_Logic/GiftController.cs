using CardboardWarehouse_DB;
using CardboardWarehouse_DS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using CardboardWarehouse_Model;

namespace CardboardWarehouse_Logic
{
    public class GiftController
    {

        public static void LoadDataToGrid(DataGrid grid)
        {
            JsonDataInformer.LoadGiftsFromJson(PathInfo.GiftsJsonPath);
            JsonLogic.UpdateJsonData(PathInfo.GiftsJsonPath);
            GeneralDataHolder.Gifts.LoadDataToGrid(grid);
        }


        public static void AddGift(Gift gifts)
        {
            if (NotNull(gifts))
            {
                GeneralDataHolder.Gifts.Add(gifts);
                JsonLogic.UpdateJsonData(PathInfo.GiftsJsonPath);
            }
        }

        public static void DeleteGift(Gift gifts)
        {
            if (NotNull(gifts))
            {
                GeneralDataHolder.Gifts.Remove(gifts);
                JsonLogic.UpdateJsonData(PathInfo.GiftsJsonPath);
            }
        }

        public static Gift GetGift(Gift gifts)
        {
            if (NotNull(gifts))
            {
                return GeneralDataHolder.Gifts.Get(gifts);
            }
            else
            {
                return default!;
            }
        }

        private static bool NotNull(Gift gifts)
        {
            return gifts != null;
        }

    }
}
