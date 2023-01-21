using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardboardWarehouse_DS
{
    public class Carton : IComparable<Carton>
    {


        private double _x;
        private double _y;
        private int _count;

        public Carton Left { get; set; }
        public Carton Right { get; set; }

        public int Count { get { return _count; } set { _count = value; } }

        public double X { get => _x; set { } }
        public double Y { get => _y; set { } }

        public Carton(double x, double y, int count)
        {
            _x = x;
            _y = y;
            _count = count;
        }


        public override string ToString()
        {
            return $"({_x},{_y})";
        }



        public int CompareTo(Carton other)
        {
            int compare = _x.CompareTo(other._x);

            if (compare == 0)
            {
                return _y.CompareTo(other._y);
            }

            return compare;
        }


    }
}
