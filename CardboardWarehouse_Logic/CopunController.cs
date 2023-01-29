using CardboardWarehouse_DB;
using CardboardWarehouse_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CardboardWarehouse_Logic
{
    public class CopunController
    {
        public static void AddCopun(Copun copun)
        {
            if(NotNull(copun))
            {
                if (!GeneralDataHolder.Copuns.Contain(copun))
                {
                    GeneralDataHolder.Copuns.Add(copun);
                    LogEventController.AddLogEvent($"The copun {copun} are added");
                }
            }
        }

        public static void DeleteCopun(Copun copun)
        {
            if (NotNull(copun))
            {
                GeneralDataHolder.Copuns.Remove(copun);
                LogEventController.AddLogEvent($"The copun {copun} are deleted");
            }
        }

        public static void ClearCopuns()
        {
            GeneralDataHolder.Copuns.Clear();
        }

        public static void LoadCopunGrid(DataGrid dataGrid)
        {
            foreach (var item in GeneralDataHolder.Copuns.Items)
            {
                dataGrid.Items.Add(item);
            }
        }

        private static bool NotNull(Copun copun)
        {
            return copun != null;
        }

        public static bool CopunExsist(Copun copun)
        {
            if (NotNull(copun))
            {
                return GeneralDataHolder.Copuns.Contain(copun);
            }
            else
            {
                return false;
            }
        }

        public static float GetPrecent(string codeCopun)
        {
            foreach (var item in GeneralDataHolder.Copuns.Items)
            {
                if(item.CopunName == codeCopun)
                {
                    return item.Precent;
                }
            }
            return 0;
        }
    }
}
