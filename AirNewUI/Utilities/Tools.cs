using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AirNewUI.Utilities
{
    class Tools
    {
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
