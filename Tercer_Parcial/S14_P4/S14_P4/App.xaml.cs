using S14_P4.Data;

namespace S14_P4
{
    public partial class App : Application
    {
        public static DatabaseService database;
        public static DatabaseService Database
        {
            get
            {
                if (database == null)
                {
                    string path = Path.Combine(
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.LocalApplicationData),
                        "Farmacia.db3");
                    database = new DatabaseService(path);
                }
                return database;

            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
            
        }
    }
}