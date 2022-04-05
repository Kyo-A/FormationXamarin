using FormationXamForms.Persistence;
using FormationXamForms.Services;
using FormationXamForms.Services.SQLite;
using FormationXamForms.ViewModels;
using FormationXamForms.ViewModels.SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FormationXamForms.Locator
{
    public class ViewModelLocator
    {
        public ViewModelLocator Main
        {
            get
            {
                return new ViewModelLocator();
            }
        }

        public CalculViewModel Calcul => new CalculViewModel();

        public LoginViewModel Login => new LoginViewModel();
       
        public PersonViewModel Person
        {
            get
            {
                var pageService = new PageService();
                return new PersonViewModel(pageService);
            }
        }

        public ContactListViewModel Contact
        {
            get 
            {
                var contactDao = new ContactDao(DependencyService.Get<ISQLiteDb>());
                var pageService = new PageService();
                return new ContactListViewModel(pageService, contactDao); 
            }
        }
    }
}
