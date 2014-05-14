namespace LearnOneNote
{
    public static class GlobalVars
    {
        private static string[] _home = { "OneNote", "   The Main Menu" };

        private static string[] _mainMenu = { "      Draw" };

        public static string[] Home() { return _home; }
        public static string[] MainMenu() { return _mainMenu; }

        public static string[] Text = Home();
    }
}
