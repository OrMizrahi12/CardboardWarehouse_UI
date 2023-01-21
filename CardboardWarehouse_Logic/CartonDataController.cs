using CardboardWarehouse_DS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CardboardWarehouse_Logic
{
    public class CartonDataController
    {
        AvlTree _cartonsTree;
        bool ok = true;
        public CartonDataController()
        {
            _cartonsTree = new AvlTree();
        }
        public void LoadDataToGrid(DataGrid grid)
        {
            if (ok)
            {
                _cartonsTree.LoadInitalData();
            }
            ok = false;
            LoadDataToGrid(grid, _cartonsTree.Root);
        }
        public void LoadDataToGrid(DataGrid grid, Carton travel)
        {
            if(travel == null)
            {
                return;
            }
            LoadDataToGrid(grid, travel.Left);
            grid.Items.Add(new Carton(travel.X,travel.Y, travel.Count));
            LoadDataToGrid(grid, travel.Right);

        }

        public void AddCarton(Carton carton)
        {
            if(NotNull(carton))
            {
                _cartonsTree.Add(carton);
            }
        }

        public void DeleteCarton(Carton carton)
        {
            if (NotNull(carton))
            {
                _cartonsTree.Delete(carton); 
            }
        }

        public Carton GetCarton(Carton carton)
        {
            if (NotNull(carton))
            {
                return _cartonsTree.Get(carton);
            }
            else
            {
                return default!;
            }
        }

        private bool NotNull(Carton carton)
        {
            return carton != null; 
        }

        public void UpdateStocK(bool increment,Carton carton)
        {
            _cartonsTree.UpdateStocK(increment, carton);
        }

    }
}
