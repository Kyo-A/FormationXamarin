using FormationXamForms.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormationXamForms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        ObservableCollection<ContactModel> contacts;

        public HomePage()
        {
            InitializeComponent();
            Data();
            contactsList.ItemsSource = contacts;
        }

        public void Data()
        {
            contacts = new ObservableCollection<ContactModel>
            {
                new ContactModel(){Num = 1, FirstName = "John", Age= 40},
                new ContactModel(){Num = 2, FirstName = "Sylvie", Age= 25},
                new ContactModel(){Num = 3, FirstName = "Fab", Age= 20},
                new ContactModel(){Num = 4, FirstName = "Pat", Age= 10},
            };
        }

        // ItemSelected="Lst_ItemSelected"

        async void Lst_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var ans = await DisplayAlert("Question?", "Would you like Delete", "Yes", "No");
            if (ans == true)
            {
                contacts.Remove(e.SelectedItem as ContactModel);
                contactsList.ItemsSource = contacts;
            }
        }

        // ItemTapped="OnButtonClicked"
        private void Lst_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var details = e.Item as ContactModel;

            DisplayAlert("Item tapped", details.Age.ToString(), "ok");
        }

        private void SearchBar_TxtChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                contactsList.ItemsSource = contacts;
            }
            else
            {
                contactsList.ItemsSource = contacts.Where(x => x.FirstName.StartsWith(e.NewTextValue));
            }
        }

        private void More_Clicked(object sender, EventArgs e)
        {
            var name = (sender as MenuItem).CommandParameter as string;
            DisplayAlert("context action", name, "Ok");
        }

        public async void Logout_Success(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Exit", "Do you want to exit the App?", "Yes", "No");
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