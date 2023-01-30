using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardboardWarehouse_Model
{
    public class Copun : IEntity
    {
        readonly int _precent;
        readonly string _copunName;
        private string _id;
        private DateTime _creationTime;
        public Copun(int precent, string copunName)
        {
            _precent = precent;
            _copunName = copunName;
            _id = DateTime.Now.Ticks.ToString();
            _creationTime = DateTime.Now;

        }
        public int Precent { get { return _precent; } }
        public string CopunName { get { return _copunName; } }

        public string Id => _id;

        public DateTime CreationTime => _creationTime;

        public override string ToString()
        {
            return $"{_precent},{_copunName}";
        }
    }
}
