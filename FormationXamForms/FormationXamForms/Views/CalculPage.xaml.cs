using FormationXamForms.Models;
using FormationXamForms.Persistence;
using FormationXamForms.Services.SQLite;
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
    public partial class CalculPage : ContentPage
    {
        public CalculPage()
        {
            InitializeComponent();

            //IDao<ContactModel> contactDao = new ContactDao(DependencyService.Get<ISQLiteDb>());
            //BindingContext = new GenericViewModel<ContactModel>(contactDao);
        }

        public async void Logout_Success(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Exit", "Do you wan't to exit the App?", "Yes", "No");
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
    }
}