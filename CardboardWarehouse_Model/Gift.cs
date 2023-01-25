using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardboardWarehouse_Model
{
    public class Gift : Cube
    {
        private DateTime _creationDate;
        public DateTime CreationTime { get { return _creationDate; } }
        public DateTime CreationDate { get { return _creationDate; } }
        public Gift(int x, int y, DateTime creationDate) : base(x, y)
        {
            _creationDate = creationDate;
        }
    }
}
