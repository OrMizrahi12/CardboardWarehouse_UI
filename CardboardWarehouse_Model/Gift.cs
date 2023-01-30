using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardboardWarehouse_Model
{
    public class Gift : Cube, IEntity
    {
        private readonly DateTime _creationDate;
        private readonly string _id;
        public DateTime CreationDate { get { return _creationDate; } }

        public string Id => _id;

        public DateTime CreationTime => throw new NotImplementedException();

        public Gift(int x, int y, DateTime creationDate) : base(x, y)
        {
            _creationDate = creationDate;
            _id = DateTime.Now.Ticks.ToString();
        }
    }
}
