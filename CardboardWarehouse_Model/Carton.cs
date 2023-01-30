using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardboardWarehouse_DS;

namespace CardboardWarehouse_Model
{
    public class Carton : Cube , IEntity
    {
        private readonly int _x;
        private readonly int _y;
        private int _count;
        private readonly int _price;
        private readonly DateTime _creationTime;
        private DateTime _lastAction;
        private readonly CustomList<Carton> ? _collisionList = new CustomList<Carton>();
        private string _id;

        public int Count { get { return _count; } set { _count = value; } }
        public DateTime CreationTime { get { return _creationTime; } }
        public DateTime LastAction { get { return _lastAction; } set { _lastAction = value; } }
        public CustomList<Carton> ? CollisionList { get { return _collisionList; } set { } }

        public double LastActionDays
        {
            get
            {
                if (LastAction != default)
                {
                    return Math.Floor((DateTime.Now - LastAction).TotalDays);
                }
                else
                {
                    return Math.Floor((DateTime.Now - CreationTime).TotalDays);
                }
            }
        }
        
        public int Price { get { return _price; } }

        public string Id => _id;

        public Carton(int x, int y, int count, DateTime creationTime, int price) : base(x, y)
        {
            _x = x;
            _y = y;
            _count = count;
            _creationTime = creationTime;
            _price = price;
            _id = DateTime.Now.Ticks.ToString();


        }

        public override string ToString()
        {
            return $"({_x},{_y})";
        }
    }
}
