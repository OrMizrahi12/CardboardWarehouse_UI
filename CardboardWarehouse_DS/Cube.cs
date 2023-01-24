using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardboardWarehouse_DS
{
    public abstract class Cube
    {
        private int _x; 
        private int _y;

        public Cube(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public override string ToString()
        {
            return $"{_x}{_y}";
        }

    }
}
