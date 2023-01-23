using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardboardWarehouse_DS
{
    public class Carton
    {


        private int _x;
        private int _y;
        private int _count;
        private DateTime _dateOnly;

        public int Count { get { return _count; } set { _count = value; } }
        public int X { get => _x; set { } }
        public int Y { get => _y; set { } }
        public DateTime Date { get { return _dateOnly; } }

        public Carton(int x, int y, int count)
        {
            _x = x;
            _y = y;
            _count = count;
            // Todo Date time
            _dateOnly = DateTime.Now;
        }


        public override string ToString()
        {
            return $"({_x},{_y})";
        }
    }
}
