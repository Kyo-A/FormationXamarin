using System;
using System.Collections.Generic;
using System.Text;
using FormationXamForms.Models;

namespace FormationXamForms.ViewModels.SQLite
{
    public class ContactViewModel : BaseViewModel
    {
        private int _num;

        public int Num
        {
            get => _num;
            set
            {
                if (_num != value) { _num = value; }
                OnPropertyChanged();
            }
        }

        private string _firstName;

        public string FirstName
        {
            get => _firstName;
            set
            {
                if (_firstName != value) { _firstName = value; }
                OnPropertyChanged();
            }
        }

        private string _lastName;

        public string LastName
        {
            get => _lastName;
            set
            {
                if (_lastName != value) { _lastName = value; }
                OnPropertyChanged();
            }
        }

        private int _age;

        public int Age
        {
            get => _age;
            set
            {
                if (_age != value) { _age = value; }
                OnPropertyChanged();
            }
        }

        public ContactViewModel() { }

        public ContactViewModel(ContactModel model) 
        {
            _num = model.Num;
            _firstName = model.FirstName;
            _lastName = model.LastName;
            _age = model.Age;
        }


    }
}
