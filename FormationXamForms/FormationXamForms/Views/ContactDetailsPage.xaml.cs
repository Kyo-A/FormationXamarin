using FormationXamForms.Persistence;
using FormationXamForms.Services;
using FormationXamForms.Services.SQLite;
using FormationXamForms.ViewModels.SQLite;
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
    public partial class ContactDetailsPage : ContentPage
    {

        public ContactDetailsPage(ContactViewModel contactViewModel)
        {
            InitializeComponent();
            var contactDao = new ContactDao(DependencyService.Get<ISQLiteDb>());
            var pageService = new PageService();
            BindingContext = new ContactDetailViewModel(contactViewModel ?? new ContactViewModel(), pageService, contactDao);
        }
    }
}