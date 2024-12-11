namespace propertyApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "users.db3");

            var databaseHelper = new databaseHelper(dbPath);

            MainPage = new AppShell();
            MainPage = new NavigationPage(new MainPage());
        }
    }
}
