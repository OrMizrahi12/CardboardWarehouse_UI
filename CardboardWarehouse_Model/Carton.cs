using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardboardWarehouse_Model
{
    public class Carton : Cube
    {
        private readonly int _x;
        private readonly int _y;
        private int _count;
        private int _price;
        private readonly DateTime _creationTime;
        private DateTime _lastAction;

        public int Count { get { return _count; } set { _count = value; } }
        public DateTime CreationTime { get { return _creationTime; } }
        public DateTime ExpiryDate { get { return LastAction.AddDays(5); } }
        public TimeSpan ExpiryDateInDeys { get { return ExpiryDate - LastAction; } }
        public DateTime LastAction { get { return _lastAction; } set { _lastAction = value; } }
        public Carton Next { get; set; }

        public int Price { get { return _price; } }

        public Carton(int x, int y, int count, DateTime creationTime, int price) : base(x, y)
        {
            _x = x;
            _y = y;
            _count = count;
            _creationTime = creationTime;
            Next = null!;
            _price = price;
        }


        public override string ToString()
        {
            return $"({_x},{_y})";
        }
    }
}
