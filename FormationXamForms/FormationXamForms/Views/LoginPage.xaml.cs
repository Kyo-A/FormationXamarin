using FormationXamForms.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormationXamForms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            //ShowLoginIndicator.IsRunning = false;
            //BindingContext = new LoginViewModel();
        }

        private void UserNameEntry_Focused(object sender, FocusEventArgs e)
        {
            EntryUsername.HorizontalTextAlignment = TextAlignment.Center;
        }

        private void UserNameEntry_Unfocused(object sender, FocusEventArgs e)
        {
            EntryUsername.HorizontalTextAlignment = TextAlignment.Start;
        }

        private void PasswordEntry_Focused(object sender, FocusEventArgs e)
        {
            EntryPassword.HorizontalTextAlignment = TextAlignment.Center;
        }

        private void PasswordEntry_Unfocused(object sender, FocusEventArgs e)
        {
            EntryPassword.HorizontalTextAlignment = TextAlignment.Start;
        }

        //private async void Login_Success(object sender, EventArgs e)
        //{
        //    IsBusy = true;

        //    if (EntryUsername.Text == "john@gmail.com" && EntryPassword.Text == "12345678")
        //    {
        //        await DisplayAlert("Login Success", "Your are logged", "Okay", "Cancel");
        //        //ShowLoginIndicator.IsVisible = true;
        //        //ShowLoginIndicator.IsRunning = true;
        //        //await Delay_Time(5000);
        //        Navigation.InsertPageBefore(new MainPage(), this);
        //        await Navigation.PopAsync();
        //    }
        //    else
        //    {
        //        await DisplayAlert("Login Failed", "Username & passwored are wrongs !", "Okay", "Cancel");
        //    }

        //    IsBusy = false;
        //}

        async Task Delay_Time(int value)
        {
            await Task.Delay(value);
        }

        private async Task Login()
        {
            IsBusy = true;
            await Task.Delay(5000);
        }



    }
}