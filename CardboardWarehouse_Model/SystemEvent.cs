using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardboardWarehouse_Model
{
    public class SystemEvent
    {
        private DateTime _date; 
        private string ? _name;

        public SystemEvent(DateTime date, string? name)
        {
            _date = date;
            _name = name;
        }
        public DateTime Date { get { return _date; } }
        public string ? Name { get { return _name;  } }


        public override string ToString()
        {
            return $"Event Name:{_name}\nDate{_date}";
        }
    }
}
