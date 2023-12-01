using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JocRegals
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            // Initialize NavigationPage for further calls to push & pop
            MainPage = new NavigationPage(new Pages.Intro());
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
