using FormationXamForms.Services.SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FormationXamForms.ViewModels
{
    public class GenericViewModel<T> : BaseViewModel where T : class 
    {
        protected readonly IDao<T> _Repository;

        private T _selectedContact;

        public T SelectedContact
        {
            get { return _selectedContact; }
            set { SetValue(ref _selectedContact, value); }
        }

        public ObservableCollection<T> List { get; set; } = new ObservableCollection<T>();

        public GenericViewModel()
        {
        }

        public GenericViewModel(IDao<T> repository)
        {
            _Repository = repository;

        }

    }
}
