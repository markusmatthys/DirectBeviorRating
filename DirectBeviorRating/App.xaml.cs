using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DirectBeviorRating
{
    public partial class App : Application
    {
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
