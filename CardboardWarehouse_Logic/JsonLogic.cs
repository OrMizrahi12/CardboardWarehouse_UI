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
        public void UpdateCartonDataInJson(string path, Carton[] cartons)
        {
            // Serialize CartonHashTable to JSON
            string json = JsonConvert.SerializeObject(cartons);

            // Write JSON to file
            File.WriteAllText(path, json);
        }

        public Carton[] LoadJsonToTree(Carton[] cartons, string path)
        {
            
            string json = File.ReadAllText(path);


            cartons = JsonConvert.DeserializeObject<Carton[]>(json);
            return cartons; 
        }



    }
}
