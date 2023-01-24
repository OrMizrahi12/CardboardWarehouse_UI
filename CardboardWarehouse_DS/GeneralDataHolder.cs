using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardboardWarehouse_DS
{
    public class GeneralDataHolder
    {
        private static readonly Carton[] _cartons = new Carton[100];
        public static Carton[]? Cartons { get { return _cartons; } set { } }


        private static readonly Gift[] _gift = new Gift[100];
        public static Gift[]? Gifts { get { return _gift; } set { } }
        public GeneralDataHolder() { }
    }
}
