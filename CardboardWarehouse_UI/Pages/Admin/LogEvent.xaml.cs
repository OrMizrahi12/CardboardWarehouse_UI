using CardboardWarehouse_Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CardboardWarehouse_UI.Pages.Admin
{

    public partial class LogEvent : Page
    {
        public LogEvent()
        {
            InitializeComponent();
            LoadData();
        }

        private void BtnClearLogEvent_Click(object sender, RoutedEventArgs e)
        {
            LogEventController.ClearLogEvent();
            LoadData();
        }

        private void LoadData()
        {
            systemEventGrid.Items.Clear();
            LogEventController.LoadLogEventToGrid(systemEventGrid);
        }
    }
}
