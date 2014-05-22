using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.CompilerServices;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.ApplicationSettings;

namespace LearnOneNote
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public partial class MainPage : Page
    {
        public void initItemList()
        {
            foreach (string s in GlobalVars.Home()) { ViewModel.ItemList.Add(s); }
        }

        public void initPages()
        {
            foreach (Type t in GlobalVars.HomeP()) { ViewModel.Pages.Add(t); }
        }

        public MainPage()
        {
            InitializeComponent();

            initItemList();
            initPages();

            DataContext = new ViewModel();

            Items.SelectedIndex = 0;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            SettingsPane.GetForCurrentView().CommandsRequested += onCommandsRequested;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            SettingsPane.GetForCurrentView().CommandsRequested -= onCommandsRequested;
        }

        void onCommandsRequested(SettingsPane settingsPane, SettingsPaneCommandsRequestedEventArgs e)
        {
            SettingsCommand defaultsCommand = new SettingsCommand("options", "Options",
                (handler) =>
                {
                    Settings sf = new Settings();
                    sf.HeaderBackground = new SolidColorBrush(Colors.DarkGoldenrod);
                    sf.Show();
                });
            e.Request.ApplicationCommands.Add(defaultsCommand);
        }

        private void remove()
        {
            foreach (string s in GlobalVars.AppBarMenu()) { ViewModel.ItemList.Remove(s); }
            foreach (string s in GlobalVars.ColorPalate()) { ViewModel.ItemList.Remove(s); }
            foreach (string s in GlobalVars.DrawMenu()) { ViewModel.ItemList.Remove(s); }
            foreach (string s in GlobalVars.DrawnItemsMenu()) { ViewModel.ItemList.Remove(s); }
            foreach (string s in GlobalVars.KeyboardShortcuts()) { ViewModel.ItemList.Remove(s); }
            foreach (string s in GlobalVars.MainMenu()) { ViewModel.ItemList.Remove(s); }
            foreach (string s in GlobalVars.PictureMenu()) { ViewModel.ItemList.Remove(s); }
            foreach (string s in GlobalVars.TableCellsMenu()) { ViewModel.ItemList.Remove(s); }
            foreach (string s in GlobalVars.TableMenu()) { ViewModel.ItemList.Remove(s); }
            foreach (string s in GlobalVars.TextGroupMenu()) { ViewModel.ItemList.Remove(s); }
            foreach (string s in GlobalVars.TextMenu()) { ViewModel.ItemList.Remove(s); }

            /*
             * foreach (Type t in GlobalVars.AppBarMenuP()) { ViewModel.Pages.Remove(t); }
             * foreach (Type t in GlobalVars.ColorPalateP()) { ViewModel.Pages.Remove(t); }
             * foreach (Type t in GlobalVars.DrawMenuP()) { ViewModel.Pages.Remove(t); }
             * foreach (Type t in GlobalVars.DrawnItemsMenuP()) { ViewModel.Pages.Remove(t); }
             * foreach (Type t in GlobalVars.KeyboardShortcutsP()) { ViewModel.Pages.Remove(t); }
             * foreach (Type t in GlobalVars.MainMenuP()) { ViewModel.Pages.Remove(t); }
             * foreach (Type t in GlobalVars.PictureMenuP()) { ViewModel.Pages.Remove(t); }
             * foreach (Type t in GlobalVars.TableCellsMenuP()) { ViewModel.Pages.Remove(t); }
             * foreach (Type t in GlobalVars.TableMenuP()) { ViewModel.Pages.Remove(t); }
             * foreach (Type t in GlobalVars.TextGroupMenuP()) { ViewModel.Pages.Remove(t); }
             * foreach (Type t in GlobalVars.TextMenuP()) { ViewModel.Pages.Remove(t); }
             */
        }

        private void newSelect(object sender, RoutedEventArgs e)
        {
            switch((string)Items.SelectedValue)
            {
                case "OneNote":
                    remove();
                    break;

                case "   The Main Menu":
                    remove();
                    foreach (string s in GlobalVars.MainMenu()) { ViewModel.ItemList.Insert(2, s); }
                    break;

                case "   The Text Menu":
                    remove();
                    foreach (string s in GlobalVars.TextMenu()) { ViewModel.ItemList.Insert(3, s); }
                    break;

                case "   The Text Group Selected Menu":
                    remove();
                    foreach (string s in GlobalVars.TextGroupMenu()) { ViewModel.ItemList.Insert(4, s); }
                    break;

                case "   The Table Menu":
                    remove();
                    foreach (string s in GlobalVars.TableMenu()) { ViewModel.ItemList.Insert(5, s); }
                    break;

                case "   The Table Cells Selected Menu":
                    remove();
                    foreach (string s in GlobalVars.TableCellsMenu()) { ViewModel.ItemList.Insert(6, s); }
                    break;

                case "   The Draw Menu":
                    remove();
                    foreach (string s in GlobalVars.DrawMenu()) { ViewModel.ItemList.Insert(7, s); }
                    break;

                case "   The Drawn Items Selected Menu":
                    remove();
                    foreach (string s in GlobalVars.DrawnItemsMenu()) { ViewModel.ItemList.Insert(8, s); }
                    break;

                case "   The Picture Selected Menu":
                    remove();
                    foreach (string s in GlobalVars.PictureMenu()) { ViewModel.ItemList.Insert(9, s); }
                    break;

                case "   The App Bar and Settings":
                    remove();
                    foreach (string s in GlobalVars.AppBarMenu()) { ViewModel.ItemList.Insert(10, s); }
                    break;

                case "   Keyboard Shortcuts":
                    remove();
                    foreach (string s in GlobalVars.KeyboardShortcuts()) { ViewModel.ItemList.Insert(11, s); }
                    break;

                case "   Color Palate":
                    remove();
                    foreach (string s in GlobalVars.ColorPalate()) { ViewModel.ItemList.Insert(12, s); }
                    break;
            }

            //title.Text = titleText;

            dataFrame.Navigate(ViewModel.Pages[Items.SelectedIndex]);
        }
    }
}
