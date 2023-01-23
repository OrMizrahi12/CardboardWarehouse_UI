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
    }
}
