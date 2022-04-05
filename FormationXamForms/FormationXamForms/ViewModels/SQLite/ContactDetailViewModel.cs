using FormationXamForms.Models;
using FormationXamForms.Services;
using FormationXamForms.Services.SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FormationXamForms.ViewModels.SQLite
{
    public class ContactDetailViewModel
    {
        private IDao<ContactModel> _contactDao;

        private IPageService _pageService;

        public ContactModel ContactModel { get; private set; }
        public ICommand SaveCommand { get; set; }

        public ContactDetailViewModel(ContactViewModel contactViewModel,IPageService pageService, IDao<ContactModel> contactDao)
        {
            _pageService = pageService;
            _contactDao = contactDao;

            SaveCommand = new Command(async () => await Save());

            if (contactViewModel == null)
                throw new ArgumentNullException(nameof(contactViewModel));

            ContactModel = new ContactModel
            {
                Num = contactViewModel.Num,
                FirstName = contactViewModel.FirstName,
                LastName = contactViewModel.LastName,
                Age = contactViewModel.Age
            };

        }
        private async Task Save()
        {
            if(String.IsNullOrWhiteSpace(ContactModel.FirstName) && String.IsNullOrWhiteSpace(ContactModel.LastName))
            {
                await _pageService.DisplayAlert("Erreur", "Rentrer une valeur", "Ok");
                return;
            }
            else
            {
                await _contactDao.AddItem(ContactModel);
                MessagingCenter.Send(this, Events.ContactAdded, ContactModel);
            }
            await _pageService.PopAsync();         
        }
    }
}
