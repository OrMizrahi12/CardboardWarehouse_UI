using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardboardWarehouse_Model
{
    public class Copun
    {
        int _precent; 
        string _copunName;

        public Copun(int precent, string copunName)
        {
            _precent = precent;
            _copunName = copunName;
        }
        public int Precent { get { return _precent; } }
        public string CopunName { get { return _copunName; } }

        public override string ToString()
        {
            return $"{_precent},{_copunName}";
        }
    }
}
