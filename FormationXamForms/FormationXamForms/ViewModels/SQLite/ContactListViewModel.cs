using FormationXamForms.Models;
using FormationXamForms.Services;
using FormationXamForms.Services.SQLite;
using FormationXamForms.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FormationXamForms.ViewModels.SQLite
{
    public class ContactListViewModel : BaseViewModel
    {
        private IDao<ContactModel> _contactDao;

        private IPageService _pageService;

        private ContactViewModel _selectedContact;

        public ContactViewModel SelectedContact
        {
            get { return _selectedContact; }
            set { SetValue(ref _selectedContact, value); }
        }
        public ObservableCollection<ContactViewModel> ContactList { get; set; } = new ObservableCollection<ContactViewModel>();

        public ICommand AddContactCommand { get; set; }
        public ICommand DeleteContactCommand { get; set; }
        public ICommand SelectContactCommand { get; set; }

        public ContactListViewModel() { }

        public ContactListViewModel(IPageService pageService, IDao<ContactModel> contactDao) 
        {
            _pageService = pageService;
            _contactDao = contactDao;

            Task.Run(async () => await LoadContacts());

            DeleteContactCommand = new Command<ContactViewModel>(async c => await DeleteContact(c));
            AddContactCommand = new Command<ContactViewModel>(async c => await AddContact());
            SelectContactCommand = new Command<ContactViewModel>(async c => await SelectContact(c));

            MessagingCenter.Subscribe<ContactDetailViewModel, ContactModel>(this, Events.ContactAdded, OnContactAdded);

        }

        private void OnContactAdded(ContactDetailViewModel source, ContactModel contact)
        {
            ContactList.Add(new ContactViewModel(contact));
        }

        private async Task AddContact()
        {
            await _pageService.PushAsync(new ContactDetailsPage(new ContactViewModel()));
        }

        private async Task SelectContact(ContactViewModel contact)
        {
            if (contact == null)
                return;
            SelectedContact = null;
            await _pageService.PushAsync(new ContactDetailsPage(contact));
        }

        private async Task LoadContacts()
        {
            var contacts = await _contactDao.GetListAsync();
            foreach (var c in contacts)
                ContactList.Add(new ContactViewModel(c));
        }

        private async Task DeleteContact(ContactViewModel c)
        {
            if(await _pageService.DisplayAlert("Attention !!!", $"Etes-vous sur de voir supprimer { c.FirstName } ?", "Yes", "No"))
            {
                ContactList.Remove(c);
                var contactModel = await _contactDao.GetItemById(c.Num);
                await _contactDao.DeleteItem(contactModel);
            }
        }

    }
}
