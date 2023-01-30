using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardboardWarehouse_Model
{
    public class SystemEvent : IEntity
    {
        private readonly DateTime _creationTime; 
        private readonly string ? _name;
        private readonly string _id;


        public SystemEvent(DateTime date, string? name)
        {
            _creationTime = date;
            _name = name;
            _id = DateTime.Now.Ticks.ToString();
        }
        public DateTime Date { get { return _creationTime; } }
        public string ? Name { get { return _name;  } }

        public string Id => _id;

        public DateTime CreationTime => _creationTime;

        public override string ToString()
        {
            return $"Event Name:{_name}\nDate{_creationTime}";
        }
    }
}
