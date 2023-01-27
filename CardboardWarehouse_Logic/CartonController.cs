using CardboardWarehouse_DB;
using CardboardWarehouse_DS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using CardboardWarehouse_Model;
using System.Security.Cryptography;
using System.Diagnostics;

namespace CardboardWarehouse_Logic
{
    public class CartonController
    {
        public static void LoadDataToGrid(DataGrid grid)
        {
            LoadDataFromJson();
            JsonLogic.UpdateJsonData(PathInfo.CartonJsonPath);
            GeneralDataHolder.Cartons.LoadDataToGrid(grid);
        }

        static public void LoadDataFromJson()
        {
            JsonDataInformer.LoadDataFromJson(PathInfo.CartonJsonPath);
        }


        public static void AddCarton(Carton carton)
        {
            if (NotNull(carton))
            {
                GeneralDataHolder.Cartons.Add(carton);
                JsonLogic.UpdateJsonData(PathInfo.CartonJsonPath);
            }
        }

        public static void DeleteCarton(Carton carton)
        {
            if (NotNull(carton))
            {
                Carton removedCarton = GeneralDataHolder.Cartons.Remove(carton);

                if (IfNotNull(removedCarton))
                {
                    AddToRecyclingBasket(removedCarton);
                }
                
                JsonLogic.UpdateJsonData(PathInfo.CartonJsonPath);
            }

        }
        private static void DeleteUnderCollision(int index, Carton carton)
        {
            Carton ? removedCarton = GeneralDataHolder.Cartons?.Table?[index]?.CollisionList?.Remove(carton);
          
            if (IfNotNull(removedCarton!))
            {
                AddToRecyclingBasket(removedCarton!);
            }
        }

        public static Carton GetCarton(Carton carton)
        {
            if (NotNull(carton))
            {
               return GeneralDataHolder.Cartons.Get(carton);
            }
            else
            {
                return default!;
            }
        }

        public static void IncrementStock(Carton carton)
        {
            if (NotNull(carton))
            {
                Carton pointer = GeneralDataHolder.Cartons.Get(carton);
                pointer.Count++;
                UpdateCartonLastAction(pointer);
            }
            JsonLogic.UpdateJsonData(PathInfo.CartonJsonPath);
        }

        public static void DicrementCarton(Carton carton)
        {
            if (NotNull(carton) && carton.Count > 0)
            {
                GeneralDataHolder.Cartons.Get(carton).Count--;
            }
            JsonLogic.UpdateJsonData(PathInfo.CartonJsonPath);

        }

        public static void UpdateCartonLastAction(Carton carton)
        {
            carton.LastAction = DateTime.Now;
        }

        private static bool NotNull(Carton carton)
        {
            return carton != null;
        }
        public static Carton GetClosestCarton(int x, int y)
        {
            Carton closestCarton = new(short.MaxValue, short.MaxValue, 0, DateTime.Now,0);
            for (int i = 0; i < GeneralDataHolder.Cartons.Table.Length; i++)
               {
                
                if (GeneralDataHolder.Cartons.Table[i] != null)
                {
                    if (CheacCartonRange(GeneralDataHolder.Cartons.Table[i], x, y))
                    {
                        if (IsBigger(closestCarton, GeneralDataHolder.Cartons.Table[i]))
                        {
                            closestCarton = GeneralDataHolder.Cartons.Table[i];
                        }
                    }
                }
            }

            if (closestCarton.X == short.MaxValue)
            {
                return null!;
            }
            else
            {
                return closestCarton;
            }
        }

        private static bool CheacCartonRange(Carton candidate, int x, int y)
        {
            if(candidate.X > x && candidate.X - x <= 10 && candidate.Y > y && candidate.Y - y <= 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool IsBigger(Carton closestCarton, Carton candidate)
        {
            if(closestCarton.X + closestCarton.Y > candidate.X + candidate.Y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void GarbejCollection()
        {            
            foreach (var carton  in GeneralDataHolder.Cartons.Table)
            {
                if (carton?.LastActionDays > 5)
                {
                    DeleteCarton(carton);
                }
            }
        }
        public static void AddToRecyclingBasket(Carton carton)
        {
            if (IfNotNull(carton))
            {
                GeneralDataHolder.CartonUndoStack.Push(carton);
            }
        }
        // this is adding the carton back to the stock
        public static void CartonUndoActions()
        {
            if(GeneralDataHolder.CartonUndoStack.Size() > 0)
            {
                Carton? cartonFromBasket = GeneralDataHolder.CartonUndoStack.Pop();
                
                if (IfNotNull(cartonFromBasket))
                {
                    AddToRedoStack(cartonFromBasket);
                    AddCarton(cartonFromBasket);
                }
            }
        }

        static private bool IfNotNull(Carton carton)
        {
            return carton != null;
        }

        static public void CartonRedoAction()
        {
            if(GeneralDataHolder.CartonRedoStack.Size() > 0)
            {
                Carton? cartonFromRedoList = GeneralDataHolder.CartonRedoStack.Pop();

                if (IfNotNull(cartonFromRedoList))
                {
                    AddToRecyclingBasket(cartonFromRedoList);
                    DeleteCarton(cartonFromRedoList);
                }
            }    
        }

        static public void AddToRedoStack(Carton carton)
        {
            if (IfNotNull(carton))
            {
                GeneralDataHolder.CartonRedoStack.Push(carton);
            }
        }
    }
}
