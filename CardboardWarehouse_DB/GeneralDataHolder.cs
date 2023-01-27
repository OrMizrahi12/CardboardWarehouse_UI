using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardboardWarehouse_DS;
using CardboardWarehouse_Model;

namespace CardboardWarehouse_DB
{
    public class GeneralDataHolder
    {
        public static GenericHash<Carton> Cartons = new GenericHash<Carton>(100);


        public static GenericHash<Gift> Gifts = new GenericHash<Gift>(100);

        public static CustomList<Carton> CartList = new CustomList<Carton>();

        public static CustomList<Purchase> Purchase = new CustomList<Purchase>();

        public static GenericStack<Carton> CartonUndoStack = new GenericStack<Carton>();

        public static GenericStack<Carton> CartonRedoStack = new GenericStack<Carton>();

        public static CustomList<Copun> Copuns = new CustomList<Copun>();
        public GeneralDataHolder() { }
    }
}
