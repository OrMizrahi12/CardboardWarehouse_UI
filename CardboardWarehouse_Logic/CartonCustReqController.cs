using CardboardWarehouse_DB;
using CardboardWarehouse_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CardboardWarehouse_Logic
{
    public class CartonCustReqController
    {
        public static void LoadDataToGrid(DataGrid dataGrid)
        {
            foreach (Cube cube in GeneralDataHolder.CartonCustReq.Items)
            {
                if (NotNull(cube))
                {
                    dataGrid.Items.Add(cube);
                }
            }
        }
        public static void Add(Cube cube)
        {
            if (NotNull(cube))
            {
                GeneralDataHolder.CartonCustReq.Add(cube);
            }
        }

        public static void AddReqToStock()
        {
            foreach (Cube cube in GeneralDataHolder.CartonCustReq.Items)
            {
                if(NotNull(cube))
                {
                    int price = FindPrice(cube.X , cube.Y);

                    CartonController.AddCarton(new Carton(cube.X, cube.Y, 5, DateTime.Now, price));
                }
            }
            Clear();
            MessageBox.Show("Added to stock!");
        }

        private static int FindPrice(int x, int y)
        {
            return (x + y) / 2;
        }

        public static void Clear()
        {
            GeneralDataHolder.CartonCustReq.Clear();
        }

        private static bool NotNull(object obj)
        {
            return obj != null;
        }
    }
}
