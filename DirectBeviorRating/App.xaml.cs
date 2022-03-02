using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DirectBeviorRating.Data;
using System.IO;

namespace DirectBeviorRating
{
    public partial class App : Application
    {
        static BehaviorDatabase database;

        public static BehaviorDatabase Database
       {
            get
            {
                if (database == null) {
                    database = new BehaviorDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Pupils.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new ApplicationShell();
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
