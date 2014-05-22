using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.CompilerServices;
using System.Text;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media;
using Windows.Data;

namespace LearnOneNote
{
    class ViewModel
    {
        private static ObservableCollection<string> _items = new ObservableCollection<string>();
        public static ObservableCollection<string> ItemList
        {
            get { return _items ?? (_items = new ObservableCollection<string>()); }
            set { _items = value; }
        }

        private static ObservableCollection<Type> _pages = new ObservableCollection<Type>();
        public static ObservableCollection<Type> Pages
        {
            get { return _pages ?? (_pages = new ObservableCollection<Type>()); }
            set { _pages = value; }
        }
    }
}
