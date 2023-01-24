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

namespace CardboardWarehouse_Logic
{
    
    public class JsonLogic
    {
        public static void UpdateJsonData(string path)
        {
            string json = JsonConvert.SerializeObject(GeneralDataHolder.Cartons);
            File.WriteAllText(path, json);
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
                        if (GeneralDataHolder.Cartons != null)
                        {
                            CartonController.AddCarton(cartons[i]);
                        }

                    }
                }
            }

            return cartons!; 
        }
    }
}
    
