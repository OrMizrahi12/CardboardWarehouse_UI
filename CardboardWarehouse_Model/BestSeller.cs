using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardboardWarehouse_Model
{
    public class BestSeller : IEntity
    {
        private int _sales; 
        private int _totalProfit;
        private readonly Carton _carton;
        private readonly string _id;
        private readonly DateTime _creationTime;

        public BestSeller(int sales, int totalProfit, Carton carton)
        {
            _sales = sales;
            _totalProfit = totalProfit;
            _carton = carton;
            _id = DateTime.Now.Ticks.ToString();
            _creationTime = DateTime.Now;

        }

        public int Sales { get { return _sales; } set { _sales = value; } }
        public int TotalProfit { get { return _totalProfit; } set { _totalProfit = value;  } }
        public Carton Carton { get { return _carton; } set { }}

        public string Id { get => _id;}
        public DateTime CreationTime { get => _creationTime;  }
    }
}
