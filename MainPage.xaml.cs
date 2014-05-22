using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml.Controls;

namespace LearnOneNote
{
    public partial class MainPage : Page
    {
        // ListBox data
        private ObservableCollection<string> _items = new ObservableCollection<string>();
        public ObservableCollection<string> ItemList
        {
            get { return _items ?? (_items = new ObservableCollection<string>()); }
            set { _items = value; }
        }

        // Init ListBox data
        public void initItemList()
        {
            foreach (string s in GlobalVars.Home()) { ItemList.Add(s); }
        }

        // Title text - problem is something in here ...
        public string titleText
        {
            get
            {
                string title = Items.SelectedValue.ToString();

                while(title.StartsWith(" "))
                {
                    title = title.Remove(0, 1);
                }

                OnPropertyChanged("titleText");

                return title;
            }
        }

        // Something about telling the title that the property was updated - I don't get this part
        // ... problem could be here, too.
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        // Handle main events
        public MainPage()
        {
            InitializeComponent();

            initItemList();

            DataContext = this;

            Items.SelectedIndex = 0;
        }
    }
}
