using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardboardWarehouse_Model
{
    public class Purchase
    {
        private string _id;
        private int _itemCount;
        private int _totalPrice;
        private DateTime _date;

        public Purchase(int itemCount, int totalPrice, DateTime date)
        {
            _id = DateTime.Now.Ticks.ToString();
            _itemCount = itemCount;
            _totalPrice = totalPrice;
            _date = date;
        }
        public string Id { get { return _id; } }
        public int ItemCount { get { return _itemCount; } }
        public int TotalPrice { get { return _totalPrice; } }
        public DateTime Date { get { return _date; } }
    }
}
