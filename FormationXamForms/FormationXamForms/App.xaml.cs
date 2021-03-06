using FormationXamForms.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormationXamForms
{
    public partial class App : Application
    {
        public static Theme AppTheme { get; set; }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
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

        public enum Theme
        {
            Light,
            Dark
        }
    }
}
