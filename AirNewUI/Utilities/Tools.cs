using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AirTicket.Utilities
{
    class Tools
    {
        public static MetroWindow loginWindow;
        public static MetroWindow mainWindow;
        public static string UserName;

        public static MetroWindow GetWindow()
        {
            return (MetroWindow)Application.Current.MainWindow;
        }

        public static HamburgerMenuIconItem GetIconItem(string hamburgerIconItemName)
        {
            return (HamburgerMenuIconItem)GetWindow().FindName(hamburgerIconItemName);
        }
    }
}
