using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DirectBeviorRating.Data;
using System.IO;

namespace DirectBeviorRating
{
    public partial class App : Application
    {
        static PupilDatabase pupilDatabase;
        static FocusDatabase focusDatabase;

        public static PupilDatabase PupilDatabase
        {
            get
            {
                if (pupilDatabase == null) {
                    pupilDatabase = new PupilDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Pupils.db3"));
                }
                return pupilDatabase;
            }
        }

        public static FocusDatabase FocusDatabase
        {
            get
            {
                if (focusDatabase == null)
                {
                    focusDatabase = new FocusDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Focus.db3"));
                }
                return focusDatabase;
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
