using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace LearnOneNote
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public partial class MainPage : Page
    {
        // hold ListBoxItems
        private ObservableCollection<string> _items = new ObservableCollection<string>();
        public ObservableCollection<string> ItemList
        {
            get { return _items ?? (_items = new ObservableCollection<string>()); }
            set { _items = value; }
        }

        // initialize ListBoxItems
        public void initItemList()
        {
            ItemList.Clear();

            foreach (string s in GlobalVars.Text) { ItemList.Add(s); }
        }

        // main class
        public MainPage()
        {
            InitializeComponent();

            initItemList();

            DataContext = this;
        }

        // run when a new selection is made in the ListBox
        private void newSelect(object sender, RoutedEventArgs e)
        {
            switch((string)Items.SelectedValue)
            {
                case "OneNote":
                    initItemList();
                    break;

                case "   The Main Menu":
                    initItemList();
                    foreach (string s in GlobalVars.MainMenu()) { ItemList.Insert(2, s); }
                    break;
            }
        }
    }
}
