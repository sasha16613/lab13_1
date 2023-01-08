using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System;
using System.IO;
using Xamarin.Forms;
using lab13_1.Data;
using System.Reflection;

namespace lab13_1
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "lab13_1.db3";
        public static ClientDB database;
        public static ClientDB Database
        {
            get
            {
                if (database == null)
                {

                    database = new ClientDB(
                        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), DATABASE_NAME));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
