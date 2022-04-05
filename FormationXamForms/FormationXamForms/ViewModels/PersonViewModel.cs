using FormationXamForms.Helpers;
using FormationXamForms.Models;
using FormationXamForms.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FormationXamForms.ViewModels
{
    public class PersonViewModel : BaseViewModel
    {
        private IPageService _pageService;

        private string _idProp;

        public string IdProp
        {
            get => _idProp;
            set
            {
                if (_idProp != value) { _idProp = value; }
                OnPropertyChanged();
            }
        }

        private string _nomProp;

        public string NomProp
        {
            get => _nomProp;
            set
            {
                if (_nomProp != value) { _nomProp = value; }
                OnPropertyChanged();
            }
        }

        private string _prenomProp;

        public string PrenomProp
        {
            get => _prenomProp;
            set
            {
                if (_prenomProp != value) { _prenomProp = value; }
                OnPropertyChanged();
            }
        }

        private PersonModel _selectedPerson;

        public PersonModel SelectedPerson
        {
            get { return _selectedPerson; }
            set { SetValue(ref _selectedPerson, value); }
        }

        ObservableCollection<PersonModel> persons = new ObservableCollection<PersonModel>();
        public ObservableCollection<PersonModel> Persons { get { return persons; } }

        public ICommand ShowCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand ShowItemCommand { get; set; }

        public PersonViewModel()
        {
          
        }

        public PersonViewModel(IPageService pageService)
        {
            _pageService = pageService;

            ShowCommand = new Command(async c => await ShowData());

            Task.Run(async () => await ShowData());

            SaveCommand = new Command(async c => await SavetoDB());
            UpdateCommand = new Command(async c => await UpdatetoDB());
            DeleteCommand = new Command<PersonModel>(async c => await DeletetoDB(c));



            ShowItemCommand = new Command<PersonModel>(async c => await ReadData(c));

        }

        public async Task ShowData()
        {
            var lstPerson = await ApiHelper.GetPersonsAsync();
            this.Persons.Clear();
            lstPerson.ForEach((p) =>
            {
                this.Persons.Add(p);
            });
        }

        private async Task ReadData(PersonModel p)
        {
            if (p == null)
                return;
            SelectedPerson = null;

            IdProp = p.Id;
            NomProp = p.Nom;
            PrenomProp = p.Prenom;

            //await _pageService.DisplayAlert("YEAHHH", "Rentrer une valeur valide", "Ok");

            // string id = IdProp;
            //if (Persons.Any(a => a.Id == p.Id))
            //{
            //    PersonModel person = await ApiHelper.GetPersonByIdAsync(int.Parse(p.Id));

            //    IdProp = person.Id;
            //    NomProp = person.Nom;
            //    PrenomProp = person.Prenom;
            //}
            //else
            //{
            //    await _pageService.DisplayAlert("Erreur", "Rentrer une valeur valide", "Ok");
            //}
        }

        private async Task DeletetoDB(PersonModel p)
        {
            this.Persons.Remove(p);
            await ApiHelper.DeletePersonAsync(int.Parse(p.Id));
            await ShowData();
            await _pageService.DisplayAlert("Success", "SUCCESS", "Ok");
            //int id = IdProp;
            //if (Persons.Any(a => a.Id == num))
            //{
            //    await ApiHelper.DeletePersonAsync(int.Parse(num));
            //    await ShowData();
            //    await _pageService.DisplayAlert("Success", "SUCCESS", "Ok");
            //}
            //else
            //{
            //    await _pageService.DisplayAlert("Erreur", "Rentrer une valeur valide", "Ok");
            //}
        }

        private async Task UpdatetoDB()
        {
            string id = IdProp;
            var nom = NomProp;
            var prenom = PrenomProp;
            if (Persons.Any(a => a.Id == id))
            {
                PersonModel person = await ApiHelper.GetPersonByIdAsync(int.Parse(id));
                person.Nom = nom;
                person.Prenom = prenom;

                await ApiHelper.UpdatePersonAsync(person);

                IdProp = "0";
                NomProp = string.Empty;
                PrenomProp = string.Empty;

                await ShowData();
                await _pageService.DisplayAlert("Success", "SUCCESS", "Ok");
            }
            else
            {
                await _pageService.DisplayAlert("Erreur", "Rentrer une valeur valide", "Ok");
            }
        }

        private async Task SavetoDB()
        {
            if (String.IsNullOrWhiteSpace(NomProp) && String.IsNullOrWhiteSpace(PrenomProp))
            {
                await _pageService.DisplayAlert("Erreur", "Rentrer une valeur", "Ok");
                return;
            }
            var nom = NomProp;
            var prenom = PrenomProp;
            PersonModel p = new PersonModel(nom, prenom);

            await ApiHelper.AddPersonAsync(p);
            this.Persons.Add(p);

            IdProp = "0";
            NomProp = string.Empty;
            PrenomProp = string.Empty;

            await _pageService.DisplayAlert("Success", "SUCCESS", "Ok");
        }

    }
}
