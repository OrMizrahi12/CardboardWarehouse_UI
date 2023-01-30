using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardboardWarehouse_Model
{
    public class Purchase : IEntity
    {
        private readonly string _id;
        private readonly int _itemCount;
        private readonly int _totalPrice;
        private readonly DateTime _creationTime;

        public Purchase(int itemCount, int totalPrice, DateTime date)
        {
            _id = DateTime.Now.Ticks.ToString();
            _itemCount = itemCount;
            _totalPrice = totalPrice;
            _creationTime = date;
        }
        public string Id { get { return _id; } }
        public int ItemCount { get { return _itemCount; } }
        public int TotalPrice { get { return _totalPrice; } }
        public DateTime CreationTime { get { return _creationTime; } }

    
    }
}
