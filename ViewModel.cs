using System.Collections.ObjectModel;

namespace LearnOneNote
{
    class ViewModel
    {
        // hold ListBoxItems
        private static ObservableCollection<string> _items = new ObservableCollection<string>();
        public static ObservableCollection<string> ItemList
        {
            get { return _items ?? (_items = new ObservableCollection<string>()); }
            set { _items = value; }
        }
    }
}
