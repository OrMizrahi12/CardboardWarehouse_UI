using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardboardWarehouse_DS
{
    public class GeneralTreeInstance
    {
        public static Carton ? GeneralRoot { get; set; }

        private static readonly Carton[] _cartons = new Carton[100];

        public static Carton[]? Cartons { get { return _cartons; } set { } }

        public GeneralTreeInstance()
        {

        }
        

    }
}
