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
    public class LogEventController
    {
        public static void LoadLogEventToGrid(DataGrid dataGrid)
        {
           
            foreach (var logEvent in GeneralDataHolder.SystemEvents.Items)
            {
                if (!dataGrid.Items.Contains(logEvent))
                {
                    dataGrid.Items.Add(logEvent);
                }
            }
        }
        static public void AddLogEvent(string eventName)
        {
             SystemEvent system = new SystemEvent(DateTime.Now, eventName);
            if (!GeneralDataHolder.SystemEvents.Contain(system))
            {
                GeneralDataHolder.SystemEvents.Add(new SystemEvent(DateTime.Now, eventName));
            }
            
        }

        public static void ClearLogEvent()
        {
            GeneralDataHolder.SystemEvents.Clear(); 
        }
    }
}
