using FormationXamForms.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FormationXamForms.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private bool isLoading, isVisible;

        private string username, password;

        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }

        public bool IsLoading
        {
            get { return isLoading; }
            set { isLoading = value; 
                  OnPropertyChanged("IsLoading"); }
        }

        public bool IsVisible
        {
            get { return isVisible; }
            set { isVisible = value; 
                  OnPropertyChanged("IsVisible"); }
        }

        public LoginViewModel()
        {
            OnLoadCommand = new Command(async () => await Loading());
            Username = "john@gmail.com";
            Password = "12345678";
        }

        public ICommand OnLoadCommand { get; set; }

        public async Task Loading()
        {
            IsLoading = true;
            IsVisible = true;

            if (Username == "john@gmail.com" && Password == "12345678")
            {
                await Application.Current.MainPage.DisplayAlert("login success", "your are logged", "okay", "cancel");
                await Task.Delay(3000);
                await Application.Current.MainPage.Navigation.PushModalAsync(new MainPage());
                // await Application.Current.MainPage.Navigation.InsertPageBefore(new MainPage(), Navigation.NavigationStack[0]);
                // Application.Current.MainPage = new NavigationPage(new MainPage());
                // await Application.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("login failed", "username & passwored are wrongs !", "okay", "cancel");
            }

            IsLoading = false;
            IsVisible = false;

        }
    }
}
