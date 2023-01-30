using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardboardWarehouse_Model
{
    public interface IEntity
    {
        string Id { get; }
        DateTime CreationTime { get; }

    }
}
