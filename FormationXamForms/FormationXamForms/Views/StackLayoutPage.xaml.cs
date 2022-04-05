using FormationXamForms.Themes;
using FormationXamForms.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing;
using static FormationXamForms.App;

namespace FormationXamForms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StackLayoutPage : ContentPage
    {
        public StackLayoutPage()
        {
            InitializeComponent();
            BindingContext = new StackLayoutViewModel();
        }

        public async void Logout_Success(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Exit", "Do you want to exit the App ?", "Yes", "No");
            if (answer == true)
            {
                //await Navigation.PushModalAsync(new NavigationPage(new LoginPage()));
                Navigation.InsertPageBefore(new LoginPage(), this);
                await Navigation.PopAsync();
            }
            else
            {
                App.Current.MainPage = new NavigationPage(new MainPage());
            }
        }

        //private void Switch_Toggled(object sender, ToggledEventArgs e)
        //{
        //    var toggleStatus = themeToggle.IsToggled;
        //    SetTheme(toggleStatus);

        //}

        //void SetTheme(bool status)
        //{
        //    Theme themeRequested;
        //    if (status)
        //    {
        //        themeRequested = Theme.Dark;
        //    }
        //    else
        //    {
        //        themeRequested = Theme.Light;
        //    }

        //    DependencyService.Get<IAppTheme>().SetAppTheme(themeRequested);
        //}

        //public void scanView_OnScanResult(Result result)
        //{
        //    Device.BeginInvokeOnMainThread(async () =>
        //    {
        //        await DisplayAlert("Scanned result", "The barcode's text is " + result.Text + ". The barcode's format is " + result.BarcodeFormat, "OK");
        //    });
        //}

        public void Btn_Vibrate(object sender, EventArgs e)
        {
            try
            {
                Vibration.Vibrate();

                var duration = TimeSpan.FromSeconds(1);
                Vibration.Vibrate(duration);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}