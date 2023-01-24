using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardboardWarehouse_DS
{
    public class Carton : Cube
    {
        private int _x;
        private int _y;
        private int _count;
        private DateTime _creationTime;
        private DateTime _lastAction;

        public int Count { get { return _count; } set { _count = value; } }
        public int X { get => _x; set { } }
        public int Y { get => _y; set { } }
        public DateTime CreationTime { get { return _creationTime; } }
        public DateTime ExpiryDate { get { return LastAction.AddDays(5); } }
        public TimeSpan ExpiryDateInDeys { get { return ExpiryDate - LastAction; } } 
        public DateTime LastAction { get { return _lastAction; } set { _lastAction = value; } }
        
        public Carton(int x, int y, int count, DateTime creationTime) : base(x, y)
        {
            _x = x;
            _y = y;
            _count = count;
            _creationTime = creationTime;
        }


        public override string ToString()
        {
            return $"({_x},{_y}{_creationTime})";
        }
    }
}
