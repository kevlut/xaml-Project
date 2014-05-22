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
        // initialize ListBoxItems
        public void initItemList()
        {
            foreach (string s in GlobalVars.Text) { ViewModel.ItemList.Add(s); }
        }

        // main class
        public MainPage()
        {
            InitializeComponent();

            initItemList();

            DataContext = new ViewModel();
        }
    }
}
