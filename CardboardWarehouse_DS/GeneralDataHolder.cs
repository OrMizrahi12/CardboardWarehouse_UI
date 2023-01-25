using CardboardWarehouse_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardboardWarehouse_DS
{
    public class GeneralDataHolder
    {


        public static GenericHash<Carton> Cartons = new GenericHash<Carton>(100);


        public static GenericHash<Gift> Gifts = new GenericHash<Gift>(100);

        public static CustomList<Carton> CartList = new CustomList<Carton>();

        public static CustomList<Purchase> Purchase = new CustomList<Purchase>();
        public GeneralDataHolder()
        {
        }
    }
}
