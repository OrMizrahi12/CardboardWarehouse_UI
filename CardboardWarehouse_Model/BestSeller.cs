using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardboardWarehouse_Model
{
    public class BestSeller
    {
        private int _sales; 
        private int _totalProfit;
        private Carton _carton;

        public BestSeller(int sales, int totalProfit, Carton carton)
        {
            _sales = sales;
            _totalProfit = totalProfit;
            _carton = carton;
        }

        public int Sales { get { return _sales; } set { _sales = value; } }
        public int TotalProfit { get { return _totalProfit; } set { _totalProfit = value;  } }
        public Carton Carton { get { return _carton; } set { }}
    }
}
